using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using DevTraining.Shared;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;

namespace DevTraining.Api.Endpoints.Contacts.Queries
{
    public class GetResult
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }
    }
    public class Get : BaseAsyncEndpoint<Guid, GetResult>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("api/Contacts/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific Contact",
            Description = "Get a specific Contact",
            OperationId = "Contact.Get",
            Tags = new[] { "ContactEndpoint" })
        ]
        public override async Task<ActionResult<GetResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var contact = _unitOfWork.Contacts.GetByID(id);
            var result = _mapper.Map<GetResult>(contact);
            return Ok(result);
        }
    }
    
}
