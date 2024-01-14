using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OpenSpace.Application.Entities;
using OpenSpace.Application.Exceptions;
using OpenSpace.Application.Repositories;
using OpenSpace.WebApi.Hubs;

namespace OpenSpace.WebApi.Controllers;

[Route("api/sessions/{sessionId:int}/surveys")]
public class SessionSurveysController : Controller
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IHubContext<SessionsHub, ISessionsHub> _sessionsHub;

    public SessionSurveysController(ISessionRepository sessionRepository, IHubContext<SessionsHub, ISessionsHub> sessionsHub)
    {
        _sessionRepository = sessionRepository;
        _sessionsHub = sessionsHub;
    }

    [HttpPost]
    public async Task<Survey> AddSurveyAsync(int sessionId, [FromBody] Survey survey)
    {
        var currentSession = await _sessionRepository.Get(sessionId);

        await _sessionRepository.Update(sessionId, (session) =>
        {
            survey = survey with
            {
                Id = Guid.NewGuid().ToString(),
                Name = string.IsNullOrWhiteSpace(survey.Name) ? "Survey " + (session.Surveys.Count + 1) : survey.Name,
                SurveyItems = new List<SurveyItem>(),
            };

            session.Surveys.Add(survey);
        });

        await _sessionsHub.Clients.Group(sessionId.ToString()).UpdateSession(currentSession);

        return survey;
    }

    [HttpDelete("{surveyId}")]
    public async Task DeleteSurveyAsync(int sessionId, string surveyId)
    {
        await _sessionRepository.Update(sessionId, (session) =>
        {
            var currentSurvey = session.Surveys.FirstOrDefault(s => s.Id == surveyId) ?? throw new EntityNotFoundException("Survey not found");
            session.Surveys.Remove(currentSurvey);
        });
        await _sessionsHub.Clients.Group(sessionId.ToString()).DeleteSurvey(surveyId);
    }

    [HttpPut("{surveyId}")]
    public async Task<Survey> UpdateSurveyAsync(int sessionId, string surveyId, [FromBody] Survey survey)
    {
        if (string.IsNullOrWhiteSpace(survey.Name))
        {
            throw new InvalidInputException("Survey name is empty");
        }

        await _sessionRepository.Update(sessionId, (session) =>
        {
            var currentSurvey = session.Surveys.FirstOrDefault(s => s.Id == surveyId) ?? throw new EntityNotFoundException("Survey not found");
            session.Surveys.Remove(currentSurvey);
            session.Surveys.Add(survey);
        });

        await _sessionsHub.Clients.Group(sessionId.ToString()).UpdateSurvey(survey);

        return survey;
    }
}
