using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codeFirstApproach.Data;
using codeFirstApproach.model;
using NuGet.Protocol;
using codeFirstApproach.IRepository;

namespace codeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerRepo manager;

        public ManagersController(IManagerRepo _manager)
        {
            manager = _manager;
        }

        // GET: api/Managers
        [HttpGet]
        public ActionResult<IEnumerable<Manager>> GetManagers()
        {
            

            return Ok(manager.GetManagers());

        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            return Ok(manager.GetManager(id));
        }

        // PUT: api/Managers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutManager(int id, Manager manager)
        {
            return Ok(this.manager.UpdateManager(manager));
        }

        [HttpPut("{id}/employee")]
        public IActionResult AddEmployeeToManager(int id, int employeeid)
        {
            return Ok(this.manager.AddNewEmployeeToManager(employeeid, id));
        }

        // POST: api/Managers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  ActionResult<Manager>  PostManager(Manager manager)
        {
            return Ok(this.manager.AddNewManager(manager));
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteManager(int id)
        {
            return Ok(this.manager.RemoveManager(id));
        }

        
    }
}
