using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.CountryOperation.Command;
using Tactsoft.Application.Features.CountryOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;

[AllowAnonymous]
public class CountryController : BaseController
{
    [HttpGet("dropdown")]
    public async Task<ActionResult<CountryVM>> GetDropdownAsync(string SearchText = null)
    {
        return Ok(await Mediator.Send(new GetCountryDropdown(SearchText)));
    }

    [HttpGet("search")]
    public async Task<ActionResult<CountryVM>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetCountrySearch(pageIndex, pageSize, searchText)));
    }

    [HttpGet("id")]
    public async Task<ActionResult<CountryVM>> GetDetailsAsync(int id)
    {
        return await Mediator.Send(new GetCountryDetails(id));
    }

    [HttpPost]
    public async Task<ActionResult<CountryVM>> InsertAsync([FromQuery] CountryVM model)
    {
        return await Mediator.Send(new CreateCountry(model));
    }

    [HttpPut("id")]
    public async Task<ActionResult<CountryVM>> UpdateAsync(int id, CountryVM model)
    {
        return await Mediator.Send(new UpdateCountry(id, model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<CountryVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteCountry(id));
    }
}
