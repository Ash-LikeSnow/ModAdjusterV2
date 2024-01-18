using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions
{
	[XmlInclude(typeof(MissileAmmoDefinition))]
	[XmlInclude(typeof(ProjectileAmmoDefinition))]
	public class AmmoDefinition : Definition
	{
		public AmmoBasicProperties BasicProperties;

		public class AmmoBasicProperties
		{
			public float? DesiredSpeed;

			public float? SpeedVariance;

			public float? MaxTrajectory;

			public float? BackkickForce;

			public float? ExplosiveDamageMultiplier;

			public bool? IsExplosive;

			public string PhysicalMaterial;

			public void Load(MyAmmoDefinition def)
			{
				if (DesiredSpeed.HasValue) def.DesiredSpeed = DesiredSpeed.Value;
				if (SpeedVariance.HasValue) def.SpeedVar = MathHelper.Clamp(SpeedVariance.Value, 0f, 1f);
				if (MaxTrajectory.HasValue) def.MaxTrajectory = MaxTrajectory.Value;
				if (BackkickForce.HasValue) def.BackkickForce = BackkickForce.Value;
				if (ExplosiveDamageMultiplier.HasValue) def.ExplosiveDamageMultiplier = ExplosiveDamageMultiplier.Value;
				if (IsExplosive.HasValue) def.IsExplosive = IsExplosive.Value;
				if (!string.IsNullOrEmpty(PhysicalMaterial)) def.PhysicalMaterial = MyStringHash.GetOrCompute(PhysicalMaterial);
			}
		}

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyAmmoDefinition;

			if (BasicProperties != null) BasicProperties.Load(def);
        }
    }

	public class MissileAmmoDefinition : AmmoDefinition
    {
		public AmmoMissileProperties MissileProperties;

		public class AmmoMissileProperties
		{
			public string MissileModelName;

			public string MissileTrailEffect;

			public bool? MissileSkipAcceleration;

			public bool? MissileGravityEnabled;

			public float? MissileMass;

			public float? MissileAcceleration;

			public float? MissileInitialSpeed;

			public float? MissileExplosionRadius;

			public float? MissileExplosionDamage;

			public float? MissileHealthPool;

			public float? MissileMinRicochetAngle;

			public float? MissileMaxRicochetAngle;

			public float? MissileRicochetDamage;

			public float? MissileMinRicochetProbability;

			public float? MissileMaxRicochetProbability;

			public void Load(MyMissileAmmoDefinition def)
            {
				if (!string.IsNullOrEmpty(MissileModelName)) def.MissileModelName = MissileModelName;
				if (!string.IsNullOrEmpty(MissileTrailEffect)) def.MissileTrailEffect = MissileTrailEffect;
				if (MissileSkipAcceleration.HasValue) def.MissileSkipAcceleration = MissileSkipAcceleration.Value;
				if (MissileGravityEnabled.HasValue) def.MissileGravityEnabled = MissileGravityEnabled.Value;
				if (MissileMass.HasValue) def.MissileMass = MissileMass.Value;
				if (MissileAcceleration.HasValue) def.MissileAcceleration = MissileAcceleration.Value;
				if (MissileInitialSpeed.HasValue) def.MissileInitialSpeed = MissileInitialSpeed.Value;
				if (MissileExplosionRadius.HasValue) def.MissileExplosionRadius = MissileExplosionRadius.Value;
				if (MissileExplosionDamage.HasValue) def.MissileExplosionDamage = MissileExplosionDamage.Value;
				if (MissileHealthPool.HasValue) def.MissileHealthPool = MissileHealthPool.Value;
				if (MissileMinRicochetAngle.HasValue) def.MissileMinRicochetAngle = MissileMinRicochetAngle.Value;
				if (MissileMaxRicochetAngle.HasValue) def.MissileMaxRicochetAngle = MissileMaxRicochetAngle.Value;
				if (MissileRicochetDamage.HasValue) def.MissileRicochetDamage = MissileRicochetDamage.Value;
				if (MissileMinRicochetProbability.HasValue) def.MissileMinRicochetProbability = MissileMinRicochetProbability.Value;
				if (MissileMaxRicochetProbability.HasValue) def.MissileMaxRicochetProbability = MissileMaxRicochetProbability.Value;
			}
		}

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyMissileAmmoDefinition;

			if (MissileProperties != null) MissileProperties.Load(def);
        }
    }

	public class ProjectileAmmoDefinition : AmmoDefinition
	{
		public AmmoProjectileProperties ProjectileProperties;

		public class AmmoProjectileProperties
		{
			public string ProjectileTrailMaterial;

			public string ProjectileOnHitEffectName;

			public bool? HeadShot;

			public SerializableVector3? ProjectileTrailColor;

			public float? ProjectileHitImpulse;

			public float? ProjectileTrailScale;

			public float? ProjectileTrailProbability;

			public float? ProjectileMassDamage;

			public float? ProjectileHealthDamage;

			public float? ProjectileHeadShotDamage;

			public float? ProjectileExplosionRadius;

			public float? ProjectileExplosionDamage;

			public int? ProjectileCount;

			public void Load(MyProjectileAmmoDefinition def)
            {
				if (!string.IsNullOrEmpty(ProjectileTrailMaterial))
				{
					def.ProjectileTrailMaterial = ProjectileTrailMaterial;
					def.ProjectileTrailMaterialId = MyStringId.GetOrCompute(ProjectileTrailMaterial);
				}

				if (!string.IsNullOrEmpty(ProjectileOnHitEffectName)) def.ProjectileOnHitEffectName = ProjectileOnHitEffectName;
				if (HeadShot.HasValue) def.HeadShot = HeadShot.Value;
				if (ProjectileTrailColor.HasValue) def.ProjectileTrailColor = ProjectileTrailColor.Value;
				if (ProjectileHitImpulse.HasValue) def.ProjectileHitImpulse = ProjectileHitImpulse.Value;
				if (ProjectileTrailScale.HasValue) def.ProjectileTrailScale = ProjectileTrailScale.Value;
				if (ProjectileTrailProbability.HasValue) def.ProjectileTrailProbability = ProjectileTrailProbability.Value;
				if (ProjectileMassDamage.HasValue) def.ProjectileMassDamage = ProjectileMassDamage.Value;
				if (ProjectileHealthDamage.HasValue) def.ProjectileHealthDamage = ProjectileHealthDamage.Value;
				if (ProjectileHeadShotDamage.HasValue) def.ProjectileHeadShotDamage = ProjectileHeadShotDamage.Value;
				if (ProjectileExplosionRadius.HasValue) def.ProjectileExplosionRadius = ProjectileExplosionRadius.Value;
				if (ProjectileExplosionDamage.HasValue) def.ProjectileExplosionDamage = ProjectileExplosionDamage.Value;
				if (ProjectileCount.HasValue) def.ProjectileCount = ProjectileCount.Value;
            }
		}

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyProjectileAmmoDefinition;

			if (ProjectileProperties != null) ProjectileProperties.Load(def);
        }
    }
}
