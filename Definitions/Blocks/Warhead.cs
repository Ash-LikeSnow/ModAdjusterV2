using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRage.Game;

namespace ModAdjusterV2.Definitions.Blocks
{
    public class WarheadDefinition : CubeBlockDefinition
    {
        public float? ExplosionRadius;

        public float? WarheadExplosionDamage;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyWarheadDefinition;

            if (ExplosionRadius.HasValue) def.ExplosionRadius = ExplosionRadius.Value;
            if (WarheadExplosionDamage.HasValue) def.WarheadExplosionDamage = WarheadExplosionDamage.Value;
        }
    }
}
