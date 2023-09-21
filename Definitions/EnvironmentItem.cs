using Sandbox.Definitions;
using System.Xml.Serialization;
using VRage.Game;

namespace ModAdjusterV2.Definitions
{
    [XmlInclude(typeof(TreeDefinition))]
    public class EnvironmentItemDefinition : PhysicalModelDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

    public class TreeDefinition : EnvironmentItemDefinition
    {
		public float? BranchesStartHeight;

		public float? HitPoints;

		public string CutEffect;

		public string FallSound;

		public string BreakSound;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyTreeDefinition;

            if (BranchesStartHeight.HasValue) def.BranchesStartHeight = BranchesStartHeight.Value;
            if (HitPoints.HasValue) def.HitPoints = HitPoints.Value;
            if (!string.IsNullOrEmpty(CutEffect)) def.CutEffect = CutEffect;
            if (!string.IsNullOrEmpty(FallSound)) def.FallSound = FallSound;
            if (!string.IsNullOrEmpty(BreakSound)) def.BreakSound = BreakSound;
        }
    }
}
