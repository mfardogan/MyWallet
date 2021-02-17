using System.ComponentModel;

namespace Turquoise.Administration.Domain.Aggregate.SurveyAnswer
{
    public enum DrawingType : byte
    {
        [Description("Free")] Free,
        [Description("Square")] Square,
        [Description("Circle")] Circle,
        [Description("Triangle")] Triangle
    }
}
