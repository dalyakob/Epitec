using Ardalis.ApiEndpoints;
using AutoMapper;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevTraining.Api.Endpoints.Contacts
{
    public class EditResult 
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }
    }
    public class EditCommand
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }

    }
    public class Edit : BaseAsyncEndpoint<EditCommand, EditResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Edit(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPut("api/Contacts")]
        [SwaggerOperation(
            Summary = "Updates an existing Contact",
            Description = "Updates an existing Contact",
            OperationId = "Contact.Update",
            Tags = new[] { "ContactEndpoint" })
        ]
        public override async Task<ActionResult<EditResult>> HandleAsync(EditCommand command, CancellationToken cancellationToken)
        {
            var contact = _unitOfWork.Contacts.GetByID(command.Id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(command, contact);
            }

            _unitOfWork.Contacts.Update(contact);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();

            var result = _mapper.Map<EditResult>(contact);
            return Ok(result);
        }
    }
}
