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
	[XmlInclude(typeof(EngineerToolBaseDefinition))]
	public class HandItemDefinition : Definition
    {
		public Quaternion? LeftHandOrientation;

		public Vector3? LeftHandPosition;

		public Quaternion? RightHandOrientation;

		public Vector3? RightHandPosition;

		public Quaternion? ItemOrientation;

		public Vector3? ItemPosition;

		public Quaternion? ItemWalkingOrientation;

		public Vector3? ItemWalkingPosition;

		public Quaternion? ItemShootOrientation;

		public Vector3? ItemShootPosition;

		public Quaternion? ItemIronsightOrientation;

		public Vector3? ItemIronsightPosition;

		public Quaternion? ItemOrientation3rd;

		public Vector3? ItemPosition3rd;

		public Quaternion? ItemWalkingOrientation3rd;

		public Vector3? ItemWalkingPosition3rd;

		public Quaternion? ItemShootOrientation3rd;

		public Vector3? ItemShootPosition3rd;

		public float? BlendTime;

		public float? ShootBlend;

		public float? XAmplitudeOffset;

		public float? YAmplitudeOffset;

		public float? ZAmplitudeOffset;

		public float? XAmplitudeScale;

		public float? YAmplitudeScale;

		public float? ZAmplitudeScale;

		public float? RunMultiplier;

		public float? AmplitudeMultiplier3rd;

		public bool? SimulateLeftHand;

		public bool? SimulateRightHand;

		public bool? SimulateLeftHandFps;

		public bool? SimulateRightHandFps;

		public string FingersAnimation;

		public Vector3? MuzzlePosition;

		public Vector3? ShootScatter;

		public float? ScatterSpeed;

		public SerializableDefinitionId? PhysicalItemId;

		public Vector4? LightColor;

		public float? LightFalloff;

		public float? LightRadius;

		public float? LightGlareSize;

		public float? LightGlareIntensity;

		public float? LightIntensityLower;

		public float? LightIntensityUpper;

		public float? ShakeAmountTarget;

		public float? ShakeAmountNoTarget;

		public List<ToolSound> ToolSounds;

		public string ToolMaterial;

		public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
			base.Load(definitionBase, path);

			var def = definitionBase as MyHandItemDefinition;

			if (LeftHandOrientation.HasValue) def.LeftHand = Matrix.CreateFromQuaternion(Quaternion.Normalize(LeftHandOrientation.Value));
			if (LeftHandPosition.HasValue) def.LeftHand.Translation = LeftHandPosition.Value;
			if (RightHandOrientation.HasValue) def.RightHand = Matrix.CreateFromQuaternion(Quaternion.Normalize(RightHandOrientation.Value));
			if (RightHandPosition.HasValue) def.RightHand.Translation = RightHandPosition.Value;
			if (ItemOrientation.HasValue) def.ItemLocation = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemOrientation.Value));
			if (ItemPosition.HasValue) def.ItemLocation.Translation = ItemPosition.Value;
			if (ItemWalkingOrientation.HasValue) def.ItemWalkingLocation = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemWalkingOrientation.Value));
			if (ItemWalkingPosition.HasValue) def.ItemWalkingLocation.Translation = ItemWalkingPosition.Value;
			if (ItemShootOrientation.HasValue) def.ItemShootLocation = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemShootOrientation.Value));
			if (ItemShootPosition.HasValue) def.ItemShootLocation.Translation = ItemShootPosition.Value;
			if (ItemIronsightOrientation.HasValue) def.ItemIronsightLocation = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemIronsightOrientation.Value));
			if (ItemIronsightPosition.HasValue) def.ItemIronsightLocation.Translation = ItemIronsightPosition.Value;
			if (ItemOrientation3rd.HasValue) def.ItemLocation3rd = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemOrientation3rd.Value));
			if (ItemPosition3rd.HasValue) def.ItemLocation3rd.Translation = ItemPosition3rd.Value;
			if (ItemWalkingOrientation3rd.HasValue) def.ItemWalkingLocation3rd = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemWalkingOrientation3rd.Value));
			if (ItemWalkingPosition3rd.HasValue) def.ItemWalkingLocation3rd.Translation = ItemWalkingPosition3rd.Value;
			if (ItemShootOrientation3rd.HasValue) def.ItemShootLocation3rd = Matrix.CreateFromQuaternion(Quaternion.Normalize(ItemShootOrientation3rd.Value));
			if (ItemShootPosition3rd.HasValue) def.ItemShootLocation3rd.Translation = ItemShootPosition3rd.Value;

			if (BlendTime.HasValue) def.BlendTime = BlendTime.Value;
			if (ShootBlend.HasValue) def.ShootBlend = ShootBlend.Value;
			if (XAmplitudeOffset.HasValue) def.XAmplitudeOffset = XAmplitudeOffset.Value;
			if (YAmplitudeOffset.HasValue) def.YAmplitudeOffset = YAmplitudeOffset.Value;
			if (ZAmplitudeOffset.HasValue) def.ZAmplitudeOffset = ZAmplitudeOffset.Value;
			if (XAmplitudeScale.HasValue) def.XAmplitudeScale = XAmplitudeScale.Value;
			if (YAmplitudeScale.HasValue) def.YAmplitudeScale = YAmplitudeScale.Value;
			if (ZAmplitudeScale.HasValue) def.ZAmplitudeScale = ZAmplitudeScale.Value;
			if (RunMultiplier.HasValue) def.RunMultiplier = RunMultiplier.Value;
			if (AmplitudeMultiplier3rd.HasValue) def.AmplitudeMultiplier3rd = AmplitudeMultiplier3rd.Value;
			if (SimulateLeftHand.HasValue) def.SimulateLeftHand = SimulateLeftHand.Value;
			if (SimulateRightHand.HasValue) def.SimulateRightHand = SimulateRightHand.Value;
			if (SimulateLeftHandFps.HasValue) def.SimulateLeftHandFps = SimulateLeftHandFps.Value;
			if (SimulateRightHandFps.HasValue) def.SimulateRightHandFps = SimulateRightHandFps.Value;
			if (!string.IsNullOrEmpty(FingersAnimation)) def.FingersAnimation = FingersAnimation;
			if (MuzzlePosition.HasValue) def.MuzzlePosition = MuzzlePosition.Value;
			if (ShootScatter.HasValue) def.ShootScatter = ShootScatter.Value;
			if (ScatterSpeed.HasValue) def.ScatterSpeed = ScatterSpeed.Value;
			if (PhysicalItemId.HasValue) def.PhysicalItemId = PhysicalItemId.Value;
			if (LightColor.HasValue) def.LightColor = LightColor.Value;
			if (LightFalloff.HasValue) def.LightFalloff = LightFalloff.Value;
			if (LightRadius.HasValue) def.LightRadius = LightRadius.Value;
			if (LightGlareSize.HasValue) def.LightGlareSize = LightGlareSize.Value;
			if (LightGlareIntensity.HasValue) def.LightGlareIntensity = LightGlareIntensity.Value;
			if (LightIntensityLower.HasValue) def.LightIntensityLower = LightIntensityLower.Value;
			if (LightIntensityUpper.HasValue) def.LightIntensityUpper = LightIntensityUpper.Value;
			if (ShakeAmountTarget.HasValue) def.ShakeAmountTarget = ShakeAmountTarget.Value;
			if (ShakeAmountNoTarget.HasValue) def.ShakeAmountNoTarget = ShakeAmountNoTarget.Value;
			if (ToolSounds != null && ToolSounds.Count > 0) def.ToolSounds = ToolSounds;
			if (!string.IsNullOrEmpty(ToolMaterial)) def.ToolMaterial = MyStringHash.GetOrCompute(ToolMaterial);

			if (ItemPositioning.HasValue) def.ItemPositioning = ItemPositioning.Value;
			if (ItemPositioning3rd.HasValue) def.ItemPositioning3rd = ItemPositioning3rd.Value;
			if (ItemPositioningWalk.HasValue) def.ItemPositioningWalk = ItemPositioningWalk.Value;
			if (ItemPositioningWalk3rd.HasValue) def.ItemPositioningWalk3rd = ItemPositioningWalk3rd.Value;
			if (ItemPositioningShoot.HasValue) def.ItemPositioningShoot = ItemPositioningShoot.Value;
			if (ItemPositioningShoot3rd.HasValue) def.ItemPositioningShoot3rd = ItemPositioningShoot3rd.Value;
			if (ItemPositioningIronsight.HasValue) def.ItemPositioningIronsight = ItemPositioningIronsight.Value;
			if (ItemPositioningIronsight3rd.HasValue) def.ItemPositioningIronsight3rd = ItemPositioningIronsight3rd.Value;

			if (SprintSpeedMultiplier.HasValue) def.SprintSpeedMultiplier = SprintSpeedMultiplier.Value;
			if (RunSpeedMultiplier.HasValue) def.RunSpeedMultiplier = RunSpeedMultiplier.Value;
			if (BackrunSpeedMultiplier.HasValue) def.BackrunSpeedMultiplier = BackrunSpeedMultiplier.Value;
			if (RunStrafingSpeedMultiplier.HasValue) def.RunStrafingSpeedMultiplier = RunStrafingSpeedMultiplier.Value;
			if (WalkSpeedMultiplier.HasValue) def.WalkSpeedMultiplier = WalkSpeedMultiplier.Value;
			if (BackwalkSpeedMultiplier.HasValue) def.BackwalkSpeedMultiplier = BackwalkSpeedMultiplier.Value;
			if (WalkStrafingSpeedMultiplier.HasValue) def.WalkStrafingSpeedMultiplier = WalkStrafingSpeedMultiplier.Value;
			if (CrouchWalkSpeedMultiplier.HasValue) def.CrouchWalkSpeedMultiplier = CrouchWalkSpeedMultiplier.Value;
			if (CrouchBackwalkSpeedMultiplier.HasValue) def.CrouchBackwalkSpeedMultiplier = CrouchBackwalkSpeedMultiplier.Value;
			if (CrouchStrafingSpeedMultiplier.HasValue) def.CrouchStrafingSpeedMultiplier = CrouchStrafingSpeedMultiplier.Value;
			if (AimingSpeedMultiplier.HasValue) def.AimingSpeedMultiplier = AimingSpeedMultiplier.Value;
			if (WeaponType.HasValue) def.WeaponType = WeaponType.Value;
		}

		public MyItemPositioningEnum? ItemPositioning;

		public MyItemPositioningEnum? ItemPositioning3rd;

		public MyItemPositioningEnum? ItemPositioningWalk;

		public MyItemPositioningEnum? ItemPositioningWalk3rd;

		public MyItemPositioningEnum? ItemPositioningShoot;

		public MyItemPositioningEnum? ItemPositioningShoot3rd;

		public MyItemPositioningEnum? ItemPositioningIronsight;

		public MyItemPositioningEnum? ItemPositioningIronsight3rd;

		public float? SprintSpeedMultiplier;

		public float? RunSpeedMultiplier;

		public float? BackrunSpeedMultiplier;

		public float? RunStrafingSpeedMultiplier;

		public float? WalkSpeedMultiplier;

		public float? BackwalkSpeedMultiplier;

		public float? WalkStrafingSpeedMultiplier;

		public float? CrouchWalkSpeedMultiplier;

		public float? CrouchBackwalkSpeedMultiplier;

		public float? CrouchStrafingSpeedMultiplier;

		public float? AimingSpeedMultiplier;

		public MyItemWeaponType? WeaponType;
    }

	[XmlInclude(typeof(AngleGrinderDefinition))]
	[XmlInclude(typeof(HandDrillDefinition))]
	[XmlInclude(typeof(WelderDefinition))]
	public class EngineerToolBaseDefinition : HandItemDefinition
    {
		public float? SpeedMultiplier;

		public float? DistanceMultiplier;

		public string Flare;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyEngineerToolBaseDefinition;

			if (SpeedMultiplier.HasValue) def.SpeedMultiplier = SpeedMultiplier.Value;
			if (DistanceMultiplier.HasValue) def.DistanceMultiplier = DistanceMultiplier.Value;
			if (!string.IsNullOrEmpty(Flare)) def.Flare = Flare;
        }
    }

	public class AngleGrinderDefinition : EngineerToolBaseDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

	public class HandDrillDefinition : EngineerToolBaseDefinition
    {
		public float? HarvestRatioMultiplier;

		public Vector3D? ParticleOffset;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyHandDrillDefinition;

			if (HarvestRatioMultiplier.HasValue) def.HarvestRatioMultiplier = HarvestRatioMultiplier.Value;
			if (ParticleOffset.HasValue) def.ParticleOffset = ParticleOffset.Value;
        }
    }

	public class WelderDefinition : EngineerToolBaseDefinition
    {
		//inaccessible
		//public string FlameEffect;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
		}
    }
}
