using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Utils;
using VRage;
using VRageMath;
using VRage.Game;
using Sandbox.Definitions.GUI;
using ModAdjusterV2.Session;

namespace ModAdjusterV2.Definitions
{
    public class HudDefinition : Definition
    {
        //[XmlArrayItem("StatControl")]
        //public MyObjectBuilder_StatControls[] StatControls;

        //public MyObjectBuilder_ToolbarControlVisualStyle Toolbar;

        //public MyObjectBuilder_GravityIndicatorVisualStyle GravityIndicator;

        //public MyObjectBuilder_CrosshairStyle Crosshair;

        //public MyObjectBuilder_TargetingMarkersStyle TargetingMarkers;

        //public Vector2I? OptimalScreenRatio;

        //public float? CustomUIScale;

        //public MyStringHash? VisorOverlayTexture;

        //public MyObjectBuilder_DPadControlVisualStyle DPad;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyHudDefinition;

            var ob = GetObjectBuilder(def);

            Logs.WriteLine($"StatControls has length {def.StatControls.Length} before init - {def.DisplayNameString}");

            ob.StatControls = new MyObjectBuilder_StatControls[1] { def.StatControls[0] };
            ob.DisplayName = "AAAAA";
            def.Init(ob, def.Context);

            Logs.WriteLine($"StatControls has length {def.StatControls.Length} after init - {def.DisplayNameString}");
            //if (StatControls != null && StatControls.Length > 0)
            //{
            //    for (int i = 0; i < StatControls.Length; i++)
            //    {
            //        def.StatControls.Append(StatControls[i]);
            //    }
            //}

        }

        private MyObjectBuilder_HudDefinition GetObjectBuilder(MyHudDefinition def)
        {
            var ob = (MyObjectBuilder_HudDefinition)def.GetObjectBuilder();

            ob.StatControls = def.StatControls;
            ob.Toolbar = def.Toolbar;
            ob.GravityIndicator = def.GravityIndicator;
            ob.Crosshair = def.Crosshair;
            ob.TargetingMarkers = def.TargetingMarkers;
            ob.OptimalScreenRatio = def.OptimalScreenRatio;
            ob.CustomUIScale = def.CustomUIScale;
            ob.VisorOverlayTexture = def.VisorOverlayTexture;
            ob.DPad = def.DPad;

            return ob;
        }
    }
}
