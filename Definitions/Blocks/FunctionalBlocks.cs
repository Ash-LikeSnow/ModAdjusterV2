using ModAdjusterV2.Session;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Localization;
using Sandbox.Game.Weapons;
using SpaceEngineers.Game.Definitions.SafeZone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions.Blocks
{
    [XmlInclude(typeof(AdvancedDoorDefinition))]
    [XmlInclude(typeof(AirtightDoorGenericDefinition))]
    [XmlInclude(typeof(AirVentDefinition))]
    [XmlInclude(typeof(BasicMissionBlockDefinition))]
    [XmlInclude(typeof(BeaconDefinition))]
    [XmlInclude(typeof(ButtonPanelDefinition))]
    [XmlInclude(typeof(CameraBlockDefinition))]
    [XmlInclude(typeof(CargoContainerDefinition))]
    [XmlInclude(typeof(ContractBlockDefinition))]
    [XmlInclude(typeof(ConveyorSorterDefinition))]
    [XmlInclude(typeof(DecoyDefinition))]
    [XmlInclude(typeof(DefensiveCombatBlockDefinition))]
    [XmlInclude(typeof(DoorDefinition))]
    [XmlInclude(typeof(EmotionControllerBlockDefinition))]
    [XmlInclude(typeof(EventControllerBlockDefinition))]
    [XmlInclude(typeof(ExhaustBlockDefinition))]
    [XmlInclude(typeof(FlightMovementBlockDefinition))]
    [XmlInclude(typeof(GravityGeneratorBaseDefinition))]
    [XmlInclude(typeof(GyroDefinition))]
    [XmlInclude(typeof(HeatVentBlockDefinition))]
    [XmlInclude(typeof(JumpDriveDefinition))]
    [XmlInclude(typeof(KitchenDefinition))]
    [XmlInclude(typeof(LandingGearDefinition))]
    [XmlInclude(typeof(LaserAntennaDefinition))]
    [XmlInclude(typeof(LCDPanelsBlockDefinition))]
    [XmlInclude(typeof(LightingBlockDefinition))]
    [XmlInclude(typeof(MechanicalConnectionBlockBaseDefinition))]
    [XmlInclude(typeof(MedicalRoomDefinition))]
    [XmlInclude(typeof(MergeBlockDefinition))]
    [XmlInclude(typeof(MissileLauncherDefinition))]
    [XmlInclude(typeof(OffensiveCombatBlockDefinition))]
    [XmlInclude(typeof(OreDetectorDefinition))]
    [XmlInclude(typeof(OxygenFarmDefinition))]
    [XmlInclude(typeof(ParachuteDefinition))]
    [XmlInclude(typeof(PathRecorderBlockDefinition))]
    [XmlInclude(typeof(PlanterDefinition))]
    [XmlInclude(typeof(PowerProducerDefinition))]
    [XmlInclude(typeof(ProductionBlockDefinition))]
    [XmlInclude(typeof(ProgrammableBlockDefinition))]
    [XmlInclude(typeof(ProjectorDefinition))]
    [XmlInclude(typeof(RadioAntennaDefinition))]
    [XmlInclude(typeof(SafeZoneBlockDefinition))]
    [XmlInclude(typeof(SearchlightDefinition))]
    [XmlInclude(typeof(SensorBlockDefinition))]
    [XmlInclude(typeof(ShipConnectorDefinition))]
    [XmlInclude(typeof(ShipControllerDefinition))]
    [XmlInclude(typeof(ShipToolDefinition))]
    [XmlInclude(typeof(SoundBlockDefinition))]
    [XmlInclude(typeof(SpaceBallDefinition))]
    [XmlInclude(typeof(StoreBlockDefinition))]
    [XmlInclude(typeof(TargetDummyBlockDefinition))]
    [XmlInclude(typeof(TextPanelDefinition))]
    [XmlInclude(typeof(ThrustDefinition))]
    [XmlInclude(typeof(TimerBlockDefinition))]
    [XmlInclude(typeof(TurretControlBlockDefinition))]
    [XmlInclude(typeof(UpgradeModuleDefinition))]
    [XmlInclude(typeof(VirtualMassDefinition))]
    [XmlInclude(typeof(WeaponBlockDefinition))]
    public class FunctionalBlockDefinition : CubeBlockDefinition
    {
        public List<ScreenArea> ScreenAreas;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyFunctionalBlockDefinition;

            if (ScreenAreas != null && ScreenAreas.Count > 0)
                def.ScreenAreas = ScreenAreas.ToList();
        }
    }

    #region Doors

    public class AdvancedDoorDefinition : FunctionalBlockDefinition
    {
        public MyObjectBuilder_AdvancedDoorDefinition.SubpartDefinition[] Subparts;

        public MyObjectBuilder_AdvancedDoorDefinition.Opening[] OpeningSequence;

        public string ResourceSinkGroup;

        public float? PowerConsumptionIdle;

        public float? PowerConsumptionMoving;



        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyAdvancedDoorDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (PowerConsumptionIdle.HasValue) def.PowerConsumptionIdle = PowerConsumptionIdle.Value;
            if (PowerConsumptionMoving.HasValue) def.PowerConsumptionMoving = PowerConsumptionMoving.Value;
            if (Subparts != null) def.Subparts = Subparts;
            if (OpeningSequence != null) def.OpeningSequence = OpeningSequence;
        }
    }

    [XmlInclude(typeof(AirtightHangarDoorDefinition))]
    [XmlInclude(typeof(AirtightSlideDoorDefinition))]
    public class AirtightDoorGenericDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? PowerConsumptionIdle;

        public float? PowerConsumptionMoving;

        public float? OpeningSpeed;

        public string Sound;

        public string OpenSound;

        public string CloseSound;

        public float? SubpartMovementDistance;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyAirtightDoorGenericDefinition;

            def.ResourceSinkGroup = ResourceSinkGroup;
            if (PowerConsumptionIdle.HasValue) def.PowerConsumptionIdle = PowerConsumptionIdle.Value;
            if (PowerConsumptionMoving.HasValue) def.PowerConsumptionMoving = PowerConsumptionMoving.Value;
            if (OpeningSpeed.HasValue) def.OpeningSpeed = OpeningSpeed.Value;
            if (!string.IsNullOrEmpty(Sound)) def.Sound = Sound;
            if (!string.IsNullOrEmpty(OpenSound)) def.OpenSound = OpenSound;
            if (!string.IsNullOrEmpty(CloseSound)) def.CloseSound = CloseSound;
            if (SubpartMovementDistance.HasValue) def.SubpartMovementDistance = SubpartMovementDistance.Value;
        }
    }

    public class AirtightHangarDoorDefinition : AirtightDoorGenericDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class AirtightSlideDoorDefinition : AirtightDoorGenericDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    #endregion
    #region A
    public class AirVentDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string ResourceSourceGroup;

        public float? OperationalPowerConsumption;

        public float? StandbyPowerConsumption;

        public float? VentilationCapacityPerSecond;

        public string PressurizeSound;

        public string DepressurizeSound;

        public string IdleSound;

        public int? RotationSpeed;

        public float? SpinUpSpeed;

        public float? SpinDownSpeed;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyAirVentDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (!string.IsNullOrEmpty(ResourceSourceGroup)) def.ResourceSourceGroup = MyStringHash.GetOrCompute(ResourceSourceGroup);
            if (StandbyPowerConsumption.HasValue) def.StandbyPowerConsumption = StandbyPowerConsumption.Value;
            if (OperationalPowerConsumption.HasValue) def.OperationalPowerConsumption = OperationalPowerConsumption.Value;
            if (VentilationCapacityPerSecond.HasValue) def.VentilationCapacityPerSecond = VentilationCapacityPerSecond.Value;
            if (!string.IsNullOrEmpty(PressurizeSound)) def.PressurizeSound = new MySoundPair(PressurizeSound, true);
            if (!string.IsNullOrEmpty(DepressurizeSound)) def.DepressurizeSound = new MySoundPair(DepressurizeSound, true);
            if (!string.IsNullOrEmpty(IdleSound)) def.IdleSound = new MySoundPair(IdleSound, true);
            if (RotationSpeed.HasValue) def.RoationSpeed = RotationSpeed.Value;
            if (SpinUpSpeed.HasValue) def.SpinUpSpeed = SpinUpSpeed.Value;
            if (SpinDownSpeed.HasValue) def.SpinDownSpeed = SpinDownSpeed.Value;
        }
    }

    public class BasicMissionBlockDefinition : FunctionalBlockDefinition
    {
        public long? DefaultMissionSelectionId;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyBasicMissionBlockDefinition;

            if (DefaultMissionSelectionId.HasValue) def.DefaultMissionSelectionId = DefaultMissionSelectionId.Value;
        }
    }

    public class BeaconDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MaxBroadcastRadius;

        public string Flare;

        public float? MaxBroadcastPowerDrainkW;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyBeaconDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (MaxBroadcastRadius.HasValue) def.MaxBroadcastRadius = MaxBroadcastRadius.Value;
            if (!string.IsNullOrEmpty(Flare)) def.Flare = Flare;
            if (MaxBroadcastPowerDrainkW.HasValue) def.MaxBroadcastPowerDrainkW = MaxBroadcastPowerDrainkW.Value;
        }
    }

    public class ButtonPanelDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public int? ButtonCount;

        public string[] ButtonSymbols;

        public Vector4[] ButtonColors;

        public Vector4? UnassignedButtonColor;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyButtonPanelDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (ButtonCount.HasValue) def.ButtonCount = ButtonCount.Value;
            if (ButtonSymbols != null) def.ButtonSymbols = ButtonSymbols;
            if (ButtonColors != null) def.ButtonColors = ButtonColors;
            if (UnassignedButtonColor.HasValue) def.UnassignedButtonColor = UnassignedButtonColor.Value;
        }
    }

    public class CameraBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? RequiredChargingInput;

        public string OverlayTexture;

        public float? MinFov;

        public float? MaxFov;

        public float? RaycastConeLimit;

        public double? RaycastDistanceLimit;

        public float? RaycastTimeMultiplier;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyCameraBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (RequiredChargingInput.HasValue) def.RequiredChargingInput = RequiredChargingInput.Value;
            if (!string.IsNullOrEmpty(OverlayTexture)) def.OverlayTexture = OverlayTexture;
            if (MinFov.HasValue) def.MinFov = MinFov.Value;
            if (MaxFov.HasValue) def.MaxFov = MaxFov.Value;
            if (RaycastConeLimit.HasValue) def.RaycastConeLimit = RaycastConeLimit.Value;
            if (RaycastDistanceLimit.HasValue) def.RaycastDistanceLimit = RaycastDistanceLimit.Value;
            if (RaycastTimeMultiplier.HasValue) def.RaycastTimeMultiplier = RaycastTimeMultiplier.Value;
        }
    }
    #endregion
    #region Cargo
    [XmlInclude(typeof(PoweredCargoContainerDefinition))]
    public class CargoContainerDefinition : FunctionalBlockDefinition
    {
        public Vector3? InventorySize;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyCargoContainerDefinition;

            if (InventorySize.HasValue) def.InventorySize = InventorySize.Value;
        }
    }

    public class PoweredCargoContainerDefinition : CargoContainerDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyPoweredCargoContainerDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
        }
    }
    #endregion
    #region B
    public class ContractBlockDefinition : FunctionalBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class ConveyorSorterDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? PowerInput;

        public Vector3? InventorySize;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyConveyorSorterDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (PowerInput.HasValue) def.PowerInput = PowerInput.Value;
            if (InventorySize.HasValue) def.InventorySize = InventorySize.Value;
        }
    }

    public class DecoyDefinition : FunctionalBlockDefinition
    {
        public float? LightningRodRadiusLarge;

        public float? LightningRodRadiusSmall;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyDecoyDefinition;

            if (LightningRodRadiusLarge.HasValue) def.LightningRodRadiusLarge = LightningRodRadiusLarge.Value;
            if (LightningRodRadiusSmall.HasValue) def.LightningRodRadiusSmall = LightningRodRadiusSmall.Value;
        }
    }

    public class DefensiveCombatBlockDefinition : FunctionalBlockDefinition
    {
        public int? WaypointReachedZoneSizeMin;

        public int? WaypointReachedZoneSizeMax;

        public int? UpdateTargetIntervalDefault;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyDefensiveCombatBlockDefinition;

            if (WaypointReachedZoneSizeMin.HasValue) def.WaypointReachedZoneSizeMin = WaypointReachedZoneSizeMin.Value;
            if (WaypointReachedZoneSizeMax.HasValue) def.WaypointReachedZoneSizeMax = WaypointReachedZoneSizeMax.Value;
            if (UpdateTargetIntervalDefault.HasValue) def.UpdateTargetIntervalDefault = UpdateTargetIntervalDefault.Value;
        }
    }

    public class DoorDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MaxOpen;

        public string OpenSound;

        public string CloseSound;

        public float? OpeningSpeed;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyDoorDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (MaxOpen.HasValue) def.MaxOpen = MaxOpen.Value;
            if (!string.IsNullOrEmpty(OpenSound)) def.OpenSound = OpenSound;
            if (!string.IsNullOrEmpty(CloseSound)) def.CloseSound = CloseSound;
            if (OpeningSpeed.HasValue) def.OpeningSpeed = OpeningSpeed.Value;
        }
    }

    public class EmotionControllerBlockDefinition : FunctionalBlockDefinition
    {
        public float? RequiredPowerInput;

        public string ResourceSinkGroup;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyEmotionControllerBlockDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }

    public class EventControllerBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyEventControllerBlockDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }

    public class ExhaustBlockDefinition : FunctionalBlockDefinition
    {
        public float? RequiredPowerInput;

        public string[] AvailableEffects;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyExhaustBlockDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (AvailableEffects != null && AvailableEffects.Length > 0) def.AvailableEffects = AvailableEffects.ToList();
        }
    }

    public class FlightMovementBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyFlightMovementBlockDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }
    #endregion
    #region Gravity
    [XmlInclude(typeof(GravityGeneratorDefinition))]
    [XmlInclude(typeof(GravityGeneratorSphereDefinition))]
    public class GravityGeneratorBaseDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MinGravityAcceleration;

        public float? MaxGravityAcceleration;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGravityGeneratorBaseDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (MinGravityAcceleration.HasValue) def.MinGravityAcceleration = MinGravityAcceleration.Value;
            if (MaxGravityAcceleration.HasValue) def.MaxGravityAcceleration = MaxGravityAcceleration.Value;
        }
    }

    public class GravityGeneratorDefinition : GravityGeneratorBaseDefinition
    {
        public float? RequiredPowerInput;

        public SerializableVector3? MinFieldSize;

        public SerializableVector3? MaxFieldSize;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGravityGeneratorDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (MinFieldSize.HasValue) def.MinFieldSize = MinFieldSize.Value;
            if (MaxFieldSize.HasValue) def.MaxFieldSize = MaxFieldSize.Value;
        }
    }

    public class GravityGeneratorSphereDefinition : GravityGeneratorBaseDefinition
    {
        public float? MinRadius;

        public float? MaxRadius;

        public float? BasePowerInput;

        public float? ConsumptionPower;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGravityGeneratorSphereDefinition;

            if (MinRadius.HasValue) def.MinRadius = MinRadius.Value;
            if (MaxRadius.HasValue) def.MaxRadius = MaxRadius.Value;
            if (BasePowerInput.HasValue) def.BasePowerInput = BasePowerInput.Value;
            if (ConsumptionPower.HasValue) def.ConsumptionPower = ConsumptionPower.Value;
        }
    }
    #endregion
    #region C
    public class GyroDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? ForceMagnitude;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGyroDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (ForceMagnitude.HasValue) def.ForceMagnitude = ForceMagnitude.Value;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
        }
    }

    public class HeatVentBlockDefinition : FunctionalBlockDefinition
    {
        public float? PowerDependency;

        public ColorDefinitionRGBA? ColorMinimalPower;

        public ColorDefinitionRGBA? ColorMaximalPower;

        public float? RequiredPowerInput;

        [XmlArrayItem("SubpartRotation")]
        public MyObjectBuilder_HeatVentBlockDefinition.SubpartRotation[] SubpartRotations;

        public string EmissiveMaterialName;

        public string LightDummyName;

        public SerializableBounds? LightFalloffBounds;

        public SerializableBounds? LightIntensityBounds;

        public SerializableBounds? LightRadiusBounds;

        public SerializableBounds? LightOffsetBounds;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyHeatVentBlockDefinition;

            if (PowerDependency.HasValue) def.PowerDependency = PowerDependency.Value;
            if (ColorMinimalPower.HasValue) def.ColorMinimalPower = ColorMinimalPower.Value;
            if (ColorMaximalPower.HasValue) def.ColorMaximalPower = ColorMaximalPower.Value;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (SubpartRotations != null) def.SubpartRotations = SubpartRotations;
            if (!string.IsNullOrEmpty(EmissiveMaterialName)) def.EmissiveMaterialName = EmissiveMaterialName;
            if (!string.IsNullOrEmpty(LightDummyName)) def.LightDummyName = LightDummyName;
            if (LightFalloffBounds.HasValue) def.LightFalloffBounds = LightFalloffBounds.Value;
            if (LightIntensityBounds.HasValue) def.LightIntensityBounds = LightIntensityBounds.Value;
            if (LightRadiusBounds.HasValue) def.LightRadiusBounds = LightRadiusBounds.Value;
            if (LightOffsetBounds.HasValue) def.LightOffsetBounds = LightOffsetBounds.Value;
        }
    }

    public class JumpDriveDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? PowerNeededForJump;

        public double? MaxJumpDistance;

        public double? MinJumpDistance;

        public double? MaxJumpMass;

        public float? PowerEfficiency;

        public string ShipJumpDriveChargingSound;

        public string ShipJumpDriveJumpInSound;

        public string ShipJumpDriveJumpOutSound;

        public string JumpParticleEffect;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyJumpDriveDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (PowerNeededForJump.HasValue) def.PowerNeededForJump = PowerNeededForJump.Value;
            if (MaxJumpDistance.HasValue) def.MaxJumpDistance = MaxJumpDistance.Value;
            if (MinJumpDistance.HasValue) def.MinJumpDistance = MinJumpDistance.Value;
            if (MaxJumpMass.HasValue) def.MaxJumpMass = MaxJumpMass.Value;
            if (PowerEfficiency.HasValue) def.PowerEfficiency = PowerEfficiency.Value;

            if (!string.IsNullOrEmpty(ShipJumpDriveChargingSound)) def.ChargingSound = new MySoundPair(ShipJumpDriveChargingSound, true);
            if (!string.IsNullOrEmpty(ShipJumpDriveJumpInSound)) def.JumpInSound = new MySoundPair(ShipJumpDriveJumpInSound, true);
            if (!string.IsNullOrEmpty(ShipJumpDriveJumpOutSound)) def.JumpOutSound = new MySoundPair(ShipJumpDriveJumpOutSound, true);
            if (!string.IsNullOrEmpty(JumpParticleEffect)) def.JumpParticleEffect = JumpParticleEffect;
        }
    }

    public class KitchenDefinition : FunctionalBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class LandingGearDefinition : FunctionalBlockDefinition
    {
        public string LockSound;

        public string UnlockSound;

        public string FailedAttachSound;

        public float? MaxLockSeparatingVelocity;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyLandingGearDefinition;

            if (!string.IsNullOrEmpty(LockSound)) def.LockSound = LockSound;
            if (!string.IsNullOrEmpty(UnlockSound)) def.UnlockSound = UnlockSound;
            if (!string.IsNullOrEmpty(FailedAttachSound)) def.FailedAttachSound = FailedAttachSound;
            if (MaxLockSeparatingVelocity.HasValue) def.MaxLockSeparatingVelocity = MaxLockSeparatingVelocity.Value;
        }
    }

    public class LaserAntennaDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? PowerInputIdle;

        public float? PowerInputTurning;

        public float? PowerInputLasing;

        public float? RotationRate;

        public float? MaxRange;

        public bool? RequireLineOfSight;

        public int? MinElevationDegrees;

        public int? MaxElevationDegrees;

        public int? MinAzimuthDegrees;

        public int? MaxAzimuthDegrees;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyLaserAntennaDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (PowerInputIdle.HasValue) def.PowerInputIdle = PowerInputIdle.Value;
            if (PowerInputTurning.HasValue) def.PowerInputTurning = PowerInputTurning.Value;
            if (PowerInputLasing.HasValue) def.PowerInputLasing = PowerInputLasing.Value;
            if (RotationRate.HasValue) def.RotationRate = RotationRate.Value;
            if (MaxRange.HasValue) def.MaxRange = MaxRange.Value;
            if (RequireLineOfSight.HasValue) def.RequireLineOfSight = RequireLineOfSight.Value;
            if (MinElevationDegrees.HasValue) def.MinElevationDegrees = MinElevationDegrees.Value;
            if (MaxElevationDegrees.HasValue) def.MaxElevationDegrees = MaxElevationDegrees.Value;
            if (MinAzimuthDegrees.HasValue) def.MinAzimuthDegrees = MinAzimuthDegrees.Value;
            if (MaxAzimuthDegrees.HasValue) def.MaxAzimuthDegrees = MaxAzimuthDegrees.Value;
        }
    }

    public class LCDPanelsBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyLCDPanelsBlockDefinition;

            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }
    #endregion
    #region Light
    [XmlInclude(typeof(ReflectorBlockDefinition))]
    public class LightingBlockDefinition : FunctionalBlockDefinition
    {
        public SerializableBounds? LightRadius;

        public SerializableBounds? LightReflectorRadius;

        public SerializableBounds? LightFalloff;

        public SerializableBounds? LightIntensity;

        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public string Flare;

        public SerializableBounds? LightBlinkIntervalSeconds;

        public SerializableBounds? LightBlinkLenght;

        public SerializableBounds? LightBlinkOffset;

        public SerializableBounds? LightOffset;

        public string PointLightEmissiveMaterial;

        public string SpotLightEmissiveMaterial;

        public string LightDummyName;

        public string LightOnlyNoEffectsDummyName;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyLightingBlockDefinition;

            if (LightRadius.HasValue) def.LightRadius = LightRadius.Value;
            if (LightReflectorRadius.HasValue) def.LightReflectorRadius = LightReflectorRadius.Value;
            if (LightFalloff.HasValue) def.LightFalloff = LightFalloff.Value;
            if (LightIntensity.HasValue) def.LightIntensity = LightIntensity.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(Flare)) def.Flare = Flare;
            if (LightBlinkIntervalSeconds.HasValue) def.BlinkIntervalSeconds = LightBlinkIntervalSeconds.Value;
            if (LightBlinkLenght.HasValue) def.BlinkLenght = LightBlinkLenght.Value;
            if (LightBlinkOffset.HasValue) def.BlinkOffset = LightBlinkOffset.Value;
            if (LightOffset.HasValue) def.LightOffset = LightOffset.Value;
            if (!string.IsNullOrEmpty(PointLightEmissiveMaterial)) def.PointLightEmissiveMaterial = PointLightEmissiveMaterial;
            if (!string.IsNullOrEmpty(SpotLightEmissiveMaterial)) def.SpotLightEmissiveMaterial = SpotLightEmissiveMaterial;
            if (!string.IsNullOrEmpty(LightDummyName)) def.LightDummyName = LightDummyName;
            if (!string.IsNullOrEmpty(LightOnlyNoEffectsDummyName)) def.LightOnlyNoEffectsDummyName = LightOnlyNoEffectsDummyName;
        }
    }

    public class ReflectorBlockDefinition : LightingBlockDefinition
    {
        public string ReflectorTexture;

        public string ReflectorConeMaterial;

        public float? ReflectorThickness;

        public float? ReflectorConeDegrees;

        public SerializableBounds? RotationSpeedBounds;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyReflectorBlockDefinition;

            if (!string.IsNullOrEmpty(ReflectorTexture)) def.ReflectorTexture = ReflectorTexture;
            if (!string.IsNullOrEmpty(ReflectorConeMaterial)) def.ReflectorConeMaterial = ReflectorConeMaterial;
            if (ReflectorThickness.HasValue) def.ReflectorThickness = ReflectorThickness.Value;
            if (ReflectorConeDegrees.HasValue) def.ReflectorConeDegrees = ReflectorConeDegrees.Value;
            if (RotationSpeedBounds.HasValue) def.RotationSpeedBounds = RotationSpeedBounds.Value;
        }
    }
    #endregion
    #region Mechanical
    [XmlInclude(typeof(MotorStatorDefinition))]
    [XmlInclude(typeof(PistonBaseDefinition))]
    public class MechanicalConnectionBlockBaseDefinition : FunctionalBlockDefinition
    {
        public string RotorPart;

        public string TopPart;

        public string MediumTopPart;

        public float? SafetyDetach;

        public float? SafetyDetachMin;

        public float? SafetyDetachMax;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMechanicalConnectionBlockBaseDefinition;

            var part = TopPart ?? RotorPart;
            if (!string.IsNullOrEmpty(part)) def.TopPart = part;
            if (!string.IsNullOrEmpty(MediumTopPart)) def.MediumTopPart = MediumTopPart;
            if (SafetyDetach.HasValue) def.SafetyDetach = SafetyDetach.Value;
            if (SafetyDetachMin.HasValue) def.SafetyDetachMin = SafetyDetachMin.Value;
            if (SafetyDetachMax.HasValue) def.SafetyDetachMax = SafetyDetachMax.Value;
        }
    }

    [XmlInclude(typeof(MotorAdvancedStatorDefinition))]
    [XmlInclude(typeof(MotorSuspensionDefinition))]
    public class MotorStatorDefinition : MechanicalConnectionBlockBaseDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? MaxForceMagnitude;

        public float? RotorDisplacementMin;

        public float? RotorDisplacementMax;

        public float? RotorDisplacementMinSmall;

        public float? RotorDisplacementMaxSmall;

        public float? RotorDisplacementInModel;

        public float? DangerousTorqueThreshold;

        public float? MinAngleDeg;

        public float? MaxAngleDeg;

        public MyRotorType? RotorType;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMotorStatorDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (MaxForceMagnitude.HasValue) def.MaxForceMagnitude = MaxForceMagnitude.Value;
            if (RotorDisplacementMin.HasValue) def.RotorDisplacementMin = RotorDisplacementMin.Value;
            if (RotorDisplacementMax.HasValue) def.RotorDisplacementMax = RotorDisplacementMax.Value;
            if (RotorDisplacementMinSmall.HasValue) def.RotorDisplacementMinSmall = RotorDisplacementMinSmall.Value;
            if (RotorDisplacementMaxSmall.HasValue) def.RotorDisplacementMaxSmall = RotorDisplacementMaxSmall.Value;
            if (RotorDisplacementInModel.HasValue) def.RotorDisplacementInModel = RotorDisplacementInModel.Value;
            if (DangerousTorqueThreshold.HasValue) def.UnsafeTorqueThreshold = DangerousTorqueThreshold.Value;
            if (MinAngleDeg.HasValue) def.MinAngleDeg = MinAngleDeg.Value;
            if (MaxAngleDeg.HasValue) def.MaxAngleDeg = MaxAngleDeg.Value;
            if (RotorType.HasValue) def.RotorType = RotorType.Value;
        }
    }

    public class MotorAdvancedStatorDefinition : MotorStatorDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class MotorSuspensionDefinition : MotorStatorDefinition
    {
        public float? MaxSteer;

        public float? SteeringSpeed;

        public float? PropulsionForce;

        public float? MinHeight;

        public float? MaxHeight;

        public float? AxleFriction;

        public float? AirShockMinSpeed;

        public float? AirShockMaxSpeed;

        public int? AirShockActivationDelay;

        public SoundDefinitionIdWrapper SoundDefinitionId;

        public float? RequiredIdlePowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMotorSuspensionDefinition;

            if (MaxSteer.HasValue) def.MaxSteer = MaxSteer.Value;
            if (SteeringSpeed.HasValue) def.SteeringSpeed = SteeringSpeed.Value;
            if (PropulsionForce.HasValue) def.PropulsionForce = PropulsionForce.Value;
            if (MinHeight.HasValue) def.MinHeight = MinHeight.Value;
            if (MaxHeight.HasValue) def.MaxHeight = MaxHeight.Value;
            if (AxleFriction.HasValue) def.AxleFriction = AxleFriction.Value;
            if (AirShockMinSpeed.HasValue) def.AirShockMinSpeed = AirShockMinSpeed.Value;
            if (AirShockMaxSpeed.HasValue) def.AirShockMaxSpeed = AirShockMaxSpeed.Value;
            if (AirShockActivationDelay.HasValue) def.AirShockActivationDelay = AirShockActivationDelay.Value;
            if (RequiredIdlePowerInput.HasValue) def.RequiredIdlePowerInput = RequiredIdlePowerInput.Value;

            if (SoundDefinitionId != null)
            {
                MyDefinitionId id;
                if (MyDefinitionId.TryParse(SoundDefinitionId.DefinitionTypeName, SoundDefinitionId.DefinitionSubtypeName, out id))
                    def.SoundDefinitionId = id;
            }
        }
    }

    [XmlInclude(typeof(ExtendedPistonBaseDefinition))]
    public class PistonBaseDefinition : MechanicalConnectionBlockBaseDefinition
    {
        public float? Minimum;

        public float? Maximum;

        public float? MaxVelocity;

        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? MaxImpulse;

        public float? DefaultMaxImpulseAxis;

        public float? DefaultMaxImpulseNonAxis;

        public float? DangerousImpulseThreshold;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyPistonBaseDefinition;

            if (Minimum.HasValue) def.Minimum = Minimum.Value;
            if (Maximum.HasValue) def.Maximum = Maximum.Value;
            if (MaxVelocity.HasValue) def.MaxVelocity = MaxVelocity.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (MaxImpulse.HasValue) def.MaxImpulse = MaxImpulse.Value;
            if (DefaultMaxImpulseAxis.HasValue) def.DefaultMaxImpulseAxis = DefaultMaxImpulseAxis.Value;
            if (DefaultMaxImpulseNonAxis.HasValue) def.DefaultMaxImpulseNonAxis = DefaultMaxImpulseNonAxis.Value;
            if (DangerousImpulseThreshold.HasValue) def.UnsafeImpulseThreshold = DangerousImpulseThreshold.Value;
        }
    }

    public class ExtendedPistonBaseDefinition : PistonBaseDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }
    #endregion
    #region D
    public class MedicalRoomDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string IdleSound;

        public string ProgressSound;

        public bool? RespawnAllowed;

        public bool? HealingAllowed;

        public bool? RefuelAllowed;

        public bool? SuitChangeAllowed;

        public bool? CustomWardrobesEnabled;

        public bool? ForceSuitChangeOnRespawn;

        public bool? SpawnWithoutOxygenEnabled;

        public string RespawnSuitName;

        public Vector3D? WardrobeCharacterOffset;

        [XmlArrayItem("Name")]
        public string[] CustomWardRobeNames;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMedicalRoomDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (!string.IsNullOrEmpty(IdleSound)) def.IdleSound = IdleSound;
            if (!string.IsNullOrEmpty(ProgressSound)) def.ProgressSound = ProgressSound;
            if (RespawnAllowed.HasValue) def.RespawnAllowed = RespawnAllowed.Value;
            if (HealingAllowed.HasValue) def.HealingAllowed = HealingAllowed.Value;
            if (RefuelAllowed.HasValue) def.RefuelAllowed = RefuelAllowed.Value;
            if (SuitChangeAllowed.HasValue) def.SuitChangeAllowed = SuitChangeAllowed.Value;
            if (CustomWardrobesEnabled.HasValue) def.CustomWardrobesEnabled = CustomWardrobesEnabled.Value;
            if (ForceSuitChangeOnRespawn.HasValue) def.ForceSuitChangeOnRespawn = ForceSuitChangeOnRespawn.Value;
            if (SpawnWithoutOxygenEnabled.HasValue) def.SpawnWithoutOxygenEnabled = SpawnWithoutOxygenEnabled.Value;
            if (!string.IsNullOrEmpty(RespawnSuitName)) def.RespawnSuitName = RespawnSuitName;

            if (WardrobeCharacterOffset.HasValue)
            {
                def.WardrobeCharacterOffset = WardrobeCharacterOffset.Value;
                def.WardrobeCharacterOffsetLength = (float)WardrobeCharacterOffset.Value.Length();
            }

            if (CustomWardRobeNames != null) def.CustomWardrobeNames = new HashSet<string>(CustomWardRobeNames);
        }
    }

    public class MergeBlockDefinition : FunctionalBlockDefinition
    {
        public float? Strength;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMergeBlockDefinition;

            if (Strength.HasValue) def.Strength = Strength.Value;
        }
    }

    public class MissileLauncherDefinition : FunctionalBlockDefinition
    {
        public string ProjectileMissile;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyMissileLauncherDefinition;

            if (!string.IsNullOrEmpty(ProjectileMissile)) def.ProjectileMissile = ProjectileMissile;
        }
    }

    public class OffensiveCombatBlockDefinition : FunctionalBlockDefinition
    {
        public int? UpdateTargetIntervalDefault;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyOffensiveCombatBlockDefinition;

            if (UpdateTargetIntervalDefault.HasValue) def.UpdateTargetIntervalDefault = UpdateTargetIntervalDefault.Value;
        }
    }

    public class OreDetectorDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MaximumRange;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyOreDetectorDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (MaximumRange.HasValue) def.MaximumRange = MaximumRange.Value;
        }
    }

    public class OxygenFarmDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string ResourceSourceGroup;

        public Vector3? PanelOrientation;

        public bool? TwoSidedPanel;

        public float? PanelOffset;

        public MyObjectBuilder_OxygenFarmDefinition.MyProducedGasInfo? ProducedGas;

        public float? OperationalPowerConsumption;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyOxygenFarmDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (!string.IsNullOrEmpty(ResourceSourceGroup)) def.ResourceSourceGroup = MyStringHash.GetOrCompute(ResourceSourceGroup);
            if (PanelOrientation.HasValue) def.PanelOrientation = PanelOrientation.Value;
            if (TwoSidedPanel.HasValue) def.IsTwoSided = TwoSidedPanel.Value;
            if (PanelOffset.HasValue) def.PanelOffset = PanelOffset.Value;

            if (ProducedGas.HasValue)
            {
                var producedGas = ProducedGas.Value;
                MyDefinitionId id;
                if (producedGas.Id.IsNull())
                {
                    id = new MyDefinitionId(typeof(MyObjectBuilder_GasProperties), "Oxygen");
                }
                else
                {
                    id = producedGas.Id;
                }
                def.ProducedGas = id;
                def.MaxGasOutput = producedGas.MaxOutputPerSecond;
            }

            if (OperationalPowerConsumption.HasValue) def.OperationalPowerConsumption = OperationalPowerConsumption.Value;
        }
    }

    public class ParachuteDefinition : FunctionalBlockDefinition
    {
        //public MyObjectBuilder_ParachuteDefinition.SubpartDefinition[] Subparts;

        //public MyObjectBuilder_ParachuteDefinition.Opening[] OpeningSequence;

        public string ResourceSinkGroup;

        public float? PowerConsumptionIdle;

        public float? PowerConsumptionMoving;

        public string ParachuteSubpartName;

        public float? DragCoefficient;

        public int? MaterialDeployCost;

        public string MaterialSubtype;

        public float? ReefAtmosphereLevel;

        public float? MinimumAtmosphereLevel;

        public float? RadiusMultiplier;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyParachuteDefinition;

            //if (Subparts != null) def.Subparts = Subparts;
            //if (OpeningSequence != null) def.OpeningSequence = OpeningSequence;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (PowerConsumptionIdle.HasValue) def.PowerConsumptionIdle = PowerConsumptionIdle.Value;
            if (PowerConsumptionMoving.HasValue) def.PowerConsumptionMoving = PowerConsumptionMoving.Value;
            if (!string.IsNullOrEmpty(ParachuteSubpartName)) def.ParachuteSubpartName = ParachuteSubpartName;
            if (DragCoefficient.HasValue) def.DragCoefficient = DragCoefficient.Value;
            if (MaterialDeployCost.HasValue) def.MaterialDeployCost = MaterialDeployCost.Value;
            if (!string.IsNullOrEmpty(MaterialSubtype)) def.MaterialDefinitionId = new MyDefinitionId(typeof(MyObjectBuilder_Component), MaterialSubtype);
            if (ReefAtmosphereLevel.HasValue) def.ReefAtmosphereLevel = ReefAtmosphereLevel.Value;
            if (MinimumAtmosphereLevel.HasValue) def.MinimumAtmosphereLevel = MinimumAtmosphereLevel.Value;
            if (RadiusMultiplier.HasValue) def.RadiusMultiplier = RadiusMultiplier.Value;
        }
    }

    public class PathRecorderBlockDefinition : FunctionalBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class PlanterDefinition : FunctionalBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }
    #endregion
    #region Power
    [XmlInclude(typeof(BatteryBlockDefinition))]
    [XmlInclude(typeof(FueledPowerProducerDefinition))]
    [XmlInclude(typeof(SolarPanelDefinition))]
    [XmlInclude(typeof(WindTurbineDefinition))]
    public class PowerProducerDefinition : FunctionalBlockDefinition
    {
        public string ResourceSourceGroup;

        public float? MaxPowerOutput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyPowerProducerDefinition;

            if (!string.IsNullOrEmpty(ResourceSourceGroup)) def.ResourceSourceGroup = MyStringHash.GetOrCompute(ResourceSourceGroup);
            if (MaxPowerOutput.HasValue) def.MaxPowerOutput = MaxPowerOutput.Value;
        }
    }

    public class BatteryBlockDefinition : PowerProducerDefinition
    {
        public float? MaxStoredPower;

        public float? InitialStoredPowerRatio;

        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public bool? AdaptibleInput;

        public float? RechargeMultiplier;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyBatteryBlockDefinition;

            if (MaxStoredPower.HasValue) def.MaxStoredPower = MaxStoredPower.Value;
            if (InitialStoredPowerRatio.HasValue) def.InitialStoredPowerRatio = InitialStoredPowerRatio.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (AdaptibleInput.HasValue) def.AdaptibleInput = AdaptibleInput.Value;
            if (RechargeMultiplier.HasValue) def.RechargeMultiplier = RechargeMultiplier.Value;
        }
    }

    [XmlInclude(typeof(GasFueledPowerProducerDefinition))]
    [XmlInclude(typeof(ReactorDefinition))]
    public class FueledPowerProducerDefinition : PowerProducerDefinition
    {
        public float? FuelProductionToCapacityMultiplier;

        public List<MyObjectBuilder_FueledPowerProducerDefinition.FuelInfo> FuelInfos;

        public string ResourceSinkGroup;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyFueledPowerProducerDefinition;

            if (FuelProductionToCapacityMultiplier.HasValue) def.FuelProductionToCapacityMultiplier = FuelProductionToCapacityMultiplier.Value;
        }
    }

    [XmlInclude(typeof(HydrogenEngineDefinition))]
    public class GasFueledPowerProducerDefinition : FueledPowerProducerDefinition
    {
        public float? FuelCapacity;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGasFueledPowerProducerDefinition;

            if (FuelCapacity.HasValue) def.FuelCapacity = FuelCapacity.Value;
            if (FuelInfos != null && FuelInfos.Count > 0) def.Fuel = new MyGasFueledPowerProducerDefinition.FuelInfo(FuelInfos[0]);
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }

    public class HydrogenEngineDefinition : GasFueledPowerProducerDefinition
    {
        public float? AnimationSpeed;

        public float? PistonAnimationMin;

        public float? PistonAnimationMax;

        public float[] PistonAnimationOffsets;

        public float? AnimationSpinUpSpeed;

        public float? AnimationSpinDownSpeed;

        public float? AnimationVisibilityDistance;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyHydrogenEngineDefinition;

            if (AnimationSpeed.HasValue) def.AnimationSpeed = AnimationSpeed.Value;
            if (PistonAnimationMin.HasValue) def.PistonAnimationMin = PistonAnimationMin.Value;
            if (PistonAnimationMax.HasValue) def.PistonAnimationMax = PistonAnimationMax.Value;
            if (PistonAnimationOffsets != null) def.PistonAnimationOffsets = PistonAnimationOffsets;
            if (AnimationSpinUpSpeed.HasValue) def.AnimationSpinUpSpeed = AnimationSpinUpSpeed.Value;
            if (AnimationSpinDownSpeed.HasValue) def.AnimationSpinDownSpeed = AnimationSpinDownSpeed.Value;
            if (AnimationVisibilityDistance.HasValue) def.AnimationVisibilityDistanceSq = AnimationVisibilityDistance.Value * AnimationVisibilityDistance.Value;
        }
    }

    public class ReactorDefinition : FueledPowerProducerDefinition
    {
        public Vector3? InventorySize;

        public SerializableDefinitionId? FuelId;

        public float? InventoryFillFactorMin;

        public float? InventoryFillFactorMax;

        public float? FuelPullAmountFromConveyorInMinutes;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyReactorDefinition;

            if (InventorySize.HasValue)
            {
                var inventorySize = InventorySize.Value;
                def.InventorySize = inventorySize;
                def.InventoryMaxVolume = inventorySize.X * inventorySize.Y * inventorySize.Z;
            }

            if (InventoryFillFactorMin.HasValue) def.InventoryFillFactorMin = InventoryFillFactorMin.Value;
            if (InventoryFillFactorMax.HasValue) def.InventoryFillFactorMax = InventoryFillFactorMax.Value;
            if (FuelPullAmountFromConveyorInMinutes.HasValue) def.FuelPullAmountFromConveyorInMinutes = FuelPullAmountFromConveyorInMinutes.Value;

            def.InventoryConstraint = new MyInventoryConstraint(string.Format(MyTexts.GetString(MySpaceTexts.ToolTipItemFilter_GenericProductionBlockInput), def.DisplayNameText), null, true);

            if (!FuelId.HasValue && (FuelInfos == null || FuelInfos.Count == 0))
                return;

            var list = FuelInfos ?? new List<MyObjectBuilder_FueledPowerProducerDefinition.FuelInfo>();
            if (list.Count == 0 && def.FuelInfos.Length > 0)
            {
                for (int i = 0; i < def.FuelInfos.Length; i++)
                {
                    var fuel = def.FuelInfos[i];
                    var info = new MyObjectBuilder_FueledPowerProducerDefinition.FuelInfo()
                    {
                        Id = fuel.FuelId,
                        Ratio = fuel.Ratio,
                    };
                    list.Add(info);
                }
            }

            if (FuelId.HasValue)
            {
                list = new List<MyObjectBuilder_FueledPowerProducerDefinition.FuelInfo>(list)
                {
                    new MyObjectBuilder_FueledPowerProducerDefinition.FuelInfo
                    {
                        Ratio = 1f,
                        Id = FuelId.Value
                    }
                };
            }

            def.FuelInfos = new MyReactorDefinition.FuelInfo[list.Count];
            def.InventoryConstraint.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                var fuelInfo = list[i];
                def.InventoryConstraint.Add(fuelInfo.Id);
                def.FuelInfos[i] = new MyReactorDefinition.FuelInfo(fuelInfo, def);
            }
        }
    }

    public class SolarPanelDefinition : PowerProducerDefinition
    {
        public Vector3? PanelOrientation;

        public bool? TwoSidedPanel;

        public float? PanelOffset;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySolarPanelDefinition;

            if (PanelOrientation.HasValue) def.PanelOrientation = PanelOrientation.Value;
            if (TwoSidedPanel.HasValue) def.IsTwoSided = TwoSidedPanel.Value;
            if (PanelOffset.HasValue) def.PanelOffset = PanelOffset.Value;
        }
    }

    public class WindTurbineDefinition : PowerProducerDefinition
    {
        public int? RaycasterSize;

        public int? RaycastersCount;

        public float? MinRaycasterClearance;
        
        public float? RaycastersToFullEfficiency;

        public float? OptimalWindSpeed;

        public float? TurbineSpinUpSpeed;

        public float? TurbineSpinDownSpeed;

        public float? TurbineRotationSpeed;

        public float? OptimalGroundClearance;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyWindTurbineDefinition;

            if (RaycasterSize.HasValue) def.RaycasterSize = RaycasterSize.Value;
            if (RaycastersCount.HasValue) def.RaycastersCount = RaycastersCount.Value;
            if (MinRaycasterClearance.HasValue) def.MinRaycasterClearance = MinRaycasterClearance.Value;
            if (RaycastersToFullEfficiency.HasValue) def.RaycastersToFullEfficiency = RaycastersToFullEfficiency.Value;
            if (OptimalWindSpeed.HasValue) def.OptimalWindSpeed = OptimalWindSpeed.Value;
            if (OptimalGroundClearance.HasValue) def.OptimalGroundClearance = OptimalGroundClearance.Value;
            if (TurbineSpinUpSpeed.HasValue) def.TurbineSpinUpSpeed = TurbineSpinUpSpeed.Value;
            if (TurbineSpinDownSpeed.HasValue) def.TurbineSpinDownSpeed = TurbineSpinDownSpeed.Value;
            if (TurbineRotationSpeed.HasValue) def.TurbineRotationSpeed = TurbineRotationSpeed.Value;
        }
    }
    #endregion
    #region Production
    [XmlInclude(typeof(AssemblerDefinition))]
    [XmlInclude(typeof(GasTankDefinition))]
    [XmlInclude(typeof(OxygenGeneratorDefinition))]
    [XmlInclude(typeof(RefineryDefinition))]
    public class ProductionBlockDefinition : FunctionalBlockDefinition
    {
        public float? InventoryMaxVolume;

        public Vector3? InventorySize;

        public string ResourceSinkGroup;

        public float? StandbyPowerConsumption;

        public float? OperationalPowerConsumption;

        [XmlArrayItem("Class")]
        public string[] BlueprintClasses;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyProductionBlockDefinition;

            if (InventoryMaxVolume.HasValue) def.InventoryMaxVolume = InventoryMaxVolume.Value;
            if (InventorySize.HasValue) def.InventorySize = InventorySize.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (StandbyPowerConsumption.HasValue) def.StandbyPowerConsumption = StandbyPowerConsumption.Value;
            if (OperationalPowerConsumption.HasValue) def.OperationalPowerConsumption = OperationalPowerConsumption.Value;

            if (BlueprintClasses != null && BlueprintClasses.Length > 0)
            {
                def.BlueprintClasses.Clear();
                foreach (var className in BlueprintClasses)
                {
                    var blueprintClass = MyDefinitionManager.Static.GetBlueprintClass(className);
                    if (blueprintClass != null)
                    {
                        def.BlueprintClasses.Add(blueprintClass);
                    }
                }
            }
        }
    }

    [XmlInclude(typeof(SurvivalKitDefinition))]
    public class AssemblerDefinition : ProductionBlockDefinition
    {
        //readonly property
        //public float? AssemblySpeed;

        public bool? IgnoreEfficiencyMultiplier;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyAssemblerDefinition;

            if (IgnoreEfficiencyMultiplier.HasValue) def.IgnoreEfficiencyMultiplier = IgnoreEfficiencyMultiplier.Value;
        }
    }

    public class SurvivalKitDefinition : AssemblerDefinition
    {
        public string ProgressSound;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySurvivalKitDefinition;

            if (!string.IsNullOrEmpty(ProgressSound)) def.ProgressSound = ProgressSound;
        }
    }

    [XmlInclude(typeof(OxygenTankDefinition))]
    public class GasTankDefinition : ProductionBlockDefinition
    {
        public float? Capacity;

        public SerializableDefinitionId? StoredGasId;

        public string ResourceSourceGroup;

        public float? LeakPercent;

        public float? GasExplosionMaxRadius;

        public float? GasExplosionNeededVolumeToReachMaxRadius;

        public float? GasExplosionDamageMultiplier;

        public string GasExplosionSound;

        public string GasExplosionEffect;

        public string EmptyDamageEffectName;

        public string EmptyDamagedSound;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGasTankDefinition;

            if (Capacity.HasValue) def.Capacity = Capacity.Value;

            if (StoredGasId.HasValue)
            {
                var storedGasId = StoredGasId.Value;
                if (storedGasId.IsNull())
                {
                    def.StoredGasId = new MyDefinitionId(typeof(MyObjectBuilder_GasProperties), "Oxygen");
                }
                else
                {
                    def.StoredGasId = storedGasId;
                }
            }

            if (!string.IsNullOrEmpty(ResourceSourceGroup)) def.ResourceSourceGroup = MyStringHash.GetOrCompute(ResourceSourceGroup);
            if (LeakPercent.HasValue) def.LeakPercent = LeakPercent.Value;
            if (GasExplosionMaxRadius.HasValue) def.GasExplosionMaxRadius = GasExplosionMaxRadius.Value;
            if (GasExplosionNeededVolumeToReachMaxRadius.HasValue) def.GasExplosionNeededVolumeToReachMaxRadius = GasExplosionNeededVolumeToReachMaxRadius.Value;
            if (GasExplosionDamageMultiplier.HasValue) def.GasExplosionDamageMultiplier = GasExplosionDamageMultiplier.Value;
            if (!string.IsNullOrEmpty(GasExplosionSound)) def.GasExplosionSound = GasExplosionSound;
            if (!string.IsNullOrEmpty(GasExplosionEffect)) def.GasExplosionEffect = GasExplosionEffect;
            if (!string.IsNullOrEmpty(EmptyDamageEffectName)) def.EmptyDamageEffectName = EmptyDamageEffectName;
            if (!string.IsNullOrEmpty(EmptyDamagedSound)) def.EmptyDamagedSound = new MySoundPair(EmptyDamagedSound, true);
        }
    }

    public class OxygenTankDefinition : GasTankDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class OxygenGeneratorDefinition : ProductionBlockDefinition
    {
        public float? IceConsumptionPerSecond;

        public string IdleSound;

        public string GenerateSound;

        public string ResourceSourceGroup;

        [XmlArrayItem("GasInfo")]
        public List<MyObjectBuilder_GasGeneratorResourceInfo> ProducedGases;

        public float? InventoryFillFactorMin;

        public float? InventoryFillFactorMax;

        public float? FuelPullAmountFromConveyorInMinutes;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyOxygenGeneratorDefinition;

            if (IceConsumptionPerSecond.HasValue) def.IceConsumptionPerSecond = IceConsumptionPerSecond.Value;
            if (!string.IsNullOrEmpty(IdleSound)) def.IdleSound = new MySoundPair(IdleSound, true);
            if (!string.IsNullOrEmpty(GenerateSound)) def.GenerateSound = new MySoundPair(GenerateSound, true);
            if (!string.IsNullOrEmpty(ResourceSourceGroup)) def.ResourceSourceGroup = MyStringHash.GetOrCompute(ResourceSourceGroup);
            if (InventoryFillFactorMin.HasValue) def.InventoryFillFactorMin = InventoryFillFactorMin.Value;
            if (InventoryFillFactorMax.HasValue) def.InventoryFillFactorMax = InventoryFillFactorMax.Value;
            if (FuelPullAmountFromConveyorInMinutes.HasValue) def.FuelPullAmountFromConveyorInMinutes = FuelPullAmountFromConveyorInMinutes.Value;

            if (ProducedGases != null && ProducedGases.Count > 0)
            {
                //def.IsOxygenOnly = (ProducedGases.Count > 0);
                def.ProducedGases = new List<MyOxygenGeneratorDefinition.MyGasGeneratorResourceInfo>(ProducedGases.Count);
                foreach (var resourceInfo in ProducedGases)
                {
                    def.ProducedGases.Add(new MyOxygenGeneratorDefinition.MyGasGeneratorResourceInfo
                    {
                        Id = resourceInfo.Id,
                        IceToGasRatio = resourceInfo.IceToGasRatio
                    });
                    //def.IsOxygenOnly &= (resourceInfo.Id == MyOxygenGeneratorDefinition.OxygenGasId);
                }
            }
        }
    }

    public class RefineryDefinition : ProductionBlockDefinition
    {
        public float? RefineSpeed;

        public float? MaterialEfficiency;

        public MyFixedPoint? OreAmountPerPullRequest;

        public float? InventoryFillFactorMin;

        public float? InventoryFillFactorMax;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyRefineryDefinition;

            if (RefineSpeed.HasValue) def.RefineSpeed = RefineSpeed.Value;
            if (MaterialEfficiency.HasValue) def.MaterialEfficiency = MaterialEfficiency.Value;
            if (OreAmountPerPullRequest.HasValue) def.OreAmountPerPullRequest = OreAmountPerPullRequest.Value;
            if (InventoryFillFactorMin.HasValue) def.InventoryFillFactorMin = InventoryFillFactorMin.Value;
            if (InventoryFillFactorMax.HasValue) def.InventoryFillFactorMax = InventoryFillFactorMax.Value;
        }
    }
    #endregion
    #region E
    public class ProgrammableBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyProgrammableBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
        }
    }

    public class ProjectorDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public string IdleSound;

        public bool? AllowScaling;

        public bool? AllowWelding;

        public bool? IgnoreSize;

        public int? RotationAngleStepDeg;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyProjectorDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (!string.IsNullOrEmpty(IdleSound)) def.IdleSound = new MySoundPair(IdleSound, true);
            if (AllowScaling.HasValue) def.AllowScaling = AllowScaling.Value;
            if (AllowWelding.HasValue) def.AllowWelding = AllowWelding.Value;
            if (IgnoreSize.HasValue) def.IgnoreSize = IgnoreSize.Value;
            if (RotationAngleStepDeg.HasValue) def.RotationAngleStepDeg = RotationAngleStepDeg.Value;
        }
    }

    public class RadioAntennaDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MaxBroadcastRadius;

        public float? LightningRodRadiusLarge;

        public float? LightningRodRadiusSmall;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyRadioAntennaDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (MaxBroadcastRadius.HasValue) def.MaxBroadcastRadius = MaxBroadcastRadius.Value;
            if (LightningRodRadiusLarge.HasValue) def.LightningRodRadiusLarge = LightningRodRadiusLarge.Value;
            if (LightningRodRadiusSmall.HasValue) def.LightningRodRadiusSmall = LightningRodRadiusSmall.Value;
        }
    }

    public class SafeZoneBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MaxSafeZoneRadius;

        public float? MinSafeZoneRadius;

        public float? DefaultSafeZoneRadius;

        public float? MaxSafeZonePowerDrainkW;

        public float? MinSafeZonePowerDrainkW;

        public uint? SafeZoneActivationTimeS;

        public uint? SafeZoneUpkeep;

        public uint? SafeZoneUpkeepTimeM;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySafeZoneBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (MaxSafeZoneRadius.HasValue) def.MaxSafeZoneRadius = MaxSafeZoneRadius.Value;
            if (MinSafeZoneRadius.HasValue) def.MinSafeZoneRadius = MinSafeZoneRadius.Value;
            if (DefaultSafeZoneRadius.HasValue) def.DefaultSafeZoneRadius = DefaultSafeZoneRadius.Value;
            if (MaxSafeZonePowerDrainkW.HasValue) def.MaxSafeZonePowerDrainkW = MaxSafeZonePowerDrainkW.Value;
            if (MinSafeZonePowerDrainkW.HasValue) def.MinSafeZonePowerDrainkW = MinSafeZonePowerDrainkW.Value;
            if (SafeZoneActivationTimeS.HasValue) def.SafeZoneActivationTimeS = SafeZoneActivationTimeS.Value;
            if (SafeZoneUpkeep.HasValue) def.SafeZoneUpkeep = SafeZoneUpkeep.Value;
            if (SafeZoneUpkeepTimeM.HasValue) def.SafeZoneUpkeepTimeM = SafeZoneUpkeepTimeM.Value;
        }
    }

    public class SearchlightDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string OverlayTexture;

        public string Flare;

        public string PointLightEmissiveMaterial;

        public string SpotLightEmissiveMaterial;

        public string ReflectorTexture;

        public string ReflectorConeMaterial;

        public string LightDummyName;

        public int? MinElevationDegrees;

        public int? MaxElevationDegrees;

        public int? MinAzimuthDegrees;

        public int? MaxAzimuthDegrees;

        public bool? IdleRotation;

        public bool? AiEnabled;

        public float? RequiredPowerInput;

        public float? MaxRangeMeters;

        public float? RotationSpeed;

        public float? MinFov;

        public float? MaxFov;

        public float? UpCameraOffset;

        public float? ForwardCameraOffset;

        public float? ReflectorThickness;

        public float? ElevationSpeed;

        public float? LightShaftOffset;

        public SerializableBounds? LightRadius;

        public SerializableBounds? LightReflectorRadius;

        public SerializableBounds? LightFalloff;

        public SerializableBounds? LightIntensity;

        public SerializableBounds? LightBlinkIntervalSeconds;

        public SerializableBounds? LightBlinkLenght;

        public SerializableBounds? LightBlinkOffset;

        public SerializableBounds? LightOffset;

        public SerializableBounds? RotationSpeedBounds;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySearchlightDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (!string.IsNullOrEmpty(OverlayTexture)) def.OverlayTexture = OverlayTexture;
            if (!string.IsNullOrEmpty(Flare)) def.Flare = Flare;
            if (!string.IsNullOrEmpty(PointLightEmissiveMaterial)) def.PointLightEmissiveMaterial = PointLightEmissiveMaterial;
            if (!string.IsNullOrEmpty(SpotLightEmissiveMaterial)) def.SpotLightEmissiveMaterial = SpotLightEmissiveMaterial;
            if (!string.IsNullOrEmpty(ReflectorTexture)) def.ReflectorTexture = ReflectorTexture;
            if (!string.IsNullOrEmpty(ReflectorConeMaterial)) def.ReflectorConeMaterial = ReflectorConeMaterial;
            if (!string.IsNullOrEmpty(LightDummyName)) def.LightDummyName = LightDummyName;

            if (MinElevationDegrees.HasValue) def.MinElevationDegrees = MinElevationDegrees.Value;
            if (MaxElevationDegrees.HasValue) def.MaxElevationDegrees = MaxElevationDegrees.Value;
            if (MinAzimuthDegrees.HasValue) def.MinAzimuthDegrees = MinAzimuthDegrees.Value;
            if (MaxAzimuthDegrees.HasValue) def.MaxAzimuthDegrees = MaxAzimuthDegrees.Value;
            if (IdleRotation.HasValue) def.IdleRotation = IdleRotation.Value;
            if (AiEnabled.HasValue) def.AiEnabled = AiEnabled.Value;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (MaxRangeMeters.HasValue) def.MaxRangeMeters = MaxRangeMeters.Value;
            if (RotationSpeed.HasValue) def.RotationSpeed = RotationSpeed.Value;
            if (MinFov.HasValue) def.MinFov = MinFov.Value;
            if (MaxFov.HasValue) def.MaxFov = MaxFov.Value;
            if (UpCameraOffset.HasValue) def.UpCameraOffset = UpCameraOffset.Value;
            if (ForwardCameraOffset.HasValue) def.ForwardCameraOffset = ForwardCameraOffset.Value;
            if (ReflectorThickness.HasValue) def.ReflectorThickness = ReflectorThickness.Value;
            if (ElevationSpeed.HasValue) def.ElevationSpeed = ElevationSpeed.Value;
            if (LightShaftOffset.HasValue) def.LightShaftOffset = LightShaftOffset.Value;
            if (LightRadius.HasValue) def.LightRadius = LightRadius.Value;
            if (LightReflectorRadius.HasValue) def.LightReflectorRadius = LightReflectorRadius.Value;
            if (LightFalloff.HasValue) def.LightFalloff = LightFalloff.Value;
            if (LightIntensity.HasValue) def.LightIntensity = LightIntensity.Value;
            if (LightBlinkIntervalSeconds.HasValue) def.BlinkIntervalSeconds = LightBlinkIntervalSeconds.Value;
            if (LightBlinkLenght.HasValue) def.BlinkLenght = LightBlinkLenght.Value;
            if (LightBlinkOffset.HasValue) def.BlinkOffset = LightBlinkOffset.Value;
            if (LightOffset.HasValue) def.LightOffset = LightOffset.Value;
            if (RotationSpeedBounds.HasValue) def.RotationSpeedBounds = RotationSpeedBounds.Value;
        }
    }

    public class SensorBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? MaxRange;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySensorBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (MaxRange.HasValue) def.MaxRange = Math.Max(1f, MaxRange.Value);
        }
    }

    public class ShipConnectorDefinition : FunctionalBlockDefinition
    {
        public float? AutoUnlockTime_Min;

        public float? AutoUnlockTime_Max;

        public Vector3? ConnectDirection;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyShipConnectorDefinition;

            if (AutoUnlockTime_Min.HasValue) def.AutoUnlockTime_Min = AutoUnlockTime_Min.Value;
            if (AutoUnlockTime_Max.HasValue) def.AutoUnlockTime_Max = AutoUnlockTime_Max.Value;
            if (ConnectDirection.HasValue) def.ConnectDirection = ConnectDirection.Value;
        }
    }
    #endregion
    #region Control
    [XmlInclude(typeof(CockpitDefinition))]
    [XmlInclude(typeof(RemoteControlDefinition))]
    public class ShipControllerDefinition : FunctionalBlockDefinition
    {
        public bool? EnableFirstPerson;

        public bool? EnableShipControl;

        public bool? EnableBuilderCockpit;

        public string GetInSound;

        public string GetOutSound;

        public Vector3D? RaycastOffset;

        public bool? IsDefault3rdView;

        public bool? TargetLockingEnabled;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyShipControllerDefinition;

            if (EnableFirstPerson.HasValue) def.EnableFirstPerson = EnableFirstPerson.Value;
            if (EnableShipControl.HasValue) def.EnableShipControl = EnableShipControl.Value;
            if (EnableBuilderCockpit.HasValue) def.EnableBuilderCockpit = EnableBuilderCockpit.Value;
            if (!string.IsNullOrEmpty(GetInSound)) def.GetInSound = GetInSound;
            if (!string.IsNullOrEmpty(GetOutSound)) def.GetOutSound = GetOutSound;
            if (RaycastOffset.HasValue) def.RaycastOffset = RaycastOffset.Value;
            if (IsDefault3rdView.HasValue) def.IsDefault3rdView = IsDefault3rdView.Value;
            if (TargetLockingEnabled.HasValue) def.TargetLockingEnabled = TargetLockingEnabled.Value;
        }
    }

    [XmlInclude(typeof(CryoChamberDefinition))]
    public class CockpitDefinition : ShipControllerDefinition
    {
        public string CharacterAnimation;

        public string CharacterAnimationMale;

        public string CharacterAnimationFemale;

        public string GlassModel;

        public string InteriorModel;

        public string HUD;

        public float? OxygenCapacity;

        public bool? IsPressurized;

        public bool? HasInventory;

        public bool? BackpackEnabled;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyCockpitDefinition;

            if (!string.IsNullOrEmpty(CharacterAnimation))
            {
                if (CharacterAnimation.Contains(Path.AltDirectorySeparatorChar) || CharacterAnimation.Contains(Path.DirectorySeparatorChar))
                    Logs.WriteLine("<CharacterAnimation> tag must contain animation name (defined in Animations.sbc) not the file: " + CharacterAnimation);

                def.CharacterAnimation = CharacterAnimation;
            }

            if (!string.IsNullOrEmpty(CharacterAnimationMale))
            {
                if (CharacterAnimationMale.Contains(Path.AltDirectorySeparatorChar) || CharacterAnimation.Contains(Path.DirectorySeparatorChar))
                    Logs.WriteLine("<CharacterAnimationMale> tag must contain animation name (defined in Animations.sbc) not the file: " + CharacterAnimationMale);

                def.CharacterAnimationMale = CharacterAnimationMale;
            }

            if (!string.IsNullOrEmpty(CharacterAnimationFemale))
            {
                if (CharacterAnimationFemale.Contains(Path.AltDirectorySeparatorChar) || CharacterAnimation.Contains(Path.DirectorySeparatorChar))
                    Logs.WriteLine("<CharacterAnimationFemale> tag must contain animation name (defined in Animations.sbc) not the file: " + CharacterAnimationFemale);

                def.CharacterAnimationFemale = CharacterAnimationFemale;
            }

            if (!string.IsNullOrEmpty(GlassModel)) def.GlassModel = GlassModel;
            if (!string.IsNullOrEmpty(InteriorModel)) def.InteriorModel = InteriorModel;
            if (!string.IsNullOrEmpty(HUD)) def.HUD = HUD;
            if (OxygenCapacity.HasValue) def.OxygenCapacity = OxygenCapacity.Value;
            if (IsPressurized.HasValue) def.IsPressurized = IsPressurized.Value;
            if (HasInventory.HasValue) def.HasInventory = HasInventory.Value;
            if (BackpackEnabled.HasValue) def.BackpackEnabled = BackpackEnabled.Value;
        }
    }

    public class CryoChamberDefinition : CockpitDefinition
    {
        public string OverlayTexture;

        public string ResourceSinkGroup;

        public string OutsideSound;

        public string InsideSound;

        public float? IdlePowerConsumption;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyCryoChamberDefinition;

            if (!string.IsNullOrEmpty(OverlayTexture)) def.OverlayTexture = OverlayTexture;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = ResourceSinkGroup;
            if (!string.IsNullOrEmpty(OutsideSound)) def.OutsideSound = new MySoundPair(OutsideSound, true);
            if (!string.IsNullOrEmpty(InsideSound)) def.InsideSound = new MySoundPair(InsideSound, true);
            if (IdlePowerConsumption.HasValue) def.IdlePowerConsumption = IdlePowerConsumption.Value;
        }
    }

    public class RemoteControlDefinition : ShipControllerDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyRemoteControlDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
        }
    }
    #endregion
    #region Tools
    [XmlInclude(typeof(ShipDrillDefinition))]
    [XmlInclude(typeof(ShipGrinderDefinition))]
    [XmlInclude(typeof(ShipWelderDefinition))]
    public class ShipToolDefinition : FunctionalBlockDefinition
    {
        public string Flare;

        public float? SensorRadius;

        public float? SensorOffset;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyShipToolDefinition;

            if (!string.IsNullOrEmpty(Flare)) def.Flare = Flare;
            if (SensorRadius.HasValue) def.SensorRadius = SensorRadius.Value;
            if (SensorOffset.HasValue) def.SensorOffset = SensorOffset.Value;
        }
    }

    public class ShipDrillDefinition : ShipToolDefinition
    {
        public string ResourceSinkGroup;

        public float? CutOutRadius;

        public float? CutOutOffset;

        public Vector3D? ParticleOffset;

        public float? DiscardingMultiplier;

        public float? Speed;

        public string[] CounterRotatingSubparts;

        public string DustEffect;

        public string DustStoneEffect;

        public string SparksEffect;

        public string DrillingMaterialName;


        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyShipDrillDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (CutOutRadius.HasValue) def.CutOutRadius = CutOutRadius.Value;
            if (CutOutOffset.HasValue) def.CutOutOffset = CutOutOffset.Value;
            if (ParticleOffset.HasValue) def.ParticleOffset = ParticleOffset.Value;

            if (DiscardingMultiplier.HasValue) def.DiscardingMultiplier = DiscardingMultiplier.Value;
            if (Speed.HasValue) def.Speed = Speed.Value;
            if (CounterRotatingSubparts != null && CounterRotatingSubparts.Length > 0) def.CounterRotatingSubparts = CounterRotatingSubparts;
            if (!string.IsNullOrEmpty(DustEffect)) def.DustEffect = DustEffect;
            if (!string.IsNullOrEmpty(DustStoneEffect)) def.DustStoneEffect = DustStoneEffect;
            if (!string.IsNullOrEmpty(SparksEffect)) def.SparksEffect = SparksEffect;
            if (!string.IsNullOrEmpty(DrillingMaterialName)) def.DrillingMaterialName = DrillingMaterialName;
        }
    }

    public class ShipGrinderDefinition : ShipToolDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class ShipWelderDefinition : ShipToolDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }
    #endregion
    #region F
    [XmlInclude(typeof(JukeboxDefinition))]
    public class SoundBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? MinRange;

        public float? MaxRange;

        public float? MaxLoopPeriod;

        public int? EmitterNumber;

        public int? LoopUpdateThreshold;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySoundBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (MinRange.HasValue) def.MinRange = MinRange.Value;
            if (MaxRange.HasValue) def.MaxRange = MaxRange.Value;
            if (MaxLoopPeriod.HasValue) def.MaxLoopPeriod = MaxLoopPeriod.Value;
            if (EmitterNumber.HasValue) def.EmitterNumber = EmitterNumber.Value;
            if (LoopUpdateThreshold.HasValue) def.LoopUpdateThreshold = LoopUpdateThreshold.Value;
        }
    }

    public class JukeboxDefinition : SoundBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class SpaceBallDefinition : FunctionalBlockDefinition
    {
        public float? MaxVirtualMass;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MySpaceBallDefinition;

            if (MaxVirtualMass.HasValue) def.MaxVirtualMass = MaxVirtualMass.Value;
        }
    }

    [XmlInclude(typeof(VendingMachineDefinition))]
    public class StoreBlockDefinition : FunctionalBlockDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class VendingMachineDefinition : StoreBlockDefinition
    {
        public List<string> AdditionalEmissiveMaterials;

        public List<MyObjectBuilder_StoreItem> DefaultItems;

        public string ThrowOutDummy;

        //public Dictionary<string, float> ThrowOutItems;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyVendingMachineDefinition;

            if (AdditionalEmissiveMaterials != null && AdditionalEmissiveMaterials.Count > 0)
                def.AdditionalEmissiveMaterials = AdditionalEmissiveMaterials;

            if (DefaultItems != null && DefaultItems.Count > 0)
                def.DefaultItems = DefaultItems;

            if (!string.IsNullOrEmpty(ThrowOutDummy)) def.ThrowOutDummy = ThrowOutDummy;

            //if (ThrowOutItems != null && ThrowOutItems.Count > 0)
            //    def.ThrowOutItems = ThrowOutItems;
        }
    }

    public class TargetDummyBlockDefinition : FunctionalBlockDefinition
    {
        public List<string> DummySubpartNames;

        public List<bool> DummySubpartCritical;

        public List<float> DummySubpartHealth;

        public string ConstructionItemName;

        public int? ConstructionItemAmount;

        public float? InventoryMaxVolume;

        public Vector3? InventorySize;

        public float? MinRegenerationTimeInS;

        public float? MaxRegenerationTimeInS;

        public string RegenerationEffectName;

        public string DestructionEffectName;

        public float? RegenerationEffectMultiplier;

        public float? DestructionEffectMultiplier;

        public string RegenerationSound;

        public string DestructionSound;

        public float? MinFillFactor;
        
        public float? MaxFillFactor;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyTargetDummyBlockDefinition;

            if (DummySubpartNames != null && DummySubpartCritical != null && DummySubpartHealth != null && DummySubpartNames.Count > 0 && DummySubpartNames.Count == DummySubpartCritical.Count && DummySubpartCritical.Count == DummySubpartHealth.Count)
            {
                def.SubpartDefinitions.Clear();
                for (int i = 0; i < DummySubpartNames.Count; i++)
                {
                    def.SubpartDefinitions.Add(DummySubpartNames[i], new MyTargetDummyBlockDefinition.MyDummySubpartDescription
                    {
                        IsCritical = DummySubpartCritical[i],
                        Health = DummySubpartHealth[i]
                    });
                }
            }
            else
            {
                Logs.WriteLine("Unequal TargetDummy subpart informations for: " + def.Id.SubtypeName);
            }

            if (!string.IsNullOrEmpty(ConstructionItemName)) def.ConstructionItem = new MyDefinitionId(typeof(MyObjectBuilder_Component), ConstructionItemName);
            if (ConstructionItemAmount.HasValue) def.ConstructionItemAmount = ConstructionItemAmount.Value;
            if (InventoryMaxVolume.HasValue) def.InventoryMaxVolume = InventoryMaxVolume.Value;
            if (InventorySize.HasValue) def.InventorySize = InventorySize.Value;
            if (MinRegenerationTimeInS.HasValue) def.MinRegenerationTimeInS = MinRegenerationTimeInS.Value;
            if (MaxRegenerationTimeInS.HasValue) def.MaxRegenerationTimeInS = MaxRegenerationTimeInS.Value;
            if (!string.IsNullOrEmpty(RegenerationEffectName)) def.RegenerationEffectName = RegenerationEffectName;
            if (!string.IsNullOrEmpty(DestructionEffectName)) def.DestructionEffectName = DestructionEffectName;
            if (RegenerationEffectMultiplier.HasValue) def.RegenerationEffectMultiplier = RegenerationEffectMultiplier.Value;
            if (DestructionEffectMultiplier.HasValue) def.DestructionEffectMultiplier = DestructionEffectMultiplier.Value;
            if (!string.IsNullOrEmpty(RegenerationSound)) def.RegenerationSound = new MySoundPair(RegenerationSound, true);
            if (!string.IsNullOrEmpty(DestructionSound)) def.DestructionSound = new MySoundPair(DestructionSound, true);
            if (MinFillFactor.HasValue) def.MinFillFactor = MinFillFactor.Value;
            if (MaxFillFactor.HasValue) def.MaxFillFactor = MaxFillFactor.Value;
        }
    }

    public class TextPanelDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string PanelMaterialName;

        public int? TextureResolution;

        public int? ScreenWidth;

        public int? ScreenHeight;

        public float? MinFontSize;

        public float? MaxFontSize;

        public float? MaxChangingSpeed;

        public float? MaxScreenRenderDistance;

        public float? RequiredPowerInput;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyTextPanelDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (!string.IsNullOrEmpty(PanelMaterialName)) def.PanelMaterialName = PanelMaterialName;
            if (TextureResolution.HasValue) def.TextureResolution = TextureResolution.Value;
            if (ScreenWidth.HasValue) def.ScreenWidth = ScreenWidth.Value;
            if (ScreenHeight.HasValue) def.ScreenHeight = ScreenHeight.Value;
            if (MinFontSize.HasValue) def.MinFontSize = MinFontSize.Value;
            if (MaxFontSize.HasValue) def.MaxFontSize = MaxFontSize.Value;
            if (MaxChangingSpeed.HasValue) def.MaxChangingSpeed = MaxChangingSpeed.Value;
            if (MaxScreenRenderDistance.HasValue) def.MaxScreenRenderDistance = MaxScreenRenderDistance.Value;
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
        }
    }

    public class ThrustDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public MyFuelConverterInfo FuelConverter;

        public float? SlowdownFactor;

        public string ThrusterType;

        public float? ForceMagnitude;

        public float? MaxPowerConsumption;

        public float? MinPowerConsumption;

        public float? FlameDamageLengthScale;

        public float? FlameLengthScale;

        public Vector4? FlameFullColor;

        public Vector4? FlameIdleColor;

        public string FlamePointMaterial;

        public string FlameLengthMaterial;

        public string FlameFlare;

        public float? FlameVisibilityDistance;

        public float? FlameGlareQuerySize;

        public float? FlameDamage;

        public float? MinPlanetaryInfluence;

        public float? MaxPlanetaryInfluence;

        public float? EffectivenessAtMaxInfluence;

        public float? EffectivenessAtMinInfluence;

        public bool? NeedsAtmosphereForInfluence;

        public float? ConsumptionFactorPerG;

        public bool? PropellerUsesPropellerSystem;

        public string PropellerSubpartEntityName;

        public float? PropellerRoundsPerSecondOnFullSpeed;

        public float? PropellerRoundsPerSecondOnIdleSpeed;

        public float? PropellerAccelerationTime;

        public float? PropellerDecelerationTime;

        public float? PropellerMaxVisibleDistance;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyThrustDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (FuelConverter != null) def.FuelConverter = FuelConverter;
            if (SlowdownFactor.HasValue) def.SlowdownFactor = SlowdownFactor.Value;
            if (!string.IsNullOrEmpty(ThrusterType)) def.ThrusterType = MyStringHash.GetOrCompute(ThrusterType);
            if (ForceMagnitude.HasValue) def.ForceMagnitude = ForceMagnitude.Value;
            if (MaxPowerConsumption.HasValue) def.MaxPowerConsumption = MaxPowerConsumption.Value;
            if (MinPowerConsumption.HasValue) def.MinPowerConsumption = MinPowerConsumption.Value;
            if (FlameDamageLengthScale.HasValue) def.FlameDamageLengthScale = FlameDamageLengthScale.Value;
            if (FlameLengthScale.HasValue) def.FlameLengthScale = FlameLengthScale.Value;
            if (FlameFullColor.HasValue) def.FlameFullColor = FlameFullColor.Value;
            if (FlameIdleColor.HasValue) def.FlameIdleColor = FlameIdleColor.Value;
            if (!string.IsNullOrEmpty(FlamePointMaterial)) def.FlamePointMaterial = FlamePointMaterial;
            if (!string.IsNullOrEmpty(FlameLengthMaterial)) def.FlameLengthMaterial = FlameLengthMaterial;
            if (!string.IsNullOrEmpty(FlameFlare)) def.FlameFlare = FlameFlare;
            if (FlameVisibilityDistance.HasValue) def.FlameVisibilityDistance = FlameVisibilityDistance.Value;
            if (FlameGlareQuerySize.HasValue) def.FlameGlareQuerySize = FlameGlareQuerySize.Value;
            if (FlameDamage.HasValue) def.FlameDamage = FlameDamage.Value;
            if (MinPlanetaryInfluence.HasValue) def.MinPlanetaryInfluence = MinPlanetaryInfluence.Value;
            if (MaxPlanetaryInfluence.HasValue) def.MaxPlanetaryInfluence = MaxPlanetaryInfluence.Value;
            if (EffectivenessAtMinInfluence.HasValue) def.EffectivenessAtMinInfluence = EffectivenessAtMinInfluence.Value;
            if (EffectivenessAtMaxInfluence.HasValue) def.EffectivenessAtMaxInfluence = EffectivenessAtMaxInfluence.Value;
            if (NeedsAtmosphereForInfluence.HasValue) def.NeedsAtmosphereForInfluence = NeedsAtmosphereForInfluence.Value;
            if (ConsumptionFactorPerG.HasValue) def.ConsumptionFactorPerG = ConsumptionFactorPerG.Value;
            if (PropellerUsesPropellerSystem.HasValue) def.PropellerUse = PropellerUsesPropellerSystem.Value;
            if (!string.IsNullOrEmpty(PropellerSubpartEntityName)) def.PropellerEntity = PropellerSubpartEntityName;
            if (PropellerRoundsPerSecondOnFullSpeed.HasValue) def.PropellerFullSpeed = PropellerRoundsPerSecondOnFullSpeed.Value;
            if (PropellerRoundsPerSecondOnIdleSpeed.HasValue) def.PropellerIdleSpeed = PropellerRoundsPerSecondOnIdleSpeed.Value;
            if (PropellerAccelerationTime.HasValue) def.PropellerAcceleration = PropellerAccelerationTime.Value;
            if (PropellerDecelerationTime.HasValue) def.PropellerDeceleration = PropellerDecelerationTime.Value;
            if (PropellerMaxVisibleDistance.HasValue) def.PropellerMaxDistance = PropellerMaxVisibleDistance.Value;

            if (MinPlanetaryInfluence.HasValue || MaxPlanetaryInfluence.HasValue)
            {
                def.InvDiffMinMaxPlanetaryInfluence = 1f / (def.MaxPlanetaryInfluence - def.MinPlanetaryInfluence);
                if (!MyUtils.IsValid(def.InvDiffMinMaxPlanetaryInfluence))
                {
                    def.InvDiffMinMaxPlanetaryInfluence = 0f;
                }
            }
        }
    }

    public class TimerBlockDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public string TimerSoundStart;

        public string TimerSoundMid;

        public string TimerSoundEnd;

        public int? MinDelay;

        public int? MaxDelay;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyTimerBlockDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (!string.IsNullOrEmpty(TimerSoundStart)) def.TimerSoundStart = TimerSoundStart;
            if (!string.IsNullOrEmpty(TimerSoundMid)) def.TimerSoundMid = TimerSoundMid;
            if (!string.IsNullOrEmpty(TimerSoundEnd)) def.TimerSoundEnd = TimerSoundEnd;
            if (MinDelay.HasValue) def.MinDelay = MinDelay.Value;
            if (MaxDelay.HasValue) def.MaxDelay = MaxDelay.Value;
        }
    }

    public class TurretControlBlockDefinition : FunctionalBlockDefinition
    {
        public float? MaxRangeMeters;

        public float? PlayerInputDivider;

        public string ResourceSinkGroup;

        public float? PowerInputIdle;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyTurretControlBlockDefinition;

            if (MaxRangeMeters.HasValue) def.MaxRangeMeters = MaxRangeMeters.Value;
            if (PlayerInputDivider.HasValue) def.PlayerInputDivider = PlayerInputDivider.Value;
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (PowerInputIdle.HasValue) def.PowerInputIdle = PowerInputIdle.Value;
        }
    }

    public class UpgradeModuleDefinition : FunctionalBlockDefinition
    {
        public MyUpgradeModuleInfo[] Upgrades;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyUpgradeModuleDefinition;

            if (Upgrades != null) def.Upgrades = Upgrades;
        }
    }

    public class VirtualMassDefinition : FunctionalBlockDefinition
    {
        public string ResourceSinkGroup;

        public float? RequiredPowerInput;

        public float? VirtualMass;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyVirtualMassDefinition;

            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (RequiredPowerInput.HasValue) def.RequiredPowerInput = RequiredPowerInput.Value;
            if (VirtualMass.HasValue) def.VirtualMass = VirtualMass.Value;
        }
    }

    [XmlInclude(typeof(LargeTurretBaseDefinition))]
    public class WeaponBlockDefinition : FunctionalBlockDefinition
    {
        public MyObjectBuilder_WeaponBlockDefinition.WeaponBlockWeaponDefinition WeaponDefinitionId;

        public string ResourceSinkGroup;

        public float? InventoryMaxVolume;

        public float? InventoryFillFactorMin;

        public string MuzzleProjectileDummyName;

        public string MuzzleMissileDummyName;

        public string HoldingDummyName;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyWeaponBlockDefinition;

            if (WeaponDefinitionId != null) def.WeaponDefinitionId = new MyDefinitionId(WeaponDefinitionId.Type, WeaponDefinitionId.Subtype);
            if (!string.IsNullOrEmpty(ResourceSinkGroup)) def.ResourceSinkGroup = MyStringHash.GetOrCompute(ResourceSinkGroup);
            if (InventoryMaxVolume.HasValue) def.InventoryMaxVolume = InventoryMaxVolume.Value;
            if (InventoryFillFactorMin.HasValue) def.InventoryFillFactorMin = InventoryFillFactorMin.Value;

            if (!string.IsNullOrEmpty(MuzzleProjectileDummyName)) def.DummyNames.Add(MyGunBase.DUMMY_KEY_PROJECTILE, MuzzleProjectileDummyName);
            if (!string.IsNullOrEmpty(MuzzleMissileDummyName)) def.DummyNames.Add(MyGunBase.DUMMY_KEY_MISSILE, MuzzleMissileDummyName);
            if (!string.IsNullOrEmpty(HoldingDummyName)) def.DummyNames.Add(MyGunBase.DUMMY_KEY_HOLDING, HoldingDummyName);
        }
    }

    public class LargeTurretBaseDefinition : WeaponBlockDefinition
    {
        public string OverlayTexture;

        public string CameraDummyName;

        public bool? AiEnabled;

        public bool? IdleRotation;

        public int? MinElevationDegrees;

        public int? MaxElevationDegrees;

        public int? MinAzimuthDegrees;

        public int? MaxAzimuthDegrees;

        public int? AmmoPullAmountPerTick;

        public float? MaxRangeMeters;

        public float? RotationSpeed;

        public float? ElevationSpeed;

        public float? MinFov;

        public float? MaxFov;

        public float? InventoryFillFactorMax;

        public float? UpCameraOffset;

        public float? ForwardCameraOffset;

        //public Dictionary<string, string> SubpartPairing;

        public MyTurretTargetingOptions? EnabledTargetingOptions;

        public MyTurretTargetingOptions? HiddenTargetingOptions;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyLargeTurretBaseDefinition;

            if (!string.IsNullOrEmpty(OverlayTexture)) def.OverlayTexture = OverlayTexture;
            if (!string.IsNullOrEmpty(CameraDummyName)) def.CameraDummyName = CameraDummyName;
            if (AiEnabled.HasValue) def.AiEnabled = AiEnabled.Value;
            if (IdleRotation.HasValue) def.IdleRotation = IdleRotation.Value;
            if (MinElevationDegrees.HasValue) def.MinElevationDegrees = MinElevationDegrees.Value;
            if (MaxElevationDegrees.HasValue) def.MaxElevationDegrees = MaxElevationDegrees.Value;
            if (MinAzimuthDegrees.HasValue) def.MinAzimuthDegrees = MinAzimuthDegrees.Value;
            if (MaxAzimuthDegrees.HasValue) def.MaxAzimuthDegrees = MaxAzimuthDegrees.Value;
            if (AmmoPullAmountPerTick.HasValue) def.AmmoPullAmount = AmmoPullAmountPerTick.Value;
            if (MaxRangeMeters.HasValue) def.MaxRangeMeters = MaxRangeMeters.Value;
            if (RotationSpeed.HasValue) def.RotationSpeed = RotationSpeed.Value;
            if (ElevationSpeed.HasValue) def.ElevationSpeed = ElevationSpeed.Value;
            if (MinFov.HasValue) def.MinFov = MinFov.Value;
            if (MaxFov.HasValue) def.MaxFov = MaxFov.Value;
            if (InventoryFillFactorMax.HasValue) def.InventoryFillFactorMax = InventoryFillFactorMax.Value;
            if (UpCameraOffset.HasValue) def.UpCameraOffset = UpCameraOffset.Value;
            if (ForwardCameraOffset.HasValue) def.ForwardCameraOffset = ForwardCameraOffset.Value;

            //if (SubpartPairing != null && SubpartPairing.Count > 0) def.SubpartPairing.Dictionary = SubpartPairing;

            if (EnabledTargetingOptions.HasValue) def.EnabledTargetingOptions = EnabledTargetingOptions.Value;
            if (HiddenTargetingOptions.HasValue) def.HiddenTargetingOptions = HiddenTargetingOptions.Value;
        }
    }
    #endregion
}
