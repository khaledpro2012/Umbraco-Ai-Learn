using CustomerNotes.Package.Models;

namespace CustomerNotes.Package.Services;

public interface ICustomerNoteService
{
    CustomerNote AddNote(string customerId, string note);
    IReadOnlyList<CustomerNote> GetNotes(string customerId);
    bool UpdateNote(string customerId, Guid noteId, string note);
    bool DeleteNote(string customerId, Guid noteId);
}
