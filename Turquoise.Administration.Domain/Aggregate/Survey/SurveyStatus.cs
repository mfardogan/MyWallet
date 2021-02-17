using System.ComponentModel;

namespace Turquoise.Administration.Domain.Aggregate.Survey
{
    public enum SurveyStatus : byte
    {
        [Description("Continuing")] Continuing,
        [Description("Locked")] Locked,
        [Description("Finalized")] Finalized
    }
}
