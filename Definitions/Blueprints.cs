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
	[XmlInclude(typeof(BlockBlueprintDefinition))]
	[XmlInclude(typeof(RepairBlueprintDefinition))]
	public class BlueprintDefinition : Definition
    {
		[XmlArrayItem("Item")]
		public BlueprintItem[] Prerequisites;

		public BlueprintItem Result;

		[XmlArrayItem("Item")]
		public BlueprintItem[] Results;

        public float? BaseProductionTimeInSeconds;

		public string ProgressBarSoundCue;

		public bool? IsPrimary;

		public int? Priority;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyBlueprintDefinition;

			if (Prerequisites != null)
            {
				def.Prerequisites = new MyBlueprintDefinitionBase.Item[Prerequisites.Length];
				for (int i = 0; i < def.Prerequisites.Length; i++)
				{
					def.Prerequisites[i] = MyBlueprintDefinitionBase.Item.FromObjectBuilder(Prerequisites[i]);
				}
			}

			if (Result != null)
			{
				def.Results = new MyBlueprintDefinitionBase.Item[1];
				def.Results[0] = MyBlueprintDefinitionBase.Item.FromObjectBuilder(Result);
			}
			else if (Results != null)
			{
				def.Results = new MyBlueprintDefinitionBase.Item[Results.Length];
				for (int j = 0; j < def.Results.Length; j++)
				{
					def.Results[j] = MyBlueprintDefinitionBase.Item.FromObjectBuilder(Results[j]);
				}
			}

			if (BaseProductionTimeInSeconds.HasValue) def.BaseProductionTimeInSeconds = BaseProductionTimeInSeconds.Value;
			if (!string.IsNullOrEmpty(ProgressBarSoundCue)) def.ProgressBarSoundCue = ProgressBarSoundCue;
			if (IsPrimary.HasValue) def.IsPrimary = IsPrimary.Value;
			if (Priority.HasValue) def.Priority = Priority.Value;
		}
    }

	public class BlockBlueprintDefinition : BlueprintDefinition
    {
        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);
        }
    }

	public class RepairBlueprintDefinition : BlueprintDefinition
    {
		public float? RepairAmount;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

			var def = definitionBase as MyRepairBlueprintDefinition;

			if (RepairAmount.HasValue) def.RepairAmount = RepairAmount.Value;
        }
    }

	public class BlueprintClassDefinition : Definition
    {
        public string HighlightIcon;

        public string FocusIcon;

        public string InputConstraintIcon;

        public string OutputConstraintIcon;

        public string ProgressBarSoundCue;

        public override void Load(MyDefinitionBase definitionBase, string path = null)
        {
            base.Load(definitionBase, path);

            var def = definitionBase as MyBlueprintClassDefinition;

            if (!string.IsNullOrEmpty(HighlightIcon)) def.HighlightIcon = HighlightIcon;
            if (!string.IsNullOrEmpty(FocusIcon)) def.FocusIcon = FocusIcon;
            if (!string.IsNullOrEmpty(InputConstraintIcon)) def.InputConstraintIcon = InputConstraintIcon;
            if (!string.IsNullOrEmpty(OutputConstraintIcon)) def.OutputConstraintIcon = OutputConstraintIcon;
            if (!string.IsNullOrEmpty(ProgressBarSoundCue)) def.ProgressBarSoundCue = ProgressBarSoundCue;
        }
    }
}
