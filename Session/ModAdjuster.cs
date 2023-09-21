using Sandbox.Definitions;
using Sandbox.ModAPI;
using System;
using VRage.Game;
using VRage.Game.Components;
using System.Text;
using ModAdjusterV2.Definitions;
using ModAdjusterV2.Definitions.Blocks;
using VRage.ObjectBuilders;
using System.Collections.Generic;
using VRage.Collections;

namespace ModAdjusterV2.Session
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ModAdjuster : MySessionComponentBase
    {
        private const string PATH = "Data\\ModAdjuster\\ModAdjusterFiles.txt";

        internal static string ModPath;

        private readonly HashSet<string> _clearedClasses = new HashSet<string>();

        public override void LoadData()
        {
            ModPath = ModContext.ModPath;
            Logs.InitLogs();
            LoadAdjusterDefs();
        }

        public override void BeforeStart()
        {

        }

        protected override void UnloadData()
        {
            _clearedClasses.Clear();
            Logs.Close();
        }

        internal void LoadAdjusterDefs()
        {
            foreach (var mod in MyAPIGateway.Session.Mods)
            {
                if (!MyAPIGateway.Utilities.FileExistsInModLocation(PATH, mod))
                    continue;

                using (var reader = MyAPIGateway.Utilities.ReadFileInModLocation(PATH, mod))
                {
                    while (reader.Peek() != -1)
                    {
                        ImportFile(reader.ReadLine(), mod);
                    }
                }
            }
        }

        private void ImportFile(string name, MyObjectBuilder_Checkpoint.ModItem mod)
        {
            if (name.Length <= 0) return;

            var path = "Data\\ModAdjuster\\" + name;
            if (!MyAPIGateway.Utilities.FileExistsInModLocation(path, mod))
                return;

            Definitions.Definitions definitions = null;
            using (var reader = MyAPIGateway.Utilities.ReadFileInModLocation(path, mod))
            {
                StringBuilder builder = new StringBuilder();
                while (reader.Peek() != -1)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("xsi:type="))
                        line = line.Replace("MyObjectBuilder_", "");

                    builder.AppendLine(line);

                }

                var data = builder.ToString();
                try
                {
                    definitions = MyAPIGateway.Utilities.SerializeFromXML<Definitions.Definitions>(data);

                }
                catch (Exception ex)
                {
                    Logs.LogException(ex);
                }
            }

            if (definitions == null) return;

            var modPath = mod.GetPath();
            ImportDefinitions(definitions.GenericDefinitions, MyDefinitionManager.Static.GetDefinition, modPath);
            ImportDefinitions(definitions.PlanetGeneratorDefinitions, MyDefinitionManager.Static.GetDefinition, modPath);
            ImportDefinitions(definitions.Blueprints, MyDefinitionManager.Static.GetBlueprintDefinition, modPath);
            ImportDefinitions(definitions.BlueprintClasses, (id) => MyDefinitionManager.Static.GetBlueprintClass(id.SubtypeName), modPath);
            ImportDefinitions(definitions.PhysicalItems, MyDefinitionManager.Static.GetPhysicalItemDefinition, modPath);
            ImportDefinitions(definitions.AmmoMagazines, MyDefinitionManager.Static.GetAmmoMagazineDefinition, modPath);
            ImportDefinitions(definitions.Components, MyDefinitionManager.Static.GetComponentDefinition, modPath);
            ImportDefinitions(definitions.CubeBlocks, MyDefinitionManager.Static.GetCubeBlockDefinition, modPath);
            ImportDefinitions(definitions.BlockVariantGroups, (id) => { MyBlockVariantGroup def = null; MyDefinitionManager.Static.GetBlockVariantGroupDefinitions().TryGetValue(id.SubtypeName, out def); return def; }, modPath);
            ImportDefinitions(definitions.Characters, (id) => { MyCharacterDefinition def = null; MyDefinitionManager.Static.Characters.TryGetValue(id.SubtypeName, out def); return def; }, modPath);
            ImportDefinitions(definitions.ContainerTypes, MyDefinitionManager.Static.GetContainerTypeDefinition, modPath);
            ImportDefinitions(definitions.DropContainers, (id) => MyDefinitionManager.Static.GetDropContainerDefinition(id.SubtypeName), modPath);
            ImportDefinitions(definitions.HandItems, (id) => MyDefinitionManager.Static.TryGetHandItemDefinition(ref id), modPath);
            ImportDefinitions(definitions.Prefabs, (id) => MyDefinitionManager.Static.GetPrefabDefinition(id.SubtypeName), modPath);
            ImportDefinitions(definitions.RespawnShips, (id) => MyDefinitionManager.Static.GetRespawnShipDefinition(id.SubtypeName), modPath);
            ImportDefinitions(definitions.Ammos, MyDefinitionManager.Static.GetAmmoDefinition, modPath);
            ImportDefinitions(definitions.Weapons, MyDefinitionManager.Static.GetWeaponDefinition, modPath);
            ImportDefinitions(definitions.VoxelMaterials, (id) => MyDefinitionManager.Static.GetVoxelMaterialDefinition(id.SubtypeName), modPath);
            
            ImportCategoryClasses(definitions.CategoryClasses, modPath);
            ImportClassEntries(definitions.BlueprintClassEntries);
        }


        private void ImportDefinitions(Definition[] definitions, Func<MyDefinitionId, MyDefinitionBase> getter, string path = null)
        {
            if (definitions == null || definitions.Length == 0) return;

            for (int i = 0; i < definitions.Length; i++)
            {
                var definition = definitions[i];
                var def = getter.Invoke(definition.Id);
                if (def != null)
                {
                    Logs.WriteLine($"Loaded definition for {definition.Id} as {def.GetType()}");
                    definition.Load(def, path);
                    continue;
                }

                Logs.WriteLine($"Failed to find definition for {definition.Id}");
            }
        }

        private void ImportCategoryClasses(GuiBlockCategoryDefinition[] classes, string path = null)
        {
            if (classes == null || classes.Length == 0) return;

            var categories = MyDefinitionManager.Static.GetCategories();
            for (int i = 0; i < classes.Length; i++)
            {
                var cClass = classes[i];

                MyGuiBlockCategoryDefinition category;
                if (!categories.TryGetValue(cClass.Name, out category))
                {
                    Logs.WriteLine($"Failed to find definition for Block Category {cClass.Name}");
                    continue;
                }

                cClass.Load(category, path);
                Logs.WriteLine($"Loaded definition for Block Category {category.Name}");
            }

        }

        private void ImportClassEntries(BlueprintClassEntry[] entries)
        {
            if (entries == null || entries.Length == 0) return;

            for (int i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];

                var bpClass = MyDefinitionManager.Static.GetBlueprintClass(entry.Class);
                if (bpClass == null)
                {
                    Logs.WriteLine($"Unable to find blueprint class: {entry.Class}");
                    continue;
                }

                if (_clearedClasses.Add(entry.Class))
                    bpClass.ClearBlueprints();

                MyDefinitionId id;
                if (entry.TypeId.IsNull)
                {
                    id = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), entry.BlueprintSubtypeId);
                }
                else if (!MyDefinitionId.TryParse(entry.BlueprintSubtypeId, out id))
                {
                    Logs.WriteLine($"Unable to find blueprint: {entry.BlueprintSubtypeId} - not a valid type!");
                    continue;
                }

                var bp = MyDefinitionManager.Static.GetBlueprintDefinition(id);
                if (bp == null)
                {
                    if (entry.TypeId.IsNull)
                    {
                        id = new MyDefinitionId(typeof(MyObjectBuilder_CompositeBlueprintDefinition), entry.BlueprintSubtypeId);
                        bp = MyDefinitionManager.Static.GetBlueprintDefinition(id);
                    }
                    if (bp == null)
                    {
                        Logs.WriteLine($"Unable to find blueprint: {entry.BlueprintSubtypeId} - not a valid subtype!");
                        continue;
                    }
                }

                bpClass.AddBlueprint(bp);
                Logs.WriteLine($"Added blueprint {id} to class {bpClass.Id}");
            }
        }

    }
}
