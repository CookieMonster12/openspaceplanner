using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpace.Application.Entities;
public record Survey(
    string Id,
    string Name,
    ICollection<SurveyItem> SurveyItems);
