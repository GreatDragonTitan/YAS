using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YAS.Models.Interfaces;
using YAS.Models.Records;

namespace YAS.Controllers
{
    [Route("autoservices")]
    public class AutoServiceController : Controller
    {
        private IAutoServiceRepository _repository;

        public AutoServiceController(IAutoServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ViewResult GetAll() => View(_repository.GetAll());

        [HttpGet("{id}")]
        public ViewResult Get(int id)
        {
            foreach (var p in _repository.GetAll())
            {
                if (p.Id == id)
                {
                    return View(p);
                }
            }
            return null;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add(AutoServiceRecord autoService)
        {
            await _repository.Add(autoService);
            return RedirectToAction("GetAll");
        }

        [HttpGet("add")]
        public ViewResult Add() => View();

        [HttpPost("edit/{id}")]
        public async Task<ActionResult> Edit(AutoServiceRecord autoService)
        {
            await _repository.Edit(autoService);
            return RedirectToAction("GetAll");
        }

        [HttpGet("edit/{id}")]
        public ViewResult Edit(int id)
        {
            foreach (var p in _repository.GetAll())
            {
                if (p.Id == id)
                {
                    return View(p);
                }
            }
            return View(null);
        }

        [HttpGet("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}