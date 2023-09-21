using ModAdjusterV2.Definitions.Blocks;
using ModAdjusterV2.Session;
using Sandbox.Definitions;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;

namespace ModAdjusterV2.Definitions
{
	public class Definitions
	{
		[XmlElement("Definition")]
		public Definition[] GenericDefinitions;
		[XmlArrayItem("PlanetGeneratorDefinition")]
		public PlanetGeneratorDefinition[] PlanetGeneratorDefinitions;
		[XmlArrayItem("Definition")]
		public CubeBlockDefinition[] CubeBlocks;
		[XmlArrayItem("Ammo")]
		public AmmoDefinition[] Ammos;
		[XmlArrayItem("BlockVariantGroup")]
		public BlockVariantGroup[] BlockVariantGroups;
		[XmlArrayItem("Category")]
		public GuiBlockCategoryDefinition[] CategoryClasses;

		[XmlArrayItem("Blueprint")]
		public BlueprintDefinition[] Blueprints;
		[XmlArrayItem("Class")]
		public BlueprintClassDefinition[] BlueprintClasses;
		[XmlArrayItem("Entry")]
		public BlueprintClassEntry[] BlueprintClassEntries;

        [XmlArrayItem("Character")]
        public CharacterDefinition[] Characters;
        [XmlArrayItem("PhysicalItem")]
        public PhysicalItemDefinition[] PhysicalItems;
        [XmlArrayItem("AmmoMagazine")]
        public AmmoMagazineDefinition[] AmmoMagazines;
        [XmlArrayItem("Component")]
        public ComponentDefinition[] Components;
		[XmlArrayItem("ContainerType")]
		public ContainerTypeDefinition[] ContainerTypes;
		[XmlArrayItem("DropContainer")]
		public DropContainerDefinition[] DropContainers;
        [XmlArrayItem("HandItem")]
        public HandItemDefinition[] HandItems;
        [XmlArrayItem("Prefab")]
        public PrefabDefinition[] Prefabs;
        [XmlArrayItem("Ship")]
        public RespawnShipDefinition[] RespawnShips;
		[XmlArrayItem("Weapon")]
		public WeaponDefinition[] Weapons;
		[XmlArrayItem("SpawnGroup")]
		public SpawnGroupDefinition[] SpawnGroups;
		[XmlArrayItem("VoxelMaterial")]
		public VoxelMaterialDefinition[] VoxelMaterials;
	}

	[XmlInclude(typeof(PhysicalModelDefinition))]
	[XmlInclude(typeof(AmmoDefinition))]
	[XmlInclude(typeof(BlockVariantGroup))]
	[XmlInclude(typeof(BlueprintDefinition))]
	[XmlInclude(typeof(BlueprintClassDefinition))]
	[XmlInclude(typeof(CharacterDefinition))]
	[XmlInclude(typeof(GuiBlockCategoryDefinition))]
	[XmlInclude(typeof(PhysicalItemDefinition))]
	[XmlInclude(typeof(ContainerTypeDefinition))]
	[XmlInclude(typeof(DropContainerDefinition))]
    [XmlInclude(typeof(PlanetGeneratorDefinition))]
    [XmlInclude(typeof(HandItemDefinition))]
    [XmlInclude(typeof(PrefabDefinition))]
    [XmlInclude(typeof(RespawnShipDefinition))]
	[XmlInclude(typeof(WeaponDefinition))]
	[XmlInclude(typeof(SpawnGroupDefinition))]
	[XmlInclude(typeof(VoxelMaterialDefinition))]
	public class Definition
	{
		public SerializableDefinitionId Id;

		public string DisplayName;

		public string Description;

		[XmlElement("Icon")]
		public string[] Icons;

		public bool? Public;

		public bool? Enabled;

		public bool? AvailableInSurvival;

		public string DescriptionArgs;

		//readonly
		////[XmlElement("DLC")]
		//public string[] DLCs;

		public virtual void Load(MyDefinitionBase definitionBase, string path = null)
        {
			var def = definitionBase;

			if (!string.IsNullOrEmpty(DisplayName))
			{
				def.DisplayNameString = DisplayName;
				def.DisplayNameEnum = IsTextEnumKey(DisplayName, "DisplayName_") ? new MyStringId?(MyStringId.GetOrCompute(DisplayName)) : null;
			}

			if (!string.IsNullOrEmpty(Description))
            {
				def.DescriptionString = Description;
				def.DescriptionEnum = IsTextEnumKey(Description, "Description_") ? new MyStringId?(MyStringId.GetOrCompute(Description)) : null;
			}

			if (Icons != null && Icons.Length > 0)
            {
				def.Icons = new string[Icons.Length];
				for (int i = 0; i < Icons.Length; i++)
					def.Icons[i] = path + "\\" +  Icons[i];
            }

			def.Public = Public ?? def.Public;
			def.Enabled = Enabled ?? def.Enabled;
			def.AvailableInSurvival = AvailableInSurvival ?? def.AvailableInSurvival;
			def.DescriptionArgs = DescriptionArgs ?? def.DescriptionArgs;
        }

		public bool IsTextEnumKey(string s, string pattern)
        {
			return (s.StartsWith(pattern) || (s.Contains(pattern) && MyTexts.MatchesReplaceFormat(s)));
		}

	}

	[XmlInclude(typeof(CubeBlockDefinition))]
	[XmlInclude(typeof(EnvironmentItemDefinition))]
	public class PhysicalModelDefinition : Definition
	{
		public string Model;

        public string PhysicalMaterial;

        public float? Mass;

		public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
			base.Load(definitionBase, path);

			var def = definitionBase as MyPhysicalModelDefinition;

			if (!string.IsNullOrEmpty(Model)) def.Model = path + "\\" + Model;

			def.Mass = Mass ?? def.Mass;

			if (!string.IsNullOrEmpty(PhysicalMaterial)) def.PhysicalMaterial = MyDefinitionManager.Static.GetPhysicalMaterialDefinition(PhysicalMaterial);
		}

	}

}
