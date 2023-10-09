using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.CityOperation.Command;
using Tactsoft.Application.Features.CityOperation.Query;
using Tactsoft.Application.Features.StateOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;

[AllowAnonymous]
public class CityController : BaseController
{
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(long? stateId = null, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetCityDropdown(stateId, searchText)));
    }

    [HttpGet("search")]
    public async Task<ActionResult<CityVM>> GetListAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetCitySearch(pageIndex, pageSize, searchText)));
    }

    [HttpGet("id")]
    public async Task<ActionResult<CityVM>> GetByIdAsync(int id)
    {
        return await Mediator.Send(new GetCityDetails(id));
    }

    [HttpPost]
    public async Task<ActionResult<CityVM>> PostAsync([FromQuery] CityVM model)
    {
        return await Mediator.Send(new CreateCity(model));
    }

    [HttpPut("id")]
    public async Task<ActionResult<CityVM>> PutAsync(int id, CityVM model)
    {
        return await Mediator.Send(new UpdateCity(id, model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<CityVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteCity(id));
    }
}
