using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using suteservice.domain.AggregatesModel.UserAgregate;

namespace suteservice.api.Controllers {
    
    [Produces("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {

        private readonly IUserRepository _repository;
        private readonly ILogger _logger;

        public UsersController (
            IUserRepository repository,
            ILogger<UsersController> logger
        ) {
            _repository = repository;
            _logger = logger;
        }

        // GET api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get () {
            
            _logger.LogInformation(1 /* ,LoggingEvents.GetItem*/, "Getting all users.");
            /* 
            IEnumerable<User> result;
            _repository.GetAsync().ContinueWith(task => result = task.Result);

            ActionResult<IEnumerable<User>> response = new ActionResult<IEnumerable<User>>(result);
            return response;  */

            return new User[] { 
                new User{ Name = "Faye", FamilyName = "Teasedale" },
                new User{ Name = "Jean-François", FamilyName = "Desrochers" },
            };
        }

        // GET api/Users/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/Users
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/Users/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/Users/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}