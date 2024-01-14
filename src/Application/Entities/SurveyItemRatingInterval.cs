using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;
public class SurveyItemRatingInterval : SurveyItemRatingBase<int>
{
    private int _ratingValue;

    public SurveyItemRatingInterval(SurveyItemRatingType ratingType, int ratingValue)
        : base(ratingType, ratingValue)
    {
    }

    public override int RatingValue
    {
        get => _ratingValue;

        set
        {
            if (RatingType == SurveyItemRatingType.Interval && IsValidRatingValue(value))
            {
                _ratingValue = value;
            }
        }
    }

    // Checks whether the given rating value is within the valid rating interval.
    private bool IsValidRatingValue(int value) => value >= 0 && value <= 5;
}
