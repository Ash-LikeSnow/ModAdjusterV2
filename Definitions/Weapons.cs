using ModAdjusterV2.Session;
using Sandbox.Definitions;
using Sandbox.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ModAdjusterV2.Definitions
{
    public class WeaponDefinition : Definition
    {
		public MyObjectBuilder_WeaponDefinition.WeaponAmmoData ProjectileAmmoData;

		public MyObjectBuilder_WeaponDefinition.WeaponAmmoData MissileAmmoData;

		public string NoAmmoSoundName;

		public string ReloadSoundName;

		public string SecondarySoundName;

		public string PhysicalMaterial;

		public float? DeviateShotAngle;

		public float? DeviateShotAngleAiming;

		public float? ReleaseTimeAfterFire;

		public int? MuzzleFlashLifeSpan;

		public int? ReloadTime;

		[XmlArrayItem("AmmoMagazine")]
		public MyObjectBuilder_WeaponDefinition.WeaponAmmoMagazine[] AmmoMagazines;

		[XmlArrayItem("Effect")]
		public MyObjectBuilder_WeaponDefinition.WeaponEffect[] Effects;

		public bool? UseDefaultMuzzleFlash;

		public int? ShotDelay;

		public float? DamageMultiplier;

		public float? RangeMultiplier;

		public bool? UseRandomizedRange;

		public float? RecoilJetpackVertical;

		public float? RecoilJetpackHorizontal;

		public float? RecoilGroundVertical;

		public float? RecoilGroundHorizontal;

		//public List<string> RecoilMultiplierDataNames;

		//public List<float> RecoilMultiplierDataVerticals;

		//public List<float> RecoilMultiplierDataHorizontals;

		public float? RecoilResetTimeMilliseconds;

		public int? ShootDirectionUpdateTime;

		public float? EquipDuration;

		public bool? ShakeOnActionPrimary;

		public bool? ShakeOnActionSecondary;

		public bool? ShakeOnActionTertiary;

		public int? MinimumTimeBetweenIdleRotationsMs;

		public int? MaximumTimeBetweenIdleRotationsMs;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyWeaponDefinition;

			if (Effects != null && Effects.Length > 0)
            {
				def.WeaponEffects = new MyWeaponDefinition.MyWeaponEffect[Effects.Length];
				for (int i = 0; i < Effects.Length; i++)
				{
					var weaponEffect = Effects[i];
					def.WeaponEffects[i] = new MyWeaponDefinition.MyWeaponEffect(weaponEffect.Action, weaponEffect.Dummy, weaponEffect.Particle, weaponEffect.Loop, weaponEffect.InstantStop, new Vector3(weaponEffect.OffsetX, weaponEffect.OffsetY, weaponEffect.OffsetZ), weaponEffect.ParticleBirthStart, weaponEffect.ParticleBirthMin, weaponEffect.ParticleBirthMax, weaponEffect.ParticleBirthIncrease, weaponEffect.ParticleBirthDecrease, weaponEffect.DisplayOnlyOnDummyFiring);
				}
			}
			if (!string.IsNullOrEmpty(PhysicalMaterial)) def.PhysicalMaterial = MyStringHash.GetOrCompute(PhysicalMaterial);
			if (UseDefaultMuzzleFlash.HasValue) def.UseDefaultMuzzleFlash = UseDefaultMuzzleFlash.Value;
			if (!string.IsNullOrEmpty(NoAmmoSoundName)) def.NoAmmoSound = new MySoundPair(NoAmmoSoundName, true);
			if (!string.IsNullOrEmpty(ReloadSoundName)) def.ReloadSound = new MySoundPair(ReloadSoundName, true);
			if (!string.IsNullOrEmpty(SecondarySoundName)) def.SecondarySound = new MySoundPair(SecondarySoundName, true);
			if (DeviateShotAngle.HasValue) def.DeviateShotAngle = MathHelper.ToRadians(DeviateShotAngle.Value);
			if (DeviateShotAngleAiming.HasValue) def.DeviateShotAngleAiming = MathHelper.ToRadians(DeviateShotAngleAiming.Value);
			if (ShotDelay.HasValue) def.ShotDelay = ShotDelay.Value;
			if (ReleaseTimeAfterFire.HasValue) def.ReleaseTimeAfterFire = ReleaseTimeAfterFire.Value;
			if (MuzzleFlashLifeSpan.HasValue) def.MuzzleFlashLifeSpan = MuzzleFlashLifeSpan.Value;
			if (ReloadTime.HasValue) def.ReloadTime = ReloadTime.Value;
			if (DamageMultiplier.HasValue) def.DamageMultiplier = DamageMultiplier.Value;
			if (RangeMultiplier.HasValue) def.RangeMultiplier = RangeMultiplier.Value;
			if (UseRandomizedRange.HasValue) def.UseRandomizedRange = UseRandomizedRange.Value;
			if (MinimumTimeBetweenIdleRotationsMs.HasValue) def.MinimumTimeBetweenIdleRotationsMs = MinimumTimeBetweenIdleRotationsMs.Value;
			if (MaximumTimeBetweenIdleRotationsMs.HasValue) def.MaximumTimeBetweenIdleRotationsMs = MaximumTimeBetweenIdleRotationsMs.Value;
			if (RecoilJetpackVertical.HasValue) def.RecoilJetpackVertical = RecoilJetpackVertical.Value;
			if (RecoilJetpackHorizontal.HasValue) def.RecoilJetpackHorizontal = RecoilJetpackHorizontal.Value;
			if (RecoilGroundVertical.HasValue) def.RecoilGroundVertical = RecoilGroundVertical.Value;
			if (RecoilGroundHorizontal.HasValue) def.RecoilGroundHorizontal = RecoilGroundHorizontal.Value;
			if (RecoilResetTimeMilliseconds.HasValue) def.RecoilResetTimeMilliseconds = RecoilResetTimeMilliseconds.Value;
			if (ShootDirectionUpdateTime.HasValue) def.ShootDirectionUpdateTime = ShootDirectionUpdateTime.Value;
			if (EquipDuration.HasValue) def.EquipDuration = EquipDuration.Value;
			if (ShakeOnActionPrimary.HasValue) def.ShakeOnAction[MyShootActionEnum.PrimaryAction] = ShakeOnActionPrimary.Value;
			if (ShakeOnActionSecondary.HasValue) def.ShakeOnAction[MyShootActionEnum.SecondaryAction] = ShakeOnActionSecondary.Value;
			if (ShakeOnActionTertiary.HasValue) def.ShakeOnAction[MyShootActionEnum.TertiaryAction] = ShakeOnActionTertiary.Value;

			if (AmmoMagazines != null && AmmoMagazines.Length > 0)
			{
				def.AmmoMagazinesId = new MyDefinitionId[AmmoMagazines.Length];
				for (int j = 0; j < def.AmmoMagazinesId.Length; j++)
				{
					MyObjectBuilder_WeaponDefinition.WeaponAmmoMagazine weaponAmmoMagazine = AmmoMagazines[j];
					def.AmmoMagazinesId[j] = new MyDefinitionId(weaponAmmoMagazine.Type, weaponAmmoMagazine.Subtype);
					MyAmmoMagazineDefinition ammoMagazineDefinition = MyDefinitionManager.Static.GetAmmoMagazineDefinition(def.AmmoMagazinesId[j]);
					MyAmmoType ammoType = MyDefinitionManager.Static.GetAmmoDefinition(ammoMagazineDefinition.AmmoDefinitionId).AmmoType;
					if (ammoType != MyAmmoType.HighSpeed)
					{
						if (ammoType != MyAmmoType.Missile)
						{
							Logs.WriteLine("Invalid ammoType for weapon: " + def.Id);
							continue;
						}
						if (MissileAmmoData != null)
						{
							def.WeaponAmmoDatas[1] = new MyWeaponDefinition.MyWeaponAmmoData(MissileAmmoData);
						}
					}
					else if (ProjectileAmmoData != null)
					{
						def.WeaponAmmoDatas[0] = new MyWeaponDefinition.MyWeaponAmmoData(ProjectileAmmoData);
					}
				}
			}

		}
    }
}
