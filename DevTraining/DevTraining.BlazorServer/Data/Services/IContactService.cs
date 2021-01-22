using DevTraining.BlazorServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Data.Services
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