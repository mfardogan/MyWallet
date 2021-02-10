using System.ComponentModel;

namespace Turquoise.Administration.Domain.Aggregation.Survey
{
    public enum SurveyStatus : byte
    {
        [Description("Continuing")] Continuing,
        [Description("Locked")] Locked,
        [Description("Finalized")] Finalized
    }
}
