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
    public class ContainerTypeDefinition : Definition
    {
		[XmlAttribute]
		public int CountMin;

		[XmlAttribute]
		public int CountMax;

		[XmlArrayItem("Item")]
		public MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] Items;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyContainerTypeDefinition;

            var ob = GetObjectBuilder(definitionBase);
            ob.CountMin = def.CountMin;
            ob.CountMax = def.CountMax;
            ob.Items = Items;

            def.Init(ob, def.Context);
        }

        public MyObjectBuilder_ContainerTypeDefinition GetObjectBuilder(MyDefinitionBase def)
        {
            var ob = (MyObjectBuilder_ContainerTypeDefinition)def.GetObjectBuilder();

            return ob;
        }
    }

    public class DropContainerDefinition : Definition
    {
        public string Prefab;

        public MyContainerSpawnRules SpawnRules;

        public float? Priority;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyDropContainerDefinition;

            if (!string.IsNullOrEmpty(Prefab)) def.Prefab = MyDefinitionManager.Static.GetPrefabDefinition(Prefab);
            if (SpawnRules != null) def.SpawnRules = SpawnRules;
            if (Priority.HasValue) def.Priority = Priority.Value;
        }
    }
}
