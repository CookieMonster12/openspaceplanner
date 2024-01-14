using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SurveyItemRatingType
{
    /// <summary>
    /// Represents an interval type of rating (0 to 5).
    /// </summary>
    Interval = 0,

    /// <summary>
    /// Represents a type of rating consisting of two possible answers: Yes and No.
    /// </summary>
    YesNo = 1,
}
