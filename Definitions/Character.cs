using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions
{
    public class CharacterDefinition : Definition
    {
		public string Name;

		public string Model;

		public string ReflectorTexture;

		public string LeftGlare;

		public string RightGlare;

		public string Skeleton;

		public float? LightGlareSize;

		public Vector3? LightOffset;

		public MyObjectBuilder_JetpackDefinition Jetpack;

		[XmlArrayItem("Resource")]
		public List<SuitResourceDefinition> SuitResourceStorage;

		//[XmlArrayItem("BoneSet")]
		//public MyBoneSetDefinition[] BoneSets;

		//[XmlArrayItem("BoneSet")]
		//public MyBoneSetDefinition[] BoneLODs;

		//public string LeftLightBone;

		//public string RightLightBone;

		//public string HeadBone;

		//public string LeftHandIKStartBone;

		//public string LeftHandIKEndBone;

		//public string RightHandIKStartBone;

		//public string RightHandIKEndBone;

		//public string WeaponBone;

		//public string Camera3rdBone;

		//public string LeftHandItemBone;

		//public string LeftForearmBone;

		//public string LeftUpperarmBone;

		//public string RightForearmBone;

		//public string RightUpperarmBone;

		//public string SpineBone;

		//public float? BendMultiplier1st;

		//public float? BendMultiplier3rd;

		[XmlArrayItem("Material")]
		public string[] MaterialsDisabledIn1st;

		//[XmlArrayItem("Mapping")]
		//public MyMovementAnimationMapping[] AnimationMappings;

		public float? Mass;

		//public string ModelRootBoneName;

		//public string LeftHipBoneName;

		//public string LeftKneeBoneName;

		//public string LeftAnkleBoneName;

		//public string RightHipBoneName;

		//public string RightKneeBoneName;

		//public string RightAnkleBoneName;

		//public bool? FeetIKEnabled;

		//[XmlArrayItem("FeetIKSettings")]
		//public MyObjectBuilder_MyFeetIKSettings[] IKSettings;

		//public string RightHandItemBone;

		public bool? UsesAtmosphereDetector;

		public bool? UsesReverbDetector;

		public bool? NeedsOxygen;

		//public string RagdollDataFile;

		//[XmlArrayItem("BoneSet")]
		//public MyRagdollBoneSetDefinition[] RagdollBonesMappings;

		//[XmlArrayItem("BoneSet")]
		//public MyBoneSetDefinition[] RagdollPartialSimulations;

		public float? OxygenConsumptionMultiplier;

		public float? OxygenConsumption;

		public float? PressureLevelForLowDamage;

		public float? DamageAmountAtZeroPressure;

		public bool? VerticalPositionFlyingOnly;

		public bool? UseOnlyWalking;

		public float? MaxSlope;

		public float? MaxSprintSpeed;

		public float? MaxRunSpeed;

		public float? MaxBackrunSpeed;

		public float? MaxRunStrafingSpeed;

		public float? MaxWalkSpeed;

		public float? MaxBackwalkSpeed;

		public float? MaxWalkStrafingSpeed;

		public float? MaxCrouchWalkSpeed;

		public float? MaxCrouchBackwalkSpeed;

		public float? MaxCrouchStrafingSpeed;

		public float? CharacterHeadSize;

		public float? CharacterHeadHeight;

		public float? CharacterCollisionScale;

		public float? CharacterCollisionWidth;

		public float? CharacterCollisionHeight;

		public float? CharacterCollisionCrouchHeight;

		public bool? CanCrouch;

		public bool? CanIronsight;

		public float? JumpForce;

		public string JumpSoundName;

		public string JetpackIdleSoundName;

		public string JetpackRunSoundName;

		public string CrouchDownSoundName;

		public string CrouchUpSoundName;

		public string MovementSoundName;

		public string PainSoundName;

		public string SuffocateSoundName;

		public string DeathSoundName;

		public string DeathBySuffocationSoundName;

		public string IronsightActSoundName;

		public string IronsightDeactSoundName;

		public string FastFlySoundName;

		public string HelmetOxygenNormalSoundName;

		public string HelmetOxygenLowSoundName;

		public string HelmetOxygenCriticalSoundName;

		public string HelmetOxygenNoneSoundName;

		public string MagnetBootsStartSoundName;

		public string MagnetBootsEndSoundName;

		public string MagnetBootsStepsSoundName;

		public string MagnetBootsProximitySoundName;

		public bool? LoopingFootsteps;

		public bool? VisibleOnHud;

		public bool? UsableByPlayer;

		//public string RagdollRootBody;

		public MyObjectBuilder_InventoryDefinition Inventory;

		//public string EnabledComponents;

		public bool? EnableSpawnInventoryAsContainer;

		public SerializableDefinitionId? InventorySpawnContainerId;

		public bool? SpawnInventoryOnBodyRemoval;

		public float? LootingTime;

		public string InitialAnimation;

		public float? ImpulseLimit;

		public string PhysicalMaterial;

		public MyObjectBuilder_DeadBodyShape DeadBodyShape;

		public string AnimationController;

		public float? MaxForce;

		public MyEnumCharacterRotationToSupport? RotationToSupport;

		public string HUD;

		public bool? EnableFirstPersonView;

		public string BreathCalmSoundName;

		public string BreathHeavySoundName;

		public string OxygenChokeNormalSoundName;

		public string OxygenChokeLowSoundName;

		public string OxygenChokeCriticalSoundName;

		public float? OxygenSuitRefillTime;

		public float? MinOxygenLevelForSuitRefill;

		public float? SuitConsumptionInTemperatureExtreme;

		public string FootprintDecal;

		public string FootprintMirroredDecal;

		//public List<int> WeakPointBoneIndices;

		public float? RecoilJetpackDampeningDegPerS;

		[XmlArrayItem("Item")]
		public List<MyObjectBuilder_FootsPosition> FootOnGroundPostions;

		public int? StepSoundDelay;

		public float? AnkleHeightWhileStanding;

		public float? CrouchHeadServerOffset;

		public float? HeadServerOffset;

		public string Gender;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyCharacterDefinition;

			if (!string.IsNullOrEmpty(Name)) def.Name = Name;
			if (!string.IsNullOrEmpty(Model)) def.Model = Model;
			if (!string.IsNullOrEmpty(ReflectorTexture)) def.ReflectorTexture = ReflectorTexture;
			if (!string.IsNullOrEmpty(LeftGlare)) def.LeftGlare = LeftGlare;
			if (!string.IsNullOrEmpty(RightGlare)) def.RightGlare = RightGlare;
			if (!string.IsNullOrEmpty(Skeleton)) def.Skeleton = Skeleton;

			if (LightGlareSize.HasValue) def.LightGlareSize = LightGlareSize.Value;
			if (LightOffset.HasValue) def.LightOffset = LightOffset.Value;

			if (Jetpack != null) def.Jetpack = Jetpack;
			if (SuitResourceStorage != null && SuitResourceStorage.Count > 0) def.SuitResourceStorage = SuitResourceStorage;

			if (MaterialsDisabledIn1st != null && MaterialsDisabledIn1st.Length > 0) def.MaterialsDisabledIn1st = MaterialsDisabledIn1st;

			if (Mass.HasValue) def.Mass = Mass.Value;

			if (UsesAtmosphereDetector.HasValue) def.UsesAtmosphereDetector = UsesAtmosphereDetector.Value;
			if (UsesReverbDetector.HasValue) def.UsesReverbDetector = UsesReverbDetector.Value;
			if (NeedsOxygen.HasValue) def.NeedsOxygen = NeedsOxygen.Value;
			if (OxygenConsumptionMultiplier.HasValue) def.OxygenConsumptionMultiplier = OxygenConsumptionMultiplier.Value;
			if (OxygenConsumption.HasValue) def.OxygenConsumption = OxygenConsumption.Value;
			if (PressureLevelForLowDamage.HasValue) def.PressureLevelForLowDamage = PressureLevelForLowDamage.Value;
			if (DamageAmountAtZeroPressure.HasValue) def.DamageAmountAtZeroPressure = DamageAmountAtZeroPressure.Value;
			if (VerticalPositionFlyingOnly.HasValue) def.VerticalPositionFlyingOnly = VerticalPositionFlyingOnly.Value;
			if (UseOnlyWalking.HasValue) def.UseOnlyWalking = UseOnlyWalking.Value;
			if (MaxSlope.HasValue) def.MaxSlope = MaxSlope.Value;
			if (MaxSprintSpeed.HasValue) def.MaxSprintSpeed = MaxSprintSpeed.Value;
			if (MaxRunSpeed.HasValue) def.MaxRunSpeed = MaxRunSpeed.Value;
			if (MaxBackrunSpeed.HasValue) def.MaxBackrunSpeed = MaxBackrunSpeed.Value;
			if (MaxRunStrafingSpeed.HasValue) def.MaxRunStrafingSpeed = MaxRunStrafingSpeed.Value;
			if (MaxWalkSpeed.HasValue) def.MaxWalkSpeed = MaxWalkSpeed.Value;
			if (MaxBackwalkSpeed.HasValue) def.MaxBackwalkSpeed = MaxBackwalkSpeed.Value;
			if (MaxWalkStrafingSpeed.HasValue) def.MaxWalkStrafingSpeed = MaxWalkStrafingSpeed.Value;
			if (MaxCrouchWalkSpeed.HasValue) def.MaxCrouchWalkSpeed = MaxCrouchWalkSpeed.Value;
			if (MaxCrouchBackwalkSpeed.HasValue) def.MaxCrouchBackwalkSpeed = MaxCrouchBackwalkSpeed.Value;
			if (MaxCrouchStrafingSpeed.HasValue) def.MaxCrouchStrafingSpeed = MaxCrouchStrafingSpeed.Value;
			if (CharacterHeadSize.HasValue) def.CharacterHeadSize = CharacterHeadSize.Value;
			if (CharacterHeadHeight.HasValue) def.CharacterHeadHeight = CharacterHeadHeight.Value;
			if (CharacterCollisionScale.HasValue) def.CharacterCollisionScale = CharacterCollisionScale.Value;
			if (CharacterCollisionWidth.HasValue) def.CharacterCollisionWidth = CharacterCollisionWidth.Value;
			if (CharacterCollisionHeight.HasValue) def.CharacterCollisionHeight = CharacterCollisionHeight.Value;
			if (CharacterCollisionCrouchHeight.HasValue) def.CharacterCollisionCrouchHeight = CharacterCollisionCrouchHeight.Value;
			if (CanCrouch.HasValue) def.CanCrouch = CanCrouch.Value;
			if (CanIronsight.HasValue) def.CanIronsight = CanIronsight.Value;
			if (JumpForce.HasValue) def.JumpForce = JumpForce.Value;

			if (!string.IsNullOrEmpty(JumpSoundName)) def.JumpSoundName = JumpSoundName;
			if (!string.IsNullOrEmpty(JetpackIdleSoundName)) def.JetpackIdleSoundName = JetpackIdleSoundName;
			if (!string.IsNullOrEmpty(JetpackRunSoundName)) def.JetpackRunSoundName = JetpackRunSoundName;
			if (!string.IsNullOrEmpty(CrouchDownSoundName)) def.CrouchDownSoundName = CrouchDownSoundName;
			if (!string.IsNullOrEmpty(CrouchUpSoundName)) def.CrouchUpSoundName = CrouchUpSoundName;
			if (!string.IsNullOrEmpty(MovementSoundName)) def.MovementSoundName = MovementSoundName;
			if (!string.IsNullOrEmpty(PainSoundName)) def.PainSoundName = PainSoundName;
			if (!string.IsNullOrEmpty(SuffocateSoundName)) def.SuffocateSoundName = SuffocateSoundName;
			if (!string.IsNullOrEmpty(DeathSoundName)) def.DeathSoundName = DeathSoundName;
			if (!string.IsNullOrEmpty(DeathBySuffocationSoundName)) def.DeathBySuffocationSoundName = DeathBySuffocationSoundName;
			if (!string.IsNullOrEmpty(IronsightActSoundName)) def.IronsightActSoundName = IronsightActSoundName;
			if (!string.IsNullOrEmpty(IronsightDeactSoundName)) def.IronsightDeactSoundName = IronsightDeactSoundName;
			if (!string.IsNullOrEmpty(FastFlySoundName)) def.FastFlySoundName = FastFlySoundName;
			if (!string.IsNullOrEmpty(HelmetOxygenNormalSoundName)) def.HelmetOxygenNormalSoundName = HelmetOxygenNormalSoundName;
			if (!string.IsNullOrEmpty(HelmetOxygenLowSoundName)) def.HelmetOxygenLowSoundName = HelmetOxygenLowSoundName;
			if (!string.IsNullOrEmpty(HelmetOxygenCriticalSoundName)) def.HelmetOxygenCriticalSoundName = HelmetOxygenCriticalSoundName;
			if (!string.IsNullOrEmpty(HelmetOxygenNoneSoundName)) def.HelmetOxygenNoneSoundName = HelmetOxygenNoneSoundName;
			if (!string.IsNullOrEmpty(MagnetBootsStartSoundName)) def.MagnetBootsStartSoundName = MagnetBootsStartSoundName;
			if (!string.IsNullOrEmpty(MagnetBootsEndSoundName)) def.MagnetBootsEndSoundName = MagnetBootsEndSoundName;
			if (!string.IsNullOrEmpty(MagnetBootsStepsSoundName)) def.MagnetBootsStepsSoundName = MagnetBootsStepsSoundName;
			if (!string.IsNullOrEmpty(MagnetBootsProximitySoundName)) def.MagnetBootsProximitySoundName = MagnetBootsProximitySoundName;

			if (LoopingFootsteps.HasValue) def.LoopingFootsteps = LoopingFootsteps.Value;
			if (VisibleOnHud.HasValue) def.VisibleOnHud = VisibleOnHud.Value;
			if (UsableByPlayer.HasValue) def.UsableByPlayer = UsableByPlayer.Value;
			if (Inventory != null) def.InventoryDefinition = Inventory;

			if (EnableSpawnInventoryAsContainer.HasValue) def.EnableSpawnInventoryAsContainer = EnableSpawnInventoryAsContainer.Value;
			if (InventorySpawnContainerId.HasValue) def.InventorySpawnContainerId = InventorySpawnContainerId.Value;
			if (SpawnInventoryOnBodyRemoval.HasValue) def.SpawnInventoryOnBodyRemoval = SpawnInventoryOnBodyRemoval.Value;
			if (LootingTime.HasValue) def.LootingTime = LootingTime.Value;

			if (!string.IsNullOrEmpty(InitialAnimation)) def.InitialAnimation = InitialAnimation;
			if (ImpulseLimit.HasValue) def.ImpulseLimit = ImpulseLimit.Value;
			if (!string.IsNullOrEmpty(PhysicalMaterial)) def.PhysicalMaterial = PhysicalMaterial;
			if (DeadBodyShape != null) def.DeadBodyShape = DeadBodyShape;
			if (!string.IsNullOrEmpty(AnimationController)) def.AnimationController = AnimationController;
			if (MaxForce.HasValue) def.MaxForce = MaxForce.Value;
			if (RotationToSupport.HasValue) def.RotationToSupport = RotationToSupport.Value;
			if (!string.IsNullOrEmpty(HUD)) def.HUD = HUD;
			if (EnableFirstPersonView.HasValue) def.EnableFirstPersonView = EnableFirstPersonView.Value;


			if (!string.IsNullOrEmpty(BreathCalmSoundName)) def.BreathCalmSoundName = BreathCalmSoundName;
			if (!string.IsNullOrEmpty(BreathHeavySoundName)) def.BreathHeavySoundName = BreathHeavySoundName;
			if (!string.IsNullOrEmpty(OxygenChokeNormalSoundName)) def.OxygenChokeNormalSoundName = OxygenChokeNormalSoundName;
			if (!string.IsNullOrEmpty(OxygenChokeLowSoundName)) def.OxygenChokeLowSoundName = OxygenChokeLowSoundName;
			if (!string.IsNullOrEmpty(OxygenChokeCriticalSoundName)) def.OxygenChokeCriticalSoundName = OxygenChokeCriticalSoundName;

			if (OxygenSuitRefillTime.HasValue) def.OxygenSuitRefillTime = OxygenSuitRefillTime.Value;
			if (MinOxygenLevelForSuitRefill.HasValue) def.MinOxygenLevelForSuitRefill = MinOxygenLevelForSuitRefill.Value;
			if (SuitConsumptionInTemperatureExtreme.HasValue) def.SuitConsumptionInTemperatureExtreme = SuitConsumptionInTemperatureExtreme.Value;

			if (!string.IsNullOrEmpty(FootprintDecal)) def.FootprintDecal = MyStringHash.GetOrCompute(FootprintDecal);
			if (!string.IsNullOrEmpty(FootprintMirroredDecal)) def.FootprintMirroredDecal = MyStringHash.GetOrCompute(FootprintMirroredDecal);

			if (RecoilJetpackDampeningDegPerS.HasValue) def.RecoilJetpackDampeningRadPerFrame = (float)((double)RecoilJetpackDampeningDegPerS.Value * 0.017453292519943295 / 60.0);
			if (FootOnGroundPostions != null && FootOnGroundPostions.Count > 0) def.FootOnGroundPostions = FootOnGroundPostions;
			if (StepSoundDelay.HasValue) def.StepSoundDelay = StepSoundDelay.Value;
			if (AnkleHeightWhileStanding.HasValue) def.AnkleHeightWhileStanding = AnkleHeightWhileStanding.Value;
			if (CrouchHeadServerOffset.HasValue) def.CrouchHeadServerOffset = CrouchHeadServerOffset.Value;
			if (HeadServerOffset.HasValue) def.HeadServerOffset = HeadServerOffset.Value;

			if (!string.IsNullOrEmpty(Gender)) def.Gender = Gender;
		}
    }
}
