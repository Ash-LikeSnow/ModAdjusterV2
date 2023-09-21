using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;

namespace ModAdjusterV2.Definitions
{
    public class RespawnShipDefinition : Definition
    {
		public string Prefab;

		public int? CooldownSeconds;

		public bool? SpawnWithDefaultItems;

		public bool? UseForSpace;

		public bool? UseForPlanetsWithAtmosphere;

		public bool? UseForPlanetsWithoutAtmosphere;

		public float? MinimalAirDensity;

		public float? PlanetDeployAltitude;

		public SerializableVector3? InitialLinearVelocity;

		public SerializableVector3? InitialAngularVelocity;

		public string HelpTextLocalizationId;

		public bool? SpawnNearProceduralAsteroids;

		[XmlArrayItem("PlanetType")]
		public string[] PlanetTypes;

		public SerializableVector3D? SpawnPosition;

		public float? SpawnPositionDispersionMin;

		public float? SpawnPositionDispersionMax;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyRespawnShipDefinition;

			if (!string.IsNullOrEmpty(Prefab)) def.Prefab = MyDefinitionManager.Static.GetPrefabDefinition(Prefab);

			if (CooldownSeconds.HasValue) def.Cooldown = CooldownSeconds.Value;
			if (SpawnWithDefaultItems.HasValue) def.SpawnWithDefaultItems = SpawnWithDefaultItems.Value;
			if (UseForSpace.HasValue) def.UseForSpace = UseForSpace.Value;
			if (UseForPlanetsWithAtmosphere.HasValue) def.UseForPlanetsWithAtmosphere = UseForPlanetsWithAtmosphere.Value;
			if (UseForPlanetsWithoutAtmosphere.HasValue) def.UseForPlanetsWithoutAtmosphere = UseForPlanetsWithoutAtmosphere.Value;
			if (MinimalAirDensity.HasValue) def.MinimalAirDensity = MinimalAirDensity.Value;
			if (PlanetDeployAltitude.HasValue) def.PlanetDeployAltitude = PlanetDeployAltitude.Value;
			if (InitialLinearVelocity.HasValue) def.InitialLinearVelocity = InitialLinearVelocity.Value;
			if (InitialAngularVelocity.HasValue) def.InitialAngularVelocity = InitialAngularVelocity.Value;
			if (!string.IsNullOrEmpty(HelpTextLocalizationId)) def.HelpTextLocalizationId = HelpTextLocalizationId;
			if (SpawnNearProceduralAsteroids.HasValue) def.SpawnNearProceduralAsteroids = SpawnNearProceduralAsteroids.Value;
			if (PlanetTypes != null && PlanetTypes.Length > 0) def.PlanetTypes = PlanetTypes;
			if (SpawnPosition.HasValue) def.SpawnPosition = SpawnPosition.Value;
			if (SpawnPositionDispersionMin.HasValue) def.SpawnPositionDispersionMin = SpawnPositionDispersionMin.Value;
			if (SpawnPositionDispersionMax.HasValue) def.SpawnPositionDispersionMax = SpawnPositionDispersionMax.Value;
		}
    }
}
