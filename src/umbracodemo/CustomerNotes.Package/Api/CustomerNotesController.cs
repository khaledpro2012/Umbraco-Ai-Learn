using CustomerNotes.Package.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerNotes.Package.Api;

[ApiController]
[Route("umbraco/api/customernotes")]
public class CustomerNotesController : ControllerBase
{
    private readonly ICustomerNoteService _customerNoteService;

    public CustomerNotesController(ICustomerNoteService customerNoteService)
    {
        _customerNoteService = customerNoteService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string customerId)
    {
        return Ok(_customerNoteService.GetNotes(customerId));
    }

    [HttpPost]
    public IActionResult Add([FromBody] AddCustomerNoteRequest request)
    {
        return Ok(_customerNoteService.AddNote(request.CustomerId, request.Note));
    }

    [HttpPut("{noteId:guid}")]
    public IActionResult Update(Guid noteId, [FromBody] UpdateCustomerNoteRequest request)
    {
        bool updated = _customerNoteService.UpdateNote(request.CustomerId, noteId, request.Note);
        return updated ? Ok() : NotFound();
    }

    [HttpDelete("{noteId:guid}")]
    public IActionResult Delete(Guid noteId, [FromQuery] string customerId)
    {
        bool deleted = _customerNoteService.DeleteNote(customerId, noteId);
        return deleted ? Ok() : NotFound();
    }

    public class AddCustomerNoteRequest
    {
        public required string CustomerId { get; init; }
        public required string Note { get; init; }
    }

    public class UpdateCustomerNoteRequest
    {
        public required string CustomerId { get; init; }
        public required string Note { get; init; }
    }
}
