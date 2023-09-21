using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game;

namespace ModAdjusterV2.Definitions
{
    public class PrefabDefinition : Definition
    {
		//obsolete
		//public bool? RespawnShip;

		//public MyObjectBuilder_CubeGrid CubeGrid;

		//[XmlArrayItem("CubeGrid")]
		//public MyObjectBuilder_CubeGrid[] CubeGrids;

		public string PrefabPath;

		public MyEnvironmentTypes? EnvironmentType;

		public string TooltipImage;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyPrefabDefinition;

			var ob = (MyObjectBuilder_PrefabDefinition)def.GetObjectBuilder();

			//var grids = CubeGrids != null && CubeGrids.Length > 0 ? CubeGrids : CubeGrid != null ? new MyObjectBuilder_CubeGrid[] { CubeGrid } : def.CubeGrids;
			//ob.CubeGrids = grids;
			ob.CubeGrids = def.CubeGrids;

			ob.PrefabPath = !string.IsNullOrEmpty(PrefabPath) ? PrefabPath : def.PrefabPath;
			ob.EnvironmentType = EnvironmentType.HasValue ? EnvironmentType.Value : def.EnvironmentType;
			ob.TooltipImage = !string.IsNullOrEmpty(TooltipImage) ? TooltipImage : def.TooltipImage;

			def.InitLazy(ob);
		}
	}
}
