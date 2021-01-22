using AutoMapper;
using DevTraining.Api.Endpoints.Contacts;
using DevTraining.Api.Endpoints.Contacts.Queries;
using DevTraining.Api.Endpoints.Contacts.Commands;
using DevTraining.Core.Models;

namespace DevTraining.Api
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateCommand, CreateResult>();
            CreateMap<CreateResult, Contact>();
            CreateMap<EditCommand, Contact>();

            CreateMap<Contact, CreateResult>();
            CreateMap<Contact, EditResult>();
            CreateMap<Contact, GetAllResult>();
            CreateMap<Contact, GetResult>();
            CreateMap<Contact, InActivateResult>();
        }
    }
}
