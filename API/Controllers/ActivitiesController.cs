using Application.Activities.Commands;
using Application.Activities.Core;
using Application.Activities.DTOs;
using Application.Activities.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedList<ActivityDto, DateTime?>>> GetActivities(
        [FromQuery]ActivityParams activityParams)
    {
        var query = new GetActivityList.Query(;
        query.Params = activityParams;
        return HandleResult(await Mediator.Send(query));
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivityDetail(string id)
    {
        return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto)
    {
        return HandleResult(
            await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto })
        );
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "IsActivityHost")]
    public async Task<ActionResult> EditActivity(string id, EditActivityDto activity)
    {
        activity.Id = id;
        return HandleResult(
            await Mediator.Send(new EditActivity.Command { ActivityDto = activity })
        );
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "IsActivityHost")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
    }

    // [HttpPost("{id}/attend")]
    // public async Task<ActionResult> Attend(string id)
    // {
    //     return BadRequest("Testing 123");
    //     return HandleResult(await Mediator.Send(new UpdateAtendance.Command { Id = id}));
    // }
}