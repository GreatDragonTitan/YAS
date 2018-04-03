using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YAS.Models.Interfaces;
using YAS.Models.Records;

namespace YAS.Controllers
{
    [Route("posts")]
    public class PostController : Controller
    {
        private IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ViewResult List() => View(_repository.Posts);

        [HttpGet("{id}")]
        public ViewResult Get(int id)
        {
            foreach(var p in _repository.Posts)
            {
                if(p.Id == id)
                {
                    return View(p);
                }
            }
            return null;
        }

        [HttpPost]
        public async Task<ViewResult> Post(PostRecord post)
        {
            await _repository.Post(post);
            return View("List", _repository.Posts);
        }

        [HttpGet("add")]
        public ViewResult Add() => View();

        [HttpPost("edit")]
        public async Task<ActionResult> Put(PostRecord post)
        {
            await _repository.Put(post);
            return RedirectToAction("List");
        }

        [HttpGet("edit/{id}")]
        public ViewResult Edit(int id)
        {
            foreach (var p in _repository.Posts)
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
            return RedirectToAction("List");
        }
    }
}