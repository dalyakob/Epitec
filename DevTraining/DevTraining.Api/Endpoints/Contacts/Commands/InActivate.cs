using Ardalis.ApiEndpoints;
using AutoMapper;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevTraining.Api.Endpoints.Contacts.Commands
{

    public class InActivateResult
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }
    }

    public class InActivate : BaseAsyncEndpoint<Guid, InActivateResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InActivate(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPut("api/Contacts/{id}")]
        [SwaggerOperation(
            Summary = "Deactivates an active contact",
            Description = "Deactivates an active contact",
            OperationId = "Contact.InActive",
            Tags = new[] { "ContactEndpoint" })
        ]
        public override async Task<ActionResult<InActivateResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        { 
            var contact = _unitOfWork.Contacts.GetByID(id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.InActivate();

            _unitOfWork.Contacts.Update(contact);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();

            var result = _mapper.Map<InActivateResult>(contact);
            return Ok(result);
        }
        
    }
}
