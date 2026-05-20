using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using CustomerNotes.Package.Services;

namespace CustomerNotes.Package.Composers;

public class CustomerNotesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<ICustomerNoteService, InMemoryCustomerNoteService>();
    }
}
