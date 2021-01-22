using Ardalis.ApiEndpoints;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevTraining.Api.Endpoints.Contacts
{
    public class DeleteResult
    {
        public Guid DeletedContactId { get; set; }
    }
    public class Delete : BaseAsyncEndpoint<Guid, DeleteResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Delete(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete("api/Contacts/{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Contact",
            Description = "Deletes a Contact",
            OperationId = "Contact.Delete",
            Tags = new[] { "ContactEndpoint" })
        ]
        public override async Task<ActionResult<DeleteResult>> HandleAsync(Guid id , CancellationToken cancellationToken)
        {
            var contact = _unitOfWork.Contacts.GetByID(id);

            if (contact == null)
            {
                return NotFound(id);
            }

            _unitOfWork.Contacts.Delete(contact);
            _unitOfWork.Commit();
            _unitOfWork.Dispose();


            return Ok(new DeleteResult { DeletedContactId = id });

        }
    }

    
}