using System.Collections.Concurrent;
using CustomerNotes.Package.Models;

namespace CustomerNotes.Package.Services;

public class InMemoryCustomerNoteService : ICustomerNoteService
{
    private readonly ConcurrentDictionary<string, List<CustomerNote>> _notesByCustomer = new(StringComparer.OrdinalIgnoreCase);

    public CustomerNote AddNote(string customerId, string note)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customerId);
        ArgumentException.ThrowIfNullOrWhiteSpace(note);

        List<CustomerNote> notes = _notesByCustomer.GetOrAdd(customerId, _ => []);

        CustomerNote customerNote = new()
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Note = note,
            CreatedAtUtc = DateTime.UtcNow
        };

        lock (notes)
        {
            notes.Add(customerNote);
        }

        return customerNote;
    }

    public IReadOnlyList<CustomerNote> GetNotes(string customerId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customerId);

        if (!_notesByCustomer.TryGetValue(customerId, out List<CustomerNote>? notes))
        {
            return [];
        }

        lock (notes)
        {
            return notes.OrderByDescending(n => n.CreatedAtUtc).ToList();
        }
    }

    public bool UpdateNote(string customerId, Guid noteId, string note)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customerId);
        ArgumentException.ThrowIfNullOrWhiteSpace(note);

        if (!_notesByCustomer.TryGetValue(customerId, out List<CustomerNote>? notes))
        {
            return false;
        }

        lock (notes)
        {
            CustomerNote? existing = notes.FirstOrDefault(n => n.Id == noteId);
            if (existing is null)
            {
                return false;
            }

            existing.Note = note;
            return true;
        }
    }

    public bool DeleteNote(string customerId, Guid noteId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customerId);

        if (!_notesByCustomer.TryGetValue(customerId, out List<CustomerNote>? notes))
        {
            return false;
        }

        lock (notes)
        {
            CustomerNote? existing = notes.FirstOrDefault(n => n.Id == noteId);
            if (existing is null)
            {
                return false;
            }

            notes.Remove(existing);
            return true;
        }
    }
}
