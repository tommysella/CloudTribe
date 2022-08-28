using CloudTribe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTribe.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TribeMembersController : ControllerBase
    {
        private readonly ILogger<TribeMembersController> _logger;

        public TribeMembersController(ILogger<TribeMembersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTribeMembers")]
        public IEnumerable<TribeMember> Get()
        {
            List<TribeMember> tribeMembers = new List<TribeMember>
            {
                new TribeMember { Id = 1, Name = "Tommy Selggren", Certifications = "AZ-204" },
                new TribeMember { Id = 2, Name = "John Doe", Certifications = "AZ-104" },
                new TribeMember { Id = 3, Name = "Frank Andersson", Certifications = "AZ-900" },
                new TribeMember { Id = 4, Name = "Kalle Kallesson", Certifications = "AZ-104, AZ-204" },
                new TribeMember { Id = 5, Name = "Nils Nilsson", Certifications = "AZ-204" }
            };

            return tribeMembers;
        }
    }
}
