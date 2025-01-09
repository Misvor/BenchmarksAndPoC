using Microsoft.AspNetCore.Mvc;
using ParallelThread.Models;

namespace ParallelThread.Controllers
{
    public class DapperController : ControllerBase
    {
        private IDapperRepository repository;

        public DapperController(IDapperRepository repo)
        {
            repository = repo;
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            DapperStoreClass? data = repository.Get(id);
            if (data != null)
            {
                repository.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("Add")]
        public ActionResult<int> Add(DapperStoreClass data)
        {
            return repository.Create(data);
        }

        [HttpGet("All")]
        public ActionResult<List<DapperStoreClass>> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPatch("Update")]
        public ActionResult Update(DapperStoreClass data)
        {
            repository.Update(data);
            return Ok();
        }

        [HttpGet("Info")]
        public ActionResult<DapperStoreClass> Get(int id)
        {
            var result  = repository.Get(id);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

    }
}
