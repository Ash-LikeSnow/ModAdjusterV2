using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions
{
    [XmlInclude(typeof(Dx11VoxelMaterialDefinition))]
    public class VoxelMaterialDefinition : Definition
    {
		public string MaterialTypeName;

		public string MinedOre;

		public float? MinedOreRatio;

		public bool? CanBeHarvested;

		public bool? IsRare;

		//public bool? UseTwoTextures;

		public string VoxelHandPreview;

		public int? MinVersion;

		public int? MaxVersion;

		public bool? SpawnsInAsteroids;

		public bool? SpawnsFromMeteorites;

		public string DamagedMaterial;

		public float? Friction;

		public float? Restitution;

		public ColorDefinitionRGBA? ColorKey;

		public string LandingEffect;

		public int? AsteroidGeneratorSpawnProbabilityMultiplier;

		public string BareVariant;

		public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyVoxelMaterialDefinition;

			if (!string.IsNullOrEmpty(MaterialTypeName)) def.MaterialTypeName = MaterialTypeName;
			if (!string.IsNullOrEmpty(MinedOre)) def.MinedOre = MinedOre;
			if (MinedOreRatio.HasValue) def.MinedOreRatio = MinedOreRatio.Value;
			if (CanBeHarvested.HasValue) def.CanBeHarvested = CanBeHarvested.Value;
			if (IsRare.HasValue) def.IsRare = IsRare.Value;
			if (!string.IsNullOrEmpty(VoxelHandPreview)) def.VoxelHandPreview = VoxelHandPreview;
			if (MinVersion.HasValue) def.MinVersion = MinVersion.Value;
			if (MaxVersion.HasValue) def.MaxVersion = MaxVersion.Value;
			if (SpawnsInAsteroids.HasValue) def.SpawnsInAsteroids = SpawnsInAsteroids.Value;
			if (SpawnsFromMeteorites.HasValue) def.SpawnsFromMeteorites = SpawnsFromMeteorites.Value;
			if (!string.IsNullOrEmpty(DamagedMaterial)) def.DamagedMaterial = MyStringHash.GetOrCompute(DamagedMaterial);
			if (Friction.HasValue) def.Friction = Friction.Value;
			if (Restitution.HasValue) def.Restitution = Restitution.Value;
			if (ColorKey.HasValue) def.ColorKey = new Vector3?(ColorExtensions.ColorToHSV(ColorKey.Value));
			if (!string.IsNullOrEmpty(LandingEffect)) def.LandingEffect = LandingEffect;
			if (AsteroidGeneratorSpawnProbabilityMultiplier.HasValue) def.AsteroidGeneratorSpawnProbabilityMultiplier = AsteroidGeneratorSpawnProbabilityMultiplier.Value;
			if (!string.IsNullOrEmpty(BareVariant)) def.BareVariant = BareVariant;
		}
    }

	public class Dx11VoxelMaterialDefinition : VoxelMaterialDefinition
    {
        //public string ColorMetalXZnY;

        //public string ColorMetalY;

        //public string NormalGlossXZnY;

        //public string NormalGlossY;

        //public string ExtXZnY;

        //public string ExtY;

        //public string ColorMetalXZnYFar1;

        //public string ColorMetalYFar1;

        //public string NormalGlossXZnYFar1;

        //public string NormalGlossYFar1;

        //public float Scale;

        //public float ScaleFar1;

        //public string ExtXZnYFar1;

        //public string ExtYFar1;

        //public string FoliageTextureArray1;

        //public string FoliageTextureArray2;

        //[XmlArrayItem("Color")]
        //public string[] FoliageColorTextureArray;

        //[XmlArrayItem("Normal")]
        //public string[] FoliageNormalTextureArray;

        //public float FoliageDensity;

        //public Vector2 FoliageScale;

        //public float FoliageRandomRescaleMult;

        //public int FoliageType;

        //public byte BiomeValueMin;

        //public byte BiomeValueMax;

        //public string ColorMetalXZnYFar2;

        //public string ColorMetalYFar2;

        //public string NormalGlossXZnYFar2;

        //public string NormalGlossYFar2;

        //public string ExtXZnYFar2;

        //public string ExtYFar2;

        //public float InitialScale;

        //public float ScaleMultiplier;

        //public float InitialDistance;

        //public float DistanceMultiplier;

        //public float TilingScale;

        //public float Far1Distance;

        //public float Far2Distance;

        //public float Far3Distance;

        //public float Far1Scale;

        //public float Far2Scale;

        //public float Far3Scale;

        //public Vector4 Far3Color;

        //public float ExtDetailScale;

        //public TilingSetup SimpleTilingSetup;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyDx11VoxelMaterialDefinition;
        }
    }
}
