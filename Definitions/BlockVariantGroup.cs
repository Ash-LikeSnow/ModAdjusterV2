using ModAdjusterV2.Session;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;

namespace ModAdjusterV2.Definitions
{
    public class BlockVariantGroup : Definition
    {
        [XmlArrayItem("Block")]
        public SerializableDefinitionId[] Blocks;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            if (Blocks == null)
                return;

            var def = definitionBase as MyBlockVariantGroup;

            ResolveBlocks(def, Blocks);
            def.Postprocess();
        }

        public void ResolveBlocks(MyBlockVariantGroup def, SerializableDefinitionId[] blocks)
        {
            def.Blocks = new MyCubeBlockDefinition[blocks.Length];

            bool flag = false;
            for (int i = 0; i < blocks.Length; i++)
            {
                SerializableDefinitionId v = blocks[i];
                MyCubeBlockDefinition myCubeBlockDefinition;
                if (MyDefinitionManager.Static.TryGetDefinition(v, out myCubeBlockDefinition))
                {
                    def.Blocks[i] = myCubeBlockDefinition;
                    continue;
                }
                flag = true;
            }

            if (flag)
            {
                def.Blocks = (from x in def.Blocks
                              where x != null
                              select x).ToArray();
            }
        }
    }

    public class GuiBlockCategoryDefinition : Definition
    {
		public string Name;

		public string[] ItemIds;

		public bool? IsShipCategory;

		public bool? IsBlockCategory;

		public bool? SearchBlocks;

		public bool? IsAnimationCategory;

		public bool? IsToolCategory;

		public bool? ShowAnimations;

		public bool? ShowInCreative;

		public bool? StrictSearch;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyGuiBlockCategoryDefinition;

            if (ItemIds != null) def.ItemIds = new HashSet<string>(ItemIds);
            if (IsShipCategory.HasValue) def.IsShipCategory = IsShipCategory.Value;
            if (IsBlockCategory.HasValue) def.IsBlockCategory = IsBlockCategory.Value;
            if (SearchBlocks.HasValue) def.SearchBlocks = SearchBlocks.Value;
            if (IsAnimationCategory.HasValue) def.IsAnimationCategory = IsAnimationCategory.Value;
            if (IsToolCategory.HasValue) def.IsToolCategory = IsToolCategory.Value;
            if (ShowAnimations.HasValue) def.ShowAnimations = ShowAnimations.Value;
            if (ShowInCreative.HasValue) def.ShowInCreative = ShowInCreative.Value;
            if (StrictSearch.HasValue) def.StrictSearch = StrictSearch.Value;

        }
    }
}
