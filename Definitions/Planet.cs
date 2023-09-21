using ModAdjusterV2.Session;
using Sandbox.Definitions;
using Sandbox.Game.WorldEnvironment.Definitions;
using Sandbox.Game.WorldEnvironment.ObjectBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.Game.ObjectBuilders;
using VRage.ObjectBuilders;
using VRage.ObjectBuilders.Definitions.Components;
using VRage.Utils;
using VRageMath;
using VRageRender.Messages;

namespace ModAdjusterV2.Definitions
{
    public class PlanetGeneratorDefinition : Definition
	{
		public string InheritFrom;

		public string InheritCloudLayersFrom;

		public string InheritAtmosphereSettingsFrom;

		public string InheritMesherPostprocessingFrom;

		public string InheritEnvironmentItemsFrom;

		public MyPlanetMaps? PlanetMaps;

		public bool? HasAtmosphere;

        //[XmlArrayItem("CloudLayer")]
        //public List<MyCloudLayerSettings> CloudLayers;

        public SerializableRange? HillParams;

		public float? GravityFalloffPower;

		public SerializableRange? MaterialsMaxDepth;

		public SerializableRange? MaterialsMinDepth;

		public MyAtmosphereColorShift HostileAtmosphereColorShift;

		[XmlArrayItem("Material")]
		public MyPlanetMaterialDefinition[] CustomMaterialTable;

		[XmlArrayItem("Distortion")]
		public MyPlanetDistortionDefinition[] DistortionTable;

		public MyPlanetMaterialDefinition DefaultSurfaceMaterial;

		public MyPlanetMaterialDefinition DefaultSubSurfaceMaterial;

		public float? SurfaceGravity;

		public MyPlanetAtmosphere Atmosphere;

		//public MyAtmosphereSettings? AtmosphereSettings;

		public string FolderName;

		public MyPlanetMaterialGroup[] ComplexMaterials;

		[XmlArrayItem("SoundRule")]
		public MySerializablePlanetEnvironmentalSoundRule[] SoundRules;

		[XmlArrayItem("MusicCategory")]
		public List<MyMusicCategory> MusicCategories;

		[XmlArrayItem("Ore")]
		public MyPlanetOreMapping[] OreMappings;

		//obsolete
		//[XmlArrayItem("Item")]
		//public PlanetEnvironmentItemMapping[] EnvironmentItems;

		public MyPlanetMaterialBlendSettings? MaterialBlending;

		public MyPlanetSurfaceDetail SurfaceDetail;

		public MyPlanetAnimalSpawnInfo AnimalSpawnInfo;

		public MyPlanetAnimalSpawnInfo NightAnimalSpawnInfo;

		public float? SectorDensity;

		public SerializableDefinitionId? Environment;

		//[XmlElement(typeof(MyAbstractXmlSerializer<MyObjectBuilder_PlanetMapProvider>))]
		//public MyObjectBuilder_PlanetMapProvider MapProvider;

		//public MyObjectBuilder_VoxelMesherComponentDefinition MesherPostprocessing;

		public float? MinimumSurfaceLayerDepth;

		public List<SerializableDefinitionId> StationBlockingMaterials;

		public MyTemperatureLevel? DefaultSurfaceTemperature;

		[XmlArrayItem("WeatherGenerator")]
		public List<MyWeatherGeneratorSettings> WeatherGenerators;

		public int? WeatherFrequencyMin;

		public int? WeatherFrequencyMax;

		public bool? GlobalWeather;

		public MyStringId Difficulty;

		public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
			base.Load(definitionBase, path);

			var def = definitionBase as MyPlanetGeneratorDefinition;

			if (!string.IsNullOrEmpty(InheritFrom)) Inherit(InheritFrom, def);
			if (!string.IsNullOrEmpty(InheritCloudLayersFrom)) InheritCloudLayers(InheritCloudLayersFrom, def);
			if (!string.IsNullOrEmpty(InheritAtmosphereSettingsFrom)) InheritAtmosphereSettings(InheritAtmosphereSettingsFrom, def);
			if (!string.IsNullOrEmpty(InheritMesherPostprocessingFrom)) InheritMesherPostprocessing(InheritMesherPostprocessingFrom, def);
			if (!string.IsNullOrEmpty(InheritEnvironmentItemsFrom)) InheritEnvironmentItems(InheritEnvironmentItemsFrom, def);

			if (PlanetMaps.HasValue) def.PlanetMaps = PlanetMaps.Value;
			if (HasAtmosphere.HasValue) def.HasAtmosphere = HasAtmosphere.Value;
			if (HillParams.HasValue) def.HillParams = HillParams.Value;
			if (GravityFalloffPower.HasValue) def.GravityFalloffPower = GravityFalloffPower.Value;
			if (MaterialsMaxDepth.HasValue) def.MaterialsMaxDepth = MaterialsMaxDepth.Value;
			if (MaterialsMinDepth.HasValue) def.MaterialsMinDepth = MaterialsMinDepth.Value;
			if (HostileAtmosphereColorShift != null) def.HostileAtmosphereColorShift = HostileAtmosphereColorShift;

			if (CustomMaterialTable != null && CustomMaterialTable.Length > 0)
			{
				def.SurfaceMaterialTable = new MyPlanetMaterialDefinition[CustomMaterialTable.Length];
				for (int j = 0; j < def.SurfaceMaterialTable.Length; j++)
				{
					def.SurfaceMaterialTable[j] = (CustomMaterialTable[j].Clone() as MyPlanetMaterialDefinition);
					if (def.SurfaceMaterialTable[j].Material == null && !def.SurfaceMaterialTable[j].HasLayers)
					{
						Logs.WriteLine("Custom material does not contain any material ids.");
					}
					else if (def.SurfaceMaterialTable[j].HasLayers)
					{
						var depth = def.SurfaceMaterialTable[j].Layers[0].Depth;
						for (int k = 1; k < def.SurfaceMaterialTable[j].Layers.Length; k++)
						{
							var layers = def.SurfaceMaterialTable[j].Layers;
							var num = k;
							layers[num].Depth = layers[num].Depth + depth;
							depth = def.SurfaceMaterialTable[j].Layers[k].Depth;
						}
					}
				}
			}

			if (DistortionTable != null && DistortionTable.Length > 0) def.DistortionTable = DistortionTable;
			if (DefaultSurfaceMaterial != null) def.DefaultSurfaceMaterial = DefaultSurfaceMaterial;
			if (DefaultSubSurfaceMaterial != null) def.DefaultSubSurfaceMaterial = DefaultSubSurfaceMaterial;
			if (SurfaceGravity.HasValue) def.SurfaceGravity = SurfaceGravity.Value;
			if (Atmosphere != null) def.Atmosphere = Atmosphere;
			if (!string.IsNullOrEmpty(FolderName)) def.FolderName = FolderName;

			if (ComplexMaterials != null && ComplexMaterials.Length > 0)
			{
				def.MaterialGroups = new MyPlanetMaterialGroup[ComplexMaterials.Length];
				for (int l = 0; l < ComplexMaterials.Length; l++)
				{
					def.MaterialGroups[l] = (ComplexMaterials[l].Clone() as MyPlanetMaterialGroup);
					var myPlanetMaterialGroup = def.MaterialGroups[l];
					var array = myPlanetMaterialGroup.MaterialRules;
					var list = new List<int>();
					for (int m = 0; m < array.Length; m++)
					{
						if (array[m].Material == null && (array[m].Layers == null || array[m].Layers.Length == 0))
						{
							Logs.WriteLine("Material rule does not contain any material ids.");
							list.Add(m);
						}
						else
						{
							if (array[m].Layers != null && array[m].Layers.Length != 0)
							{
								float depth2 = array[m].Layers[0].Depth;
								for (int n = 1; n < array[m].Layers.Length; n++)
								{
									MyPlanetMaterialLayer[] layers2 = array[m].Layers;
									int num2 = n;
									layers2[num2].Depth = layers2[num2].Depth + depth2;
									depth2 = array[m].Layers[n].Depth;
								}
							}
							array[m].Slope.ConvertToCosine();
							array[m].Latitude.ConvertToSine();
							array[m].Longitude.ConvertToCosineLongitude();
						}
					}
					for (int i = list.Count - 1; i >= 0; i--)
						array.RemoveAtFast(list[i]);
					myPlanetMaterialGroup.MaterialRules = array;
				}
			}

			if (SoundRules != null && SoundRules.Length > 0)
			{
				def.SoundRules = new MyPlanetEnvironmentalSoundRule[SoundRules.Length];
				for (int i = 0; i < SoundRules.Length; i++)
				{
					var rule = SoundRules[i];
					var myPlanetEnvironmentalSoundRule = new MyPlanetEnvironmentalSoundRule
					{
						Latitude = rule.Latitude,
						Height = rule.Height,
						SunAngleFromZenith = rule.SunAngleFromZenith,
						EnvironmentSound = MyStringHash.GetOrCompute(rule.EnvironmentSound)
					};
					myPlanetEnvironmentalSoundRule.Latitude.ConvertToSine();
					myPlanetEnvironmentalSoundRule.SunAngleFromZenith.ConvertToCosine();
					def.SoundRules[i] = myPlanetEnvironmentalSoundRule;
				}
			}

			if (MusicCategories != null && MusicCategories.Count > 0) def.MusicCategories = MusicCategories;
			if (OreMappings != null && OreMappings.Length > 0) def.OreMappings = OreMappings;
			if (MaterialBlending.HasValue) def.MaterialBlending = MaterialBlending.Value;
			if (SurfaceDetail != null) def.Detail = SurfaceDetail;
			if (AnimalSpawnInfo != null) def.AnimalSpawnInfo = AnimalSpawnInfo;
			if (NightAnimalSpawnInfo != null) def.NightAnimalSpawnInfo = NightAnimalSpawnInfo;
			if (SectorDensity.HasValue) def.SectorDensity = SectorDensity.Value;
			if (Environment.HasValue) def.EnvironmentId = Environment.Value;
			//if (MapProvider != null) def.MapProvider = MapProvider;
			if (MinimumSurfaceLayerDepth.HasValue) def.MinimumSurfaceLayerDepth = MinimumSurfaceLayerDepth.Value;

			if (StationBlockingMaterials != null && StationBlockingMaterials.Count > 0)
			{
				def.StationBlockingMaterials.Clear();
				foreach (var material in StationBlockingMaterials)
					def.StationBlockingMaterials.Add(material);
			}

			if (DefaultSurfaceTemperature.HasValue) def.DefaultSurfaceTemperature = DefaultSurfaceTemperature.Value;
			if (WeatherGenerators != null && WeatherGenerators.Count > 0) def.WeatherGenerators = WeatherGenerators;
			if (WeatherFrequencyMin.HasValue) def.WeatherFrequencyMin = WeatherFrequencyMin.Value;
			if (WeatherFrequencyMax.HasValue) def.WeatherFrequencyMax = WeatherFrequencyMax.Value;
			if (GlobalWeather.HasValue) def.GlobalWeather = GlobalWeather.Value;
			if (Difficulty != MyStringId.NullOrEmpty) def.Difficulty = Difficulty;
		}

		private void Inherit(string generator, MyPlanetGeneratorDefinition def)
		{
			var definition = GetGenerator(generator);
			if (definition == null) return;

			def.PlanetMaps = definition.PlanetMaps;
			def.HasAtmosphere = definition.HasAtmosphere;
			def.Atmosphere = definition.Atmosphere;
			def.CloudLayers = definition.CloudLayers;
			def.SoundRules = definition.SoundRules;
			def.MusicCategories = definition.MusicCategories;
			def.HillParams = definition.HillParams;
			def.MaterialsMaxDepth = definition.MaterialsMaxDepth;
			def.MaterialsMinDepth = definition.MaterialsMinDepth;
			def.GravityFalloffPower = definition.GravityFalloffPower;
			def.HostileAtmosphereColorShift = definition.HostileAtmosphereColorShift;
			def.SurfaceMaterialTable = definition.SurfaceMaterialTable;
			def.DistortionTable = definition.DistortionTable;
			def.DefaultSurfaceMaterial = definition.DefaultSurfaceMaterial;
			def.DefaultSubSurfaceMaterial = definition.DefaultSubSurfaceMaterial;
			def.MaterialGroups = definition.MaterialGroups;
			def.MaterialEnvironmentMappings = definition.MaterialEnvironmentMappings;
			def.SurfaceGravity = definition.SurfaceGravity;
			def.AtmosphereSettings = definition.AtmosphereSettings;
			def.FolderName = definition.FolderName;
			def.MaterialBlending = definition.MaterialBlending;
			def.OreMappings = definition.OreMappings;
			def.AnimalSpawnInfo = definition.AnimalSpawnInfo;
			def.NightAnimalSpawnInfo = definition.NightAnimalSpawnInfo;
			def.Detail = definition.Detail;
			def.SectorDensity = definition.SectorDensity;
			def.DefaultSurfaceTemperature = definition.DefaultSurfaceTemperature;
			def.EnvironmentSectorType = definition.EnvironmentSectorType;
			def.MesherPostprocessing = definition.MesherPostprocessing;
			def.MinimumSurfaceLayerDepth = definition.MinimumSurfaceLayerDepth;
		}

		private void InheritCloudLayers(string generator, MyPlanetGeneratorDefinition def)
        {
			var definition = GetGenerator(generator);
			if (definition == null) return;

			def.CloudLayers = definition.CloudLayers;
        }

		private void InheritAtmosphereSettings(string generator, MyPlanetGeneratorDefinition def)
		{
			var definition = GetGenerator(generator);
			if (definition == null) return;

			def.AtmosphereSettings = definition.AtmosphereSettings;
		}

		private void InheritMesherPostprocessing(string generator, MyPlanetGeneratorDefinition def)
		{
			var definition = GetGenerator(generator);
			if (definition == null) return;

			def.MesherPostprocessing = definition.MesherPostprocessing;
		}

		private void InheritEnvironmentItems(string generator, MyPlanetGeneratorDefinition def)
		{
			var definition = GetGenerator(generator);
			if (definition == null) return;

			def.EnvironmentDefinition = definition.EnvironmentDefinition;
			def.EnvironmentSectorType = definition.EnvironmentSectorType;
			def.MaterialEnvironmentMappings = definition.MaterialEnvironmentMappings;
		}

		private MyPlanetGeneratorDefinition GetGenerator(string name)
        {
			var nameHash = MyStringHash.GetOrCompute(name);
			var definition = MyDefinitionManager.Static.GetDefinition<MyPlanetGeneratorDefinition>(nameHash);
			if (definition == null)
				Logs.WriteLine(string.Format("Could not find planet generator definition for '{0}'.", name));

			return definition;
		}
	}
}
