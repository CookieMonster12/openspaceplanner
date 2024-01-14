using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;
public record SurveyItem(
    string Id,
    string Text,
    ISurveyItemRatingBase Rating);
