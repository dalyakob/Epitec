using DevTraining.BlazorServer.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Contacts.Services
{
    public interface IContactService
    {
        Task<List<ContactResponseDTO>> GetAll();
        Task<ContactResponseDTO> Get(Guid id);
        Task<ContactResponseDTO> Create(ContactResponseDTO contact);
        Task<ContactResponseDTO> Edit(ContactResponseDTO contact);
        Task Delete(Guid id);
        
    }
}