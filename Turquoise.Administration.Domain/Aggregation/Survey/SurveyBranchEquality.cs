using System.Collections.Generic;

namespace Turquoise.Administration.Domain.Aggregation.Survey
{
    public class SurveyBranchEquality : IEqualityComparer<SurveyBranch>
    {
        bool IEqualityComparer<SurveyBranch>.Equals(SurveyBranch x, SurveyBranch y)
        {
            return x.BranchId.Equals(y.BranchId);
        }

        int IEqualityComparer<SurveyBranch>.GetHashCode(SurveyBranch obj)
        {
            return obj.BranchId.GetHashCode();
        }
    }
}
