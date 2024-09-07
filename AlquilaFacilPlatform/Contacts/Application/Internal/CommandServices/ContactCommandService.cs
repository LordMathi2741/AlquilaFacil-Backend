using AlquilaFacilPlatform.Contacts.Application.Internal.OutboundServices;
using AlquilaFacilPlatform.Contacts.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Contacts.Domain.Model.Commands;
using AlquilaFacilPlatform.Contacts.Domain.Repositories;
using AlquilaFacilPlatform.Contacts.Domain.Services;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Domain.Repositories;

namespace AlquilaFacilPlatform.Contacts.Application.Internal.CommandServices;

public class ContactCommandService (IContactRepository contactRepository, IUnitOfWork unitOfWork,IExternalUserService externalUserService) : IContactCommandService
{
    public async Task<Contact?> Handle(CreateContactCommand command)
    {
        if (!externalUserService.UserExists(command.UserId))
        {
            throw new Exception("This user doesnt exists " + command.UserId);
        }
        var contact = new Contact(command.Name, command.Lastname, command.Message, command.Email, command.Phone, command.UserId);
        await contactRepository.AddAsync(contact);
        await unitOfWork.CompleteAsync();
        return contact;
    }
    
}