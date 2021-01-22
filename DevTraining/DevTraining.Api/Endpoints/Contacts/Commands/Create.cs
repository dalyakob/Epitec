using Ardalis.ApiEndpoints;
using AutoMapper;
using DevTraining.Core.Models;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevTraining.Api.Endpoints.Contacts
{
    public class CreateResult : CreateCommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    public class CreateCommand
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }
    }
    public class Create : BaseAsyncEndpoint<CreateCommand, CreateResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        //private UnitOfWork _unitOfWork = new UnitOfWork(new DevTrainingContext());

        public Create(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("api/Contacts")]
        [SwaggerOperation(
            Summary = "Creates a new Contact",
            Description = "Creates a new Contact",
            OperationId = "Contact.Create",
            Tags = new[] { "ContactEndpoint" })
        ]
        public override async Task<ActionResult<CreateResult>> HandleAsync([FromBody]CreateCommand command, CancellationToken cancellationToken)
        {   
            var contact = new Contact();
            var result = new CreateResult();
            _mapper.Map(command, result);
            _mapper.Map(result, contact);

            _unitOfWork.Contacts.Create(contact);
            _unitOfWork.Commit();

            return Ok(result);
        }
        
    }
}
