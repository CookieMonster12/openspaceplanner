using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;
public abstract class SurveyItemRatingBase<T> : ISurveyItemRatingBase
{
    protected SurveyItemRatingBase(SurveyItemRatingType ratingType, T ratingValue)
    {
        RatingType = ratingType;
        RatingValue = ratingValue;
    }

    public SurveyItemRatingType RatingType { get; set; }

    public virtual T RatingValue { get; set; }
}
