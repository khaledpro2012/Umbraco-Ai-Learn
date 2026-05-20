using CustomerNotes.Package.Models;
using CustomerNotes.Package.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerNotes.Package.Pages;

public class CustomerNotesModel : PageModel
{
    private readonly ICustomerNoteService _customerNoteService;

    public CustomerNotesModel(ICustomerNoteService customerNoteService)
    {
        _customerNoteService = customerNoteService;
    }

    [BindProperty]
    public string CustomerId { get; set; } = string.Empty;

    [BindProperty]
    public string NewNote { get; set; } = string.Empty;

    public IReadOnlyList<CustomerNote> Notes { get; private set; } = [];

    public void OnGet()
    {
    }

    public IActionResult OnPostLoad()
    {
        LoadNotes();
        return Page();
    }

    public IActionResult OnPostCreate()
    {
        if (!string.IsNullOrWhiteSpace(CustomerId) && !string.IsNullOrWhiteSpace(NewNote))
        {
            _customerNoteService.AddNote(CustomerId, NewNote);
            NewNote = string.Empty;
        }

        LoadNotes();
        return Page();
    }

    public IActionResult OnPostUpdate(string customerId, Guid noteId, string note)
    {
        if (!string.IsNullOrWhiteSpace(customerId) && !string.IsNullOrWhiteSpace(note))
        {
            _customerNoteService.UpdateNote(customerId, noteId, note);
            CustomerId = customerId;
        }

        LoadNotes();
        return Page();
    }

    public IActionResult OnPostDelete(string customerId, Guid noteId)
    {
        if (!string.IsNullOrWhiteSpace(customerId))
        {
            _customerNoteService.DeleteNote(customerId, noteId);
            CustomerId = customerId;
        }

        LoadNotes();
        return Page();
    }

    private void LoadNotes()
    {
        Notes = string.IsNullOrWhiteSpace(CustomerId)
            ? []
            : _customerNoteService.GetNotes(CustomerId);
    }
}
