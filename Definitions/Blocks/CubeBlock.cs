using Sandbox.Definitions;
using Sandbox.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.ObjectBuilders;
using VRageMath;
using ModAdjusterV2.Session;
using VRage.Game.ObjectBuilders.ComponentSystem;
using VRage.Utils;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;

namespace ModAdjusterV2.Definitions.Blocks
{
	[XmlInclude(typeof(FunctionalBlockDefinition))]
	[XmlInclude(typeof(WarheadDefinition))]
	public class CubeBlockDefinition : PhysicalModelDefinition
	{
		public VoxelPlacementOverride? VoxelPlacement;

		public bool? SilenceableByShipSoundSystem;

		public MyCubeSize? CubeSize;

		public MyBlockTopology? BlockTopology;

		public SerializableVector3I? Size;

		public SerializableVector3? ModelOffset;

		public MyObjectBuilder_CubeBlockDefinition.PatternDefinition CubeDefinition;

		//
		public float? DeformationRatio;

		[XmlArrayItem("Component")]
		public MyObjectBuilder_CubeBlockDefinition.CubeBlockComponent[] Components;

		public MyObjectBuilder_CubeBlockDefinition.CriticalPart CriticalComponent;

		public float? BuildTimeSeconds;

		public float? DisassembleRatio;

		public int? MaxIntegrity;
		//

		[XmlArrayItem("Effect")]
		public MyObjectBuilder_CubeBlockDefinition.CubeBlockEffectBase[] Effects;

		public MyObjectBuilder_CubeBlockDefinition.MountPoint[] MountPoints;

		public MyObjectBuilder_CubeBlockDefinition.Variant[] Variants;

		[XmlArrayItem("Component")]
		public MyObjectBuilder_CubeBlockDefinition.EntityComponentDefinition[] EntityComponents;

		public MyPhysicsOption? PhysicsOption;

		[XmlArrayItem("Model")]
		public List<MyObjectBuilder_CubeBlockDefinition.BuildProgressModel> BuildProgressModels;

		public string BlockPairName;

		public SerializableVector3I? Center;

		[DefaultValue(MySymmetryAxisEnum.None)]
		public MySymmetryAxisEnum MirroringX;

		[DefaultValue(MySymmetryAxisEnum.None)]
		public MySymmetryAxisEnum MirroringY;

		[DefaultValue(MySymmetryAxisEnum.None)]
		public MySymmetryAxisEnum MirroringZ;

		public string EdgeType;

		public MyAutorotateMode? AutorotateMode;

		public string MirroringBlock;

		public bool? UseModelIntersection;

		public string PrimarySound;

		public string ActionSound;

		public string BuildType;

		public string BuildMaterial;

		[XmlArrayItem("Template")]
		public string[] CompoundTemplates;

		public bool? CompoundEnabled;

		[XmlArrayItem("Definition")]
		public MyObjectBuilder_CubeBlockDefinition.MySubBlockDefinition[] SubBlockDefinitions;

		public string MultiBlock;

		public string NavigationDefinition;

		public bool? GuiVisible;

		[XmlArrayItem("BlockVariant")]
		public SerializableDefinitionId[] BlockVariants;

		public MyBlockDirection? Direction;

		public MyBlockRotation? Rotation;

		[XmlArrayItem("GeneratedBlock")]
		public SerializableDefinitionId[] GeneratedBlocks;

		public string GeneratedBlockType;

		public bool? Mirrored;

		public int? DamageEffectId;

		public string DestroyEffect;

		public string DestroySound;

		public List<BoneInfo> Skeleton;

		public bool? RandomRotation;

		public bool? IsAirTight;

		public bool? IsStandAlone;

		public bool? HasPhysics;

		//public bool UseNeighbourOxygenRooms;

		[Obsolete]
		public int? Points;

		public float? BuildProgressToPlaceGeneratedBlocks;

		public string DamagedSound;

		public bool? CreateFracturedPieces;

		public string EmissiveColorPreset;

		public float? GeneralDamageMultiplier;

		public string DamageEffectName;

		public bool? UsesDeformation;

		public Vector3? DestroyEffectOffset;

		public int? PCU;

		public int? PCUConsole;

		public bool? PlaceDecals;

		public SerializableVector3? DepressurizationEffectOffset;

		public uint[] TieredUpdateTimes;

		[XmlArray(IsNullable = true)]
		[XmlArrayItem("string")]
		public string[] TargetingGroups;

		public float? PriorityModifier;

		public float? NotWorkingPriorityMultiplier;

		public float? DamageMultiplierExplosion;

		public float? DamageThreshold;

		public float? DetonateChance;

		public string AmmoExplosionEffect;

		public string AmmoExplosionSound;

		public Vector3? DamageEffectOffset;

		public Vector3? AimingOffset;

		public SerializableVector3I? MirroringCenter;

		public float? DestroyEffectScale;

		public bool? EnableUseObjectSimpleTargeting;

		public SerializableVector3? MechanicalTopInitialPlacementOffset;

		public bool? UseNeighbourOxygenRooms;

		public bool? AllowInteractionThroughBlock;


        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
			base.Load(definitionBase, path);

			var def = definitionBase as MyCubeBlockDefinition;
			var ob = (MyObjectBuilder_CubeBlockDefinition)def.GetObjectBuilder();

			def.Size = Size ?? def.Size;
			def.UseModelIntersection = UseModelIntersection ?? def.UseModelIntersection;
			def.CubeSize = CubeSize ?? def.CubeSize;
			def.ModelOffset = ModelOffset ?? def.ModelOffset;
			def.BlockTopology = BlockTopology ?? def.BlockTopology;
			def.PhysicsOption = PhysicsOption ?? def.PhysicsOption;
			if (!string.IsNullOrEmpty(BlockPairName)) def.BlockPairName = BlockPairName;

			//def.m_center = (Center ?? ((def.Size - 1) / 2));
			//def.m_mirroringCenter = (MirroringCenter ?? def.m_center);
			//def.m_symmetryX = MirroringX;
			//def.m_symmetryY = MirroringY;
			//def.m_symmetryZ = MirroringZ;
			//def.m_mirroringBlock = MirroringBlock;

			if (UsesDeformation.HasValue) def.UsesDeformation = UsesDeformation.Value;
			if (DeformationRatio.HasValue) def.DeformationRatio = DeformationRatio.Value;
			if (SilenceableByShipSoundSystem.HasValue) def.SilenceableByShipSoundSystem = SilenceableByShipSoundSystem.Value;
			if (EdgeType != null) def.EdgeType = EdgeType;
			if (AutorotateMode.HasValue) def.AutorotateMode = AutorotateMode.Value;
			if (!string.IsNullOrEmpty(MultiBlock)) def.MultiBlock = MultiBlock;
			if (GuiVisible.HasValue) def.GuiVisible = GuiVisible.Value;

			//def.Rotation = Rotation;
			//def.Direction = Direction;
			//def.Mirrored = Mirrored;
			//def.RandomRotation = RandomRotation;

			if (!string.IsNullOrEmpty(BuildType)) def.BuildType = MyStringId.GetOrCompute(BuildType.ToLower());
			if (!string.IsNullOrEmpty(BuildMaterial)) def.BuildMaterial = BuildMaterial.ToLower();
			if (BuildProgressToPlaceGeneratedBlocks.HasValue) def.BuildProgressToPlaceGeneratedBlocks = BuildProgressToPlaceGeneratedBlocks.Value;
			if (!string.IsNullOrEmpty(GeneratedBlockType)) def.GeneratedBlockType = MyStringId.GetOrCompute(GeneratedBlockType.ToLower());
			if (CompoundEnabled.HasValue) def.CompoundEnabled = CompoundEnabled.Value;
			if (CreateFracturedPieces.HasValue) def.CreateFracturedPieces = CreateFracturedPieces.Value;
			if (!string.IsNullOrEmpty(EmissiveColorPreset)) def.EmissiveColorPreset = MyStringHash.GetOrCompute(EmissiveColorPreset);
			if (VoxelPlacement.HasValue )def.VoxelPlacement = VoxelPlacement;
			if (GeneralDamageMultiplier.HasValue) def.GeneralDamageMultiplier = GeneralDamageMultiplier.Value;

			//def.PriorityModifier = PriorityModifier;
			//def.NotWorkingPriorityMultiplier = NotWorkingPriorityMultiplier;

			if (DamageMultiplierExplosion.HasValue) def.DamageMultiplierExplosion = DamageMultiplierExplosion.Value;
			if (DestroyEffectScale.HasValue) def.DestroyEffectScale = DestroyEffectScale.Value;
			if (EnableUseObjectSimpleTargeting.HasValue )def.EnableUseObjectSimpleTargeting = EnableUseObjectSimpleTargeting.Value;
			if (MechanicalTopInitialPlacementOffset.HasValue) def.MechanicalTopInitialPlacementOffset = new Vector3?(MechanicalTopInitialPlacementOffset.GetValueOrDefault());

			if (TargetingGroups != null)
			{
				if (def.TargetingGroups != null)
				{
					def.TargetingGroups.Clear();
					foreach (string str in TargetingGroups)
					{
						var hash = MyStringHash.GetOrCompute(str);
						def.TargetingGroups.Add(hash);
					}
				}
				else
					Logs.WriteLine($"Targeting groups for {def.Id.SubtypeName} cannot be edited!");
			}

			if (Effects != null)
			{
				def.Effects = new CubeBlockEffectBase[Effects.Length];
				for (int j = 0; j < Effects.Length; j++)
				{
					def.Effects[j] = new CubeBlockEffectBase(Effects[j].Name, Effects[j].ParameterMin, Effects[j].ParameterMax);
					if (Effects[j].ParticleEffects != null && Effects[j].ParticleEffects.Length != 0)
					{
						def.Effects[j].ParticleEffects = new CubeBlockEffect[Effects[j].ParticleEffects.Length];
						for (int k = 0; k < Effects[j].ParticleEffects.Length; k++)
						{
							def.Effects[j].ParticleEffects[k] = new CubeBlockEffect(Effects[j].ParticleEffects[k]);
						}
					}
					else
					{
						def.Effects[j].ParticleEffects = null;
					}
				}
			}

			if (DamageEffectId.HasValue) def.DamageEffectID = DamageEffectId;
			if (!string.IsNullOrEmpty(DamageEffectName)) def.DamageEffectName = DamageEffectName;
			if (DamageEffectOffset.HasValue) def.DamageEffectOffset = DamageEffectOffset;
			if (AimingOffset.HasValue) def.AimingOffset = AimingOffset;
			if (!string.IsNullOrEmpty(DestroyEffect)) def.DestroyEffect = DestroyEffect;
			if (DestroyEffectOffset.HasValue) def.DestroyEffectOffset = DestroyEffectOffset;
			if (DepressurizationEffectOffset.HasValue) def.DepressurizationEffectOffset = DepressurizationEffectOffset;
			if (DamageThreshold.HasValue )def.DamageThreshold = DamageThreshold.Value;
			if (DetonateChance.HasValue) def.DetonateChance = DetonateChance.Value;
			if (!string.IsNullOrEmpty(AmmoExplosionEffect)) def.AmmoExplosionEffect = AmmoExplosionEffect;
			if (!string.IsNullOrEmpty(AmmoExplosionSound)) def.AmmoExplosionSound = AmmoExplosionSound;

			if (EntityComponents != null) InitEntityComponents(EntityComponents, def);

			if (CompoundTemplates != null && CompoundTemplates.Length > 0) def.CompoundTemplates = CompoundTemplates;

			if (SubBlockDefinitions != null)
			{
				def.SubBlockDefinitions = new Dictionary<string, MyDefinitionId>();
				foreach (var mySubBlockDefinition in SubBlockDefinitions)
				{
					MyDefinitionId value;
					if (!def.SubBlockDefinitions.TryGetValue(mySubBlockDefinition.SubBlock, out value))
					{
						value = mySubBlockDefinition.Id;
						def.SubBlockDefinitions.Add(mySubBlockDefinition.SubBlock, value);
					}
				}
			}

			if (BlockVariants != null)
			{
				Logs.WriteLine("BlockVariants are obsolete! Use BlockVariantGroups instead.");
				def.BlockStages = new MyDefinitionId[BlockVariants.Length];
				for (int l = 0; l < BlockVariants.Length; l++)
				{
					def.BlockStages[l] = BlockVariants[l];
				}
			}

			if (CubeDefinition != null)
			{
				MyCubeDefinition myCubeDefinition = new MyCubeDefinition();
				myCubeDefinition.CubeTopology = CubeDefinition.CubeTopology;
				myCubeDefinition.ShowEdges = CubeDefinition.ShowEdges;
				MyObjectBuilder_CubeBlockDefinition.Side[] sides = CubeDefinition.Sides;
				myCubeDefinition.Model = new string[sides.Length];
				myCubeDefinition.PatternSize = new Vector2I[sides.Length];
				myCubeDefinition.ScaleTile = new Vector2I[sides.Length];
				for (int m = 0; m < sides.Length; m++)
				{
					MyObjectBuilder_CubeBlockDefinition.Side side = sides[m];
					myCubeDefinition.Model[m] = side.Model;
					myCubeDefinition.PatternSize[m] = side.PatternSize;
					myCubeDefinition.ScaleTile[m] = new Vector2I(side.ScaleTileU, side.ScaleTileV);
				}
				def.CubeDefinition = myCubeDefinition;
			}

			var buildProgressChange = BuildProgressModels != null && BuildProgressModels.Count > 0;

			#region Components
			float mass = 0f;
			float criticalIntegrity = 0f;
			float ownershipIntegrity = 0f;
			var criticalComp = CriticalComponent ?? ob.CriticalComponent;
			if (Components != null && Components.Length != 0)
			{
				def.Components = new MyCubeBlockDefinition.Component[Components.Length];
				float integrity = 0f;
				var criticalCompIndex = 0;
				for (int i = 0; i < Components.Length; i++)
				{
					var cubeBlockComponent = Components[i];
					var componentDefinition = MyDefinitionManager.Static.GetComponentDefinition(new MyDefinitionId(cubeBlockComponent.Type, cubeBlockComponent.Subtype));
					MyPhysicalItemDefinition myPhysicalItemDefinition = null;
					if (!cubeBlockComponent.DeconstructId.IsNull() && !MyDefinitionManager.Static.TryGetPhysicalItemDefinition(cubeBlockComponent.DeconstructId, out myPhysicalItemDefinition))
					{
						myPhysicalItemDefinition = componentDefinition;
					}
					if (myPhysicalItemDefinition == null)
					{
						myPhysicalItemDefinition = componentDefinition;
					}

					var component = new MyCubeBlockDefinition.Component
					{
						Definition = componentDefinition,
						Count = (int)cubeBlockComponent.Count,
						DeconstructItem = myPhysicalItemDefinition
					};
					if (cubeBlockComponent.Type == typeof(MyObjectBuilder_Component) && cubeBlockComponent.Subtype == "Computer" && ownershipIntegrity == 0f)
					{
						ownershipIntegrity = integrity + (float)component.Definition.MaxIntegrity;
					}
					integrity += (float)(component.Count * component.Definition.MaxIntegrity);

					if (cubeBlockComponent.Type == criticalComp.Type && cubeBlockComponent.Subtype == criticalComp.Subtype)
					{
						if (criticalCompIndex == criticalComp.Index)
						{
							def.CriticalGroup = (ushort)i;
							criticalIntegrity = integrity - (float)component.Definition.MaxIntegrity;
						}
						criticalCompIndex++;
					}
					mass += (float)component.Count * component.Definition.Mass;
					def.Components[i] = component;
				}

				var buildTime = BuildTimeSeconds ?? def.MaxIntegrity / def.IntegrityPointsPerSec;
                def.MaxIntegrity = integrity;

				if (!MyPerGameSettings.Destruction)
				{
					def.Mass = mass;
				}

				if (MaxIntegrity.HasValue) def.MaxIntegrity = MaxIntegrity.Value;

                def.IntegrityPointsPerSec = def.MaxIntegrity / buildTime;
                def.DisassembleRatio = DisassembleRatio ?? ob.DisassembleRatio;

                SetRatios(def, criticalIntegrity, ownershipIntegrity, buildProgressChange);
			}
			else if (MaxIntegrity.HasValue)
            {
                var buildTime = BuildTimeSeconds ?? def.MaxIntegrity / def.IntegrityPointsPerSec;
                def.MaxIntegrity = MaxIntegrity.Value;
                def.IntegrityPointsPerSec = def.MaxIntegrity / buildTime;

                SetRatios(def, criticalIntegrity, ownershipIntegrity, buildProgressChange);
			}

			#endregion

			if (buildProgressChange)
			{
				BuildProgressModels.Sort((MyObjectBuilder_CubeBlockDefinition.BuildProgressModel a, MyObjectBuilder_CubeBlockDefinition.BuildProgressModel b) => a.BuildPercentUpperBound.CompareTo(b.BuildPercentUpperBound));
				def.BuildProgressModels = new MyCubeBlockDefinition.BuildProgressModel[BuildProgressModels.Count];
				for (int num6 = 0; num6 < def.BuildProgressModels.Length; num6++)
				{
					var buildProgressModel = BuildProgressModels[num6];
					if (!string.IsNullOrEmpty(buildProgressModel.File))
					{
						def.BuildProgressModels[num6] = new MyCubeBlockDefinition.BuildProgressModel
						{
							BuildRatioUpperBound = ((def.CriticalIntegrityRatio > 0f) ? (buildProgressModel.BuildPercentUpperBound * def.CriticalIntegrityRatio) : buildProgressModel.BuildPercentUpperBound),
							File = path + "\\" + buildProgressModel.File,
							RandomOrientation = buildProgressModel.RandomOrientation
						};
					}
				}
			}

			if (GeneratedBlocks != null)
			{
				def.GeneratedBlockDefinitions = new MyDefinitionId[GeneratedBlocks.Length];
				for (int num7 = 0; num7 < GeneratedBlocks.Length; num7++)
				{
					SerializableDefinitionId v = GeneratedBlocks[num7];
					def.GeneratedBlockDefinitions[num7] = v;
				}
			}
			
			if (Skeleton != null && Skeleton.Count > 0)
            {
				def.Skeleton = Skeleton;
				def.Bones = new Dictionary<Vector3I, Vector3>(Skeleton.Count);
				foreach (var boneInfo in def.Skeleton)
				{
					def.Bones[boneInfo.BonePosition] = Vector3UByte.Denormalize(boneInfo.BoneOffset, MyDefinitionManager.Static.GetCubeSize(def.CubeSize));
				}
			}

			if (IsAirTight.HasValue) def.IsAirTight = IsAirTight;
			if (IsStandAlone.HasValue) def.IsStandAlone = IsStandAlone.Value;
			if (HasPhysics.HasValue) def.HasPhysics = HasPhysics.Value;
			if (UseNeighbourOxygenRooms.HasValue) def.UseNeighbourOxygenRooms = UseNeighbourOxygenRooms.Value;

			if (MountPoints != null)
			{
				InitMountPoints(ob, def);
				InitPressurization(def);
			}

			if (!string.IsNullOrEmpty(PrimarySound)) def.PrimarySound = new MySoundPair(PrimarySound, true);
			if (!string.IsNullOrEmpty(ActionSound)) def.ActionSound = new MySoundPair(ActionSound, true);
			if (!string.IsNullOrEmpty(DamagedSound)) def.DamagedSound = new MySoundPair(DamagedSound, true);
			if (!string.IsNullOrEmpty(DestroySound)) def.DestroySound = new MySoundPair(DestroySound, true);

			var pcu = MyAPIGateway.Session.SessionSettings.UseConsolePCU ? PCUConsole : PCU;
			if (pcu.HasValue) def.PCU = pcu.Value;
			if (PlaceDecals.HasValue) def.PlaceDecals = PlaceDecals.Value;

			if (TieredUpdateTimes != null && TieredUpdateTimes.Length > 0)
			{
				def.TieredUpdateTimes.Clear();
				foreach (var item in TieredUpdateTimes)
				{
					def.TieredUpdateTimes.Add(item);
				}
			}

			if (AllowInteractionThroughBlock.HasValue) def.AllowInteractionThroughBlock = AllowInteractionThroughBlock.Value;
		}

		public void SetRatios(MyCubeBlockDefinition def, float criticalIntegrity, float ownershipIntegrity, bool buildProgressChange)
        {
			var newCriticalIntegrityRatio = criticalIntegrity / def.MaxIntegrity;
			if (!buildProgressChange && def.CriticalIntegrityRatio > 0)
			{
				var ratioChange = newCriticalIntegrityRatio / def.CriticalIntegrityRatio;
				foreach (var model in def.BuildProgressModels)
				{
					model.BuildRatioUpperBound *= ratioChange;
				}
			}
			def.CriticalIntegrityRatio = newCriticalIntegrityRatio;
			def.OwnershipIntegrityRatio = ownershipIntegrity / def.MaxIntegrity;
		}

		public void InitPressurization(MyCubeBlockDefinition def)
		{
			def.IsCubePressurized = new Dictionary<Vector3I, Dictionary<Vector3I, MyCubeBlockDefinition.MyCubePressurizationMark>>();
			for (int i = 0; i < def.Size.X; i++)
			{
				for (int j = 0; j < def.Size.Y; j++)
				{
					for (int k = 0; k < def.Size.Z; k++)
					{
						Vector3 vector = new Vector3((float)i, (float)j, (float)k);
						Vector3 vector2 = new Vector3((float)i, (float)j, (float)k) + Vector3.One;
						Vector3I key = new Vector3I(i, j, k);
						def.IsCubePressurized[key] = new Dictionary<Vector3I, MyCubeBlockDefinition.MyCubePressurizationMark>();
						for (int m = 0; m < 6; m++)
						{
							var vector3I = Base6Directions.IntDirections[m];
							def.IsCubePressurized[key][vector3I] = MyCubeBlockDefinition.MyCubePressurizationMark.NotPressurized;
							if ((vector3I.X != 1 || i == def.Size.X - 1) && (vector3I.X != -1 || i == 0) && (vector3I.Y != 1 || j == def.Size.Y - 1) && (vector3I.Y != -1 || j == 0) && (vector3I.Z != 1 || k == def.Size.Z - 1) && (vector3I.Z != -1 || k == 0))
							{
								foreach (var mountPoint in def.MountPoints)
								{
									if (vector3I == mountPoint.Normal)
									{
										int mountPointWallIndex = MyCubeBlockDefinition.GetMountPointWallIndex(Base6Directions.GetDirection(ref vector3I));
										Vector3I size = def.Size;
										Vector3 start = mountPoint.Start;
										Vector3 end = mountPoint.End;
										Vector3 vector3;
										UntransformMountPointPosition(ref start, mountPointWallIndex, size, out vector3);
										Vector3 vector4;
										UntransformMountPointPosition(ref end, mountPointWallIndex, size, out vector4);
										Vector3 vector5;
										UntransformMountPointPosition(ref vector, mountPointWallIndex, size, out vector5);
										Vector3 vector6;
										UntransformMountPointPosition(ref vector2, mountPointWallIndex, size, out vector6);
										Vector3 vector7 = new Vector3(Math.Max(vector5.X, vector6.X), Math.Max(vector5.Y, vector6.Y), Math.Max(vector5.Z, vector6.Z));
										Vector3 vector8 = new Vector3(Math.Min(vector5.X, vector6.X), Math.Min(vector5.Y, vector6.Y), Math.Min(vector5.Z, vector6.Z));
										if ((double)vector3.X - 0.05 <= (double)vector8.X && (double)vector4.X + 0.05 > (double)vector7.X && (double)vector3.Y - 0.05 <= (double)vector8.Y && (double)vector4.Y + 0.05 > (double)vector7.Y)
										{
											if (mountPoint.PressurizedWhenOpen)
											{
												def.IsCubePressurized[key][vector3I] = MyCubeBlockDefinition.MyCubePressurizationMark.PressurizedAlways;
												break;
											}
											def.IsCubePressurized[key][vector3I] = MyCubeBlockDefinition.MyCubePressurizationMark.PressurizedClosed;
											break;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		internal static void UntransformMountPointPosition(ref Vector3 position, int wallIndex, Vector3I cubeSize, out Vector3 result)
		{
			Vector3 vector = position - m_mountPointWallOffsets[wallIndex] * cubeSize;
			Matrix matrix = Matrix.Invert(m_mountPointTransforms[wallIndex]);
			Vector3.Transform(ref vector, ref matrix, out result);
		}

		private void InitEntityComponents(MyObjectBuilder_CubeBlockDefinition.EntityComponentDefinition[] entityComponentDefinitions, MyCubeBlockDefinition def)
		{
			def.EntityComponents = new Dictionary<string, MyObjectBuilder_ComponentBase>(entityComponentDefinitions.Length);
			foreach (var entityComponentDefinition in entityComponentDefinitions)
			{
				MyObjectBuilderType type = MyObjectBuilderType.Parse(entityComponentDefinition.BuilderType);
				if (!type.IsNull)
				{
					var myObjectBuilder_ComponentBase = MyObjectBuilderSerializer.CreateNewObject(type) as MyObjectBuilder_ComponentBase;
					if (myObjectBuilder_ComponentBase != null)
					{
						def.EntityComponents.Add(entityComponentDefinition.ComponentType, myObjectBuilder_ComponentBase);
					}
				}
			}
		}

		private void InitMountPoints(MyObjectBuilder_CubeBlockDefinition ob, MyCubeBlockDefinition def)
		{
			var size = Size ?? ob.Size;

			SetMountPoints(ref def.MountPoints, MountPoints, m_tmpMounts, size);

			var bpModels = BuildProgressModels ?? ob.BuildProgressModels;
			if (bpModels != null)
			{
				for (int i = 0; i < bpModels.Count; i++)
				{
					MyCubeBlockDefinition.BuildProgressModel buildProgressModel = def.BuildProgressModels[i];
					if (buildProgressModel != null)
					{
						MyObjectBuilder_CubeBlockDefinition.BuildProgressModel buildProgressModel2 = bpModels[i];
						if (buildProgressModel2.MountPoints != null)
						{
							MyObjectBuilder_CubeBlockDefinition.MountPoint[] mountPoints = buildProgressModel2.MountPoints;
							for (int j = 0; j < mountPoints.Length; j++)
							{
								MyObjectBuilder_CubeBlockDefinition.MountPoint mountPoint = mountPoints[j];
								int sideId = (int)mountPoint.Side;
								if (!m_tmpIndices.Contains(sideId))
								{
									m_tmpMounts.RemoveAll((MyObjectBuilder_CubeBlockDefinition.MountPoint mount) => mount.Side == (BlockSideEnum)sideId);
									m_tmpIndices.Add(sideId);
								}
								m_tmpMounts.Add(mountPoint);
							}
							m_tmpIndices.Clear();
							buildProgressModel.MountPoints = new MyCubeBlockDefinition.MountPoint[m_tmpMounts.Count];
							SetMountPoints(ref buildProgressModel.MountPoints, m_tmpMounts.ToArray(), null, size);
						}
					}
				}
			}
			m_tmpMounts.Clear();
		}

		private void SetMountPoints(ref MyCubeBlockDefinition.MountPoint[] mountPoints, MyObjectBuilder_CubeBlockDefinition.MountPoint[] mpBuilders, List<MyObjectBuilder_CubeBlockDefinition.MountPoint> addedMounts, SerializableVector3I size)
		{
			if (mountPoints == null)
			{
				mountPoints = new MyCubeBlockDefinition.MountPoint[mpBuilders.Length];
			}
			for (int i = 0; i < mountPoints.Length; i++)
			{
				MyObjectBuilder_CubeBlockDefinition.MountPoint mountPoint = mpBuilders[i];
				if (addedMounts != null)
				{
					addedMounts.Add(mountPoint);
				}
				Vector3 start = new Vector3(Vector2.Min(mountPoint.Start, mountPoint.End) + 0.001f, 0.0004f);
				Vector3 end = new Vector3(Vector2.Max(mountPoint.Start, mountPoint.End) - 0.001f, -0.0004f);
				int side = (int)mountPoint.Side;
				Vector3I forward = Vector3I.Forward;
				TransformMountPointPosition(ref start, side, size, out start);
				TransformMountPointPosition(ref end, side, size, out end);
				Vector3I.TransformNormal(ref forward, ref m_mountPointTransforms[side], out forward);
				mountPoints[i].Start = start;
				mountPoints[i].End = end;
				mountPoints[i].Normal = forward;
				mountPoints[i].ExclusionMask = mountPoint.ExclusionMask;
				mountPoints[i].PropertiesMask = mountPoint.PropertiesMask;
				mountPoints[i].Enabled = mountPoint.Enabled;
				mountPoints[i].PressurizedWhenOpen = mountPoint.PressurizedWhenOpen;
				mountPoints[i].Default = mountPoint.Default;
			}
		}

		internal static void TransformMountPointPosition(ref Vector3 position, int wallIndex, Vector3I cubeSize, out Vector3 result)
		{
			Vector3.Transform(ref position, ref m_mountPointTransforms[wallIndex], out result);
			result += m_mountPointWallOffsets[wallIndex] * cubeSize;
		}

		private static Matrix[] m_mountPointTransforms = new Matrix[]
		{
			Matrix.CreateFromDir(Vector3.Right, Vector3.Up) * Matrix.CreateScale(1f, 1f, -1f),
			Matrix.CreateFromDir(Vector3.Up, Vector3.Forward) * Matrix.CreateScale(-1f, 1f, 1f),
			Matrix.CreateFromDir(Vector3.Forward, Vector3.Up) * Matrix.CreateScale(-1f, 1f, 1f),
			Matrix.CreateFromDir(Vector3.Left, Vector3.Up) * Matrix.CreateScale(1f, 1f, -1f),
			Matrix.CreateFromDir(Vector3.Down, Vector3.Backward) * Matrix.CreateScale(-1f, 1f, 1f),
			Matrix.CreateFromDir(Vector3.Backward, Vector3.Up) * Matrix.CreateScale(-1f, 1f, 1f)
		};

		private static Vector3[] m_mountPointWallOffsets = new Vector3[]
		{
			new Vector3(1f, 0f, 1f),
			new Vector3(0f, 1f, 1f),
			new Vector3(1f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 0f),
			new Vector3(0f, 0f, 1f)
		};

		private static List<MyObjectBuilder_CubeBlockDefinition.MountPoint> m_tmpMounts = new List<MyObjectBuilder_CubeBlockDefinition.MountPoint>();

		private static List<int> m_tmpIndices = new List<int>();
	}

}
