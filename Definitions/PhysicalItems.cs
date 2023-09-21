using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.Game.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions
{
	[XmlInclude(typeof(AmmoMagazineDefinition))]
	[XmlInclude(typeof(ComponentDefinition))]
	[XmlInclude(typeof(DatapadDefinition))]
	[XmlInclude(typeof(OxygenContainerDefinition))]
	[XmlInclude(typeof(PackageDefinition))]
	[XmlInclude(typeof(ToolItemDefinition))]
	[XmlInclude(typeof(UsableItemDefinition))]
	[XmlInclude(typeof(WeaponItemDefinition))]
	public class PhysicalItemDefinition : Definition
    {
		public Vector3? Size;

		public float? Mass;

		public string Model;

		[XmlArrayItem("Model")]
		public string[] Models;

		public string IconSymbol;

		public float? Volume;

		public float? ModelVolume;

		public string PhysicalMaterial;

		public string VoxelMaterial;

		public bool? CanSpawnFromScreen;

		public bool? RotateOnSpawnX;

		public bool? RotateOnSpawnY;

		public bool? RotateOnSpawnZ;

		public int? Health;

		public SerializableDefinitionId? DestroyedPieceId;

		public int? DestroyedPieces;

		public string ExtraInventoryTooltipLine;

		public string ExtraInventoryTooltipLineId;

		public MyFixedPoint? MaxStackAmount;

		public int? MinimalPricePerUnit;

		public int? MinimumOfferAmount;

		public int? MaximumOfferAmount;

		public int? MinimumOrderAmount;

		public int? MaximumOrderAmount;

		public bool? CanPlayerOrder;

		public int? MinimumAcquisitionAmount;

		public int? MaximumAcquisitionAmount;

		public string DestroySound;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyPhysicalItemDefinition;

			if (Size.HasValue)
			{
				def.Size = Size.Value;
				def.Volume = Size.Value.Volume;
			}
			if (Mass.HasValue) def.Mass = Mass.Value;
			if (!string.IsNullOrEmpty(Model)) def.Model = Model;
			if (Models != null) def.Models = Models;
			if (!string.IsNullOrEmpty(IconSymbol)) def.IconSymbol = MyStringId.GetOrCompute(IconSymbol);
			if (Volume.HasValue)
			{
				def.Volume = Volume.Value / 1000f;
				def.ModelVolume = def.Volume;
			}
			if (ModelVolume.HasValue) def.ModelVolume = ModelVolume.Value / 1000f;
			if (!string.IsNullOrEmpty(PhysicalMaterial)) def.PhysicalMaterial = MyStringHash.GetOrCompute(PhysicalMaterial);
			if (!string.IsNullOrEmpty(VoxelMaterial)) def.VoxelMaterial = MyStringHash.GetOrCompute(VoxelMaterial);
			if (CanSpawnFromScreen.HasValue) def.CanSpawnFromScreen = CanSpawnFromScreen.Value;
			if (RotateOnSpawnX.HasValue) def.RotateOnSpawnX = RotateOnSpawnX.Value;
			if (RotateOnSpawnY.HasValue) def.RotateOnSpawnY = RotateOnSpawnY.Value;
			if (RotateOnSpawnZ.HasValue) def.RotateOnSpawnZ = RotateOnSpawnZ.Value;
			if (Health.HasValue) def.Health = Health.Value;
			if (DestroyedPieceId.HasValue) def.DestroyedPieceId = DestroyedPieceId.Value;
			if (DestroyedPieces.HasValue) def.DestroyedPieces = DestroyedPieces.Value;
			if (!string.IsNullOrEmpty(ExtraInventoryTooltipLine)) def.ExtraInventoryTooltipLine = new StringBuilder().Append(Environment.NewLine).Append(ExtraInventoryTooltipLine);
			if (!string.IsNullOrEmpty(ExtraInventoryTooltipLineId)) def.ExtraInventoryTooltipLine = new StringBuilder().Append(Environment.NewLine).Append(MyTexts.Get(MyStringId.GetOrCompute(ExtraInventoryTooltipLineId)));
			if (MaxStackAmount.HasValue) def.MaxStackAmount = MaxStackAmount.Value;
			if (MinimalPricePerUnit.HasValue) def.MinimalPricePerUnit = MinimalPricePerUnit.Value;
			if (MinimumOfferAmount.HasValue) def.MinimumOfferAmount = MinimumOfferAmount.Value;
			if (MaximumOfferAmount.HasValue) def.MaximumOfferAmount = MaximumOfferAmount.Value;
			if (MinimumOrderAmount.HasValue) def.MinimumOrderAmount = MinimumOrderAmount.Value;
			if (MaximumOrderAmount.HasValue) def.MaximumOrderAmount = MaximumOrderAmount.Value;
			if (CanPlayerOrder.HasValue) def.CanPlayerOrder = CanPlayerOrder.Value;
			if (MinimumAcquisitionAmount.HasValue) def.MinimumAcquisitionAmount = MinimumAcquisitionAmount.Value;
			if (MaximumAcquisitionAmount.HasValue) def.MaximumAcquisitionAmount = MaximumAcquisitionAmount.Value;
			if (!string.IsNullOrEmpty(DestroySound)) def.DestroySound = new MySoundPair(DestroySound, true);
		}
    }

	public class AmmoMagazineDefinition : PhysicalItemDefinition
    {
		public int? Capacity;

        //public MyAmmoCategoryEnum? Category;

        public AmmoDefinitionA AmmoDefinitionId;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyAmmoMagazineDefinition;

			if (Capacity.HasValue) def.Capacity = Capacity.Value;
			//if (Category.HasValue) def.Category = Category.Value;
			if (AmmoDefinitionId != null && !string.IsNullOrEmpty(AmmoDefinitionId.Subtype)) def.AmmoDefinitionId = new MyDefinitionId(typeof(MyObjectBuilder_AmmoDefinition), AmmoDefinitionId.Subtype);
		}

		public class AmmoDefinitionA
        {
			[XmlAttribute]
			public string Subtype;
		}

	}

	public class ComponentDefinition : PhysicalItemDefinition
    {
		public int? MaxIntegrity;

		public float? DropProbability;

		public float? DeconstructionEfficiency;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyComponentDefinition;

			if (MaxIntegrity.HasValue) def.MaxIntegrity = MaxIntegrity.Value;
			if (DropProbability.HasValue) def.DropProbability = DropProbability.Value;
			if (DeconstructionEfficiency.HasValue) def.DeconstructionEfficiency = DeconstructionEfficiency.Value;
        }
    }

	public class DatapadDefinition : PhysicalItemDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

	public class OxygenContainerDefinition : PhysicalItemDefinition
    {
		public float? Capacity;

		public SerializableDefinitionId? StoredGasId;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyOxygenContainerDefinition;

			if (Capacity.HasValue) def.Capacity = Capacity.Value;
			if (StoredGasId.HasValue) def.StoredGasId = StoredGasId.Value;
        }
    }

	public class PackageDefinition : PhysicalItemDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

	public class ToolItemDefinition : PhysicalItemDefinition
    {
		[XmlArrayItem("Mining")]
		public MyObjectBuilder_ToolItemDefinition.MyVoxelMiningDefinition[] VoxelMinings;

		[XmlArrayItem("Action")]
		public MyObjectBuilder_ToolItemDefinition.MyToolActionDefinition[] PrimaryActions;

		[XmlArrayItem("Action")]
		public MyObjectBuilder_ToolItemDefinition.MyToolActionDefinition[] SecondaryActions;

		public float? HitDistance;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyToolItemDefinition;

			if (VoxelMinings != null && VoxelMinings.Length > 0)
            {
				def.VoxelMinings = new MyVoxelMiningDefinition[VoxelMinings.Length];
				for (int i = 0; i < VoxelMinings.Length; i++)
				{
					def.VoxelMinings[i].MinedOre = VoxelMinings[i].MinedOre;
					def.VoxelMinings[i].HitCount = VoxelMinings[i].HitCount;
					def.VoxelMinings[i].PhysicalItemId = VoxelMinings[i].PhysicalItemId;
					def.VoxelMinings[i].RemovedRadius = VoxelMinings[i].RemovedRadius;
					def.VoxelMinings[i].OnlyApplyMaterial = VoxelMinings[i].OnlyApplyMaterial;
				}
			}

			if (PrimaryActions != null && PrimaryActions.Length > 0) CopyActions(PrimaryActions, def.PrimaryActions);
			if (SecondaryActions != null && SecondaryActions.Length > 0) CopyActions(SecondaryActions, def.SecondaryActions);

			if (HitDistance.HasValue) def.HitDistance = HitDistance.Value;
		}

		private void CopyActions(MyObjectBuilder_ToolItemDefinition.MyToolActionDefinition[] sourceActions, List<MyToolActionDefinition> targetList)
		{
			if (sourceActions != null && sourceActions.Length != 0)
			{
				for (int i = 0; i < sourceActions.Length; i++)
				{
					MyToolActionDefinition myToolActionDefinition = default(MyToolActionDefinition);
					myToolActionDefinition.Name = MyStringId.GetOrCompute(sourceActions[i].Name);
					myToolActionDefinition.StartTime = sourceActions[i].StartTime;
					myToolActionDefinition.EndTime = sourceActions[i].EndTime;
					myToolActionDefinition.Efficiency = sourceActions[i].Efficiency;
					myToolActionDefinition.StatsEfficiency = sourceActions[i].StatsEfficiency;
					myToolActionDefinition.SwingSound = sourceActions[i].SwingSound;
					myToolActionDefinition.SwingSoundStart = sourceActions[i].SwingSoundStart;
					myToolActionDefinition.HitStart = sourceActions[i].HitStart;
					myToolActionDefinition.HitDuration = sourceActions[i].HitDuration;
					myToolActionDefinition.HitSound = sourceActions[i].HitSound;
					myToolActionDefinition.CustomShapeRadius = sourceActions[i].CustomShapeRadius;
					myToolActionDefinition.Crosshair = sourceActions[i].Crosshair;
					if (sourceActions[i].HitConditions != null)
					{
						myToolActionDefinition.HitConditions = new MyToolHitCondition[sourceActions[i].HitConditions.Length];
						for (int j = 0; j < myToolActionDefinition.HitConditions.Length; j++)
						{
							myToolActionDefinition.HitConditions[j].EntityType = sourceActions[i].HitConditions[j].EntityType;
							myToolActionDefinition.HitConditions[j].Animation = sourceActions[i].HitConditions[j].Animation;
							myToolActionDefinition.HitConditions[j].AnimationTimeScale = sourceActions[i].HitConditions[j].AnimationTimeScale;
							myToolActionDefinition.HitConditions[j].StatsAction = sourceActions[i].HitConditions[j].StatsAction;
							myToolActionDefinition.HitConditions[j].StatsActionIfHit = sourceActions[i].HitConditions[j].StatsActionIfHit;
							myToolActionDefinition.HitConditions[j].StatsModifier = sourceActions[i].HitConditions[j].StatsModifier;
							myToolActionDefinition.HitConditions[j].StatsModifierIfHit = sourceActions[i].HitConditions[j].StatsModifierIfHit;
							myToolActionDefinition.HitConditions[j].Component = sourceActions[i].HitConditions[j].Component;
						}
					}
					targetList.Add(myToolActionDefinition);
				}
			}
		}
	}

	[XmlInclude(typeof(ConsumableItemDefinition))]
	[XmlInclude(typeof(SchematicItemDefinition))]
	public class UsableItemDefinition : PhysicalItemDefinition
    {
		public string UseSound;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyUsableItemDefinition;

			if (!string.IsNullOrEmpty(UseSound)) def.UseSound = UseSound;
        }
    }

	public class ConsumableItemDefinition : UsableItemDefinition
    {
		[XmlArrayItem("Stat")]
		public MyObjectBuilder_ConsumableItemDefinition.StatValue[] Stats;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyConsumableItemDefinition;

			if (Stats != null && Stats.Length > 0)
            {
				def.Stats.Clear();
				foreach (var statValue in Stats)
				{
					def.Stats.Add(new MyConsumableItemDefinition.StatValue(statValue.Name, statValue.Value, statValue.Time));
				}
			}
        }
    }

	public class SchematicItemDefinition : UsableItemDefinition
    {
		public SerializableDefinitionId? Research;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MySchematicItemDefinition;

			if (Research.HasValue) def.Research = Research.Value;
        }
    }

	public class WeaponItemDefinition : PhysicalItemDefinition
    {
		public MyObjectBuilder_WeaponItemDefinition.PhysicalItemWeaponDefinitionId WeaponDefinitionId;
		
		public bool? ShowAmmoCount;

		public string MuzzleProjectileDummyName;

		public string MuzzleMissileDummyName;

		public string HoldingDummyName;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyWeaponItemDefinition;

			if (WeaponDefinitionId != null) def.WeaponDefinitionId = new MyDefinitionId(WeaponDefinitionId.Type, WeaponDefinitionId.Subtype);
			if (ShowAmmoCount.HasValue) def.ShowAmmoCount = ShowAmmoCount.Value;
			if (!string.IsNullOrEmpty(MuzzleProjectileDummyName)) def.DummyNames[MyGunBase.DUMMY_KEY_PROJECTILE] = MuzzleProjectileDummyName;
			if (!string.IsNullOrEmpty(MuzzleMissileDummyName)) def.DummyNames[MyGunBase.DUMMY_KEY_MISSILE] = MuzzleMissileDummyName;
			if (!string.IsNullOrEmpty(HoldingDummyName)) def.DummyNames[MyGunBase.DUMMY_KEY_HOLDING] = HoldingDummyName;
		}
    }
}
