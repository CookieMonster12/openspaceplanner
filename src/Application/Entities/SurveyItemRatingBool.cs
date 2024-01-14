using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;
public class SurveyItemRatingBool : SurveyItemRatingBase<bool>
{
    public SurveyItemRatingBool(SurveyItemRatingType ratingType, bool ratingValue)
        : base(ratingType, ratingValue)
    {
    }
}
