using ModAdjusterV2.Session;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game;

namespace ModAdjusterV2.Definitions
{
    public class SpawnGroupDefinition : Definition
    {
		public float? Frequency;

		[XmlArrayItem("Prefab")]
		public MyObjectBuilder_SpawnGroupDefinition.SpawnGroupPrefab[] Prefabs;

		[XmlArrayItem("Voxel")]
		public MyObjectBuilder_SpawnGroupDefinition.SpawnGroupVoxel[] Voxels;

		public bool? IsEncounter;

		public bool? IsPirate;

		public bool? IsCargoShip;

		public bool? ReactorsOn;

		public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySpawnGroupDefinition;

			if (Frequency.HasValue) def.Frequency = Frequency.Value;
			if (def.Frequency == 0f)
			{
				Logs.WriteLine($"Spawn group initialization: spawn group has zero frequency: {def.Id.SubtypeName}");
				return;
			}

			if (Prefabs != null)
            {
				def.Prefabs.Clear();
				foreach (var spawnGroupPrefab in Prefabs)
				{
					var spawnGroupPrefab2 = default(MySpawnGroupDefinition.SpawnGroupPrefab);
					spawnGroupPrefab2.Position = spawnGroupPrefab.Position;
					spawnGroupPrefab2.SubtypeId = spawnGroupPrefab.SubtypeId;
					spawnGroupPrefab2.BeaconText = spawnGroupPrefab.BeaconText;
					spawnGroupPrefab2.Speed = spawnGroupPrefab.Speed;
					spawnGroupPrefab2.ResetOwnership = spawnGroupPrefab.ResetOwnership;
					spawnGroupPrefab2.PlaceToGridOrigin = spawnGroupPrefab.PlaceToGridOrigin;
					spawnGroupPrefab2.Behaviour = spawnGroupPrefab.Behaviour;
					spawnGroupPrefab2.BehaviourActivationDistance = spawnGroupPrefab.BehaviourActivationDistance;
					if (MyDefinitionManager.Static.GetPrefabDefinition(spawnGroupPrefab2.SubtypeId) == null)
					{
						Logs.WriteLine("Spawn group initialization: Could not get prefab " + spawnGroupPrefab2.SubtypeId);
						continue;
					}
					def.Prefabs.Add(spawnGroupPrefab2);
				}

				def.ReloadPrefabs();
			}

			if (Voxels != null)
			{
				def.Voxels.Clear();
				foreach (var spawnGroupVoxel in Voxels)
				{
					var item = default(MySpawnGroupDefinition.SpawnGroupVoxel);
					item.Offset = spawnGroupVoxel.Offset;
					item.StorageName = spawnGroupVoxel.StorageName;
					item.CenterOffset = spawnGroupVoxel.CenterOffset;
					def.Voxels.Add(item);
				}
			}

			if (IsEncounter.HasValue) def.IsEncounter = IsEncounter.Value;
			if (IsCargoShip.HasValue) def.IsCargoShip = IsCargoShip.Value;
			if (IsPirate.HasValue) def.IsPirate = IsPirate.Value;
			if (ReactorsOn.HasValue) def.ReactorsOn = ReactorsOn.Value;
		}
    }

}
