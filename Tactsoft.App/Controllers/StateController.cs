using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.StateOperation.Command;
using Tactsoft.Application.Features.StateOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;

[AllowAnonymous]
public class StateController : BaseController
{
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(long? countryId = null, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetStateDropdown(countryId, searchText)));
    }

    [HttpGet("search")]
    public async Task<ActionResult<StateVM>> GetSerchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetStateSearch(pageIndex, pageSize, searchText)));
    }

    [HttpGet("id")]
    public async Task<ActionResult<StateVM>> GetDetailsAsync(int id)
    {
        return await Mediator.Send(new GetStateDetails(id));
    }

    [HttpPost]
    public async Task<ActionResult<StateVM>> InsertAsync([FromQuery] StateVM model)
    {
        return await Mediator.Send(new CreateState(model));
    }

    [HttpPut("id")]
    public async Task<ActionResult<StateVM>> UpdateAsync(int id, StateVM model)
    {
        return await Mediator.Send(new UpdateState(id, model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<StateVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteState(id));
    }
}
