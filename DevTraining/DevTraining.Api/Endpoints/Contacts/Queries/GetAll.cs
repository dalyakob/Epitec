using Ardalis.ApiEndpoints;
using AutoMapper;
using DevTraining.Infrastructure.Data;
using DevTraining.Shared.RepositoryPattern;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevTraining.Api.Endpoints.Contacts.Queries
{
    public class GetAllResult 
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? InActivatedDate { get; set; }
    }
    public class GetAll : BaseAsyncEndpoint
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("api/Contacts")]
        public async Task<ActionResult> HandleAsync(CancellationToken cancellationToken)
        {
            var result = _unitOfWork.Contacts.Get().Select(i => _mapper.Map<GetAllResult>(i));

            _unitOfWork.Dispose();

            return Ok(result);
        }
    }
    
}
