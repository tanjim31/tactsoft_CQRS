using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Application.Common;
using Tactsoft.Application.Features.StudentOperation.Command;
using Tactsoft.Application.Features.StudentOperation.Query;
using Tactsoft.Application.Models.Entities;

namespace Tactsoft.App.Controllers;

[AllowAnonymous]
public class StudentController : BaseController
{
    [HttpGet("id")]
    public async Task<ActionResult<StudentVM>> GetDetailsAsync(int id)
    {
        return await Mediator.Send(new GetStudentDetails(id));
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentVM>>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        return Ok(await Mediator.Send(new GetStudentSearch(pageIndex, pageSize, searchText)));
    }

    [HttpPost]
    public async Task<ActionResult<StudentVM>> InsertAsync(StudentVM model)
    {
        return await Mediator.Send(new CreateStudent(model));
    }

    [HttpPut("id")]
    public async Task<ActionResult<StudentVM>> UpdateAsync(int id, StudentVM model)
    {
        return await Mediator.Send(new UpdateStudent(id, model));
    }

    [HttpDelete("id")]
    public async Task<ActionResult<StudentVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteStudent(id));
    }
}
