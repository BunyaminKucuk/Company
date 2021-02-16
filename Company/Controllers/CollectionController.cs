using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Business.Abstract;
using Company.Business.Concrete;
using Company.Entities;

namespace Company.API.Controllers
{
    [Route("api/collection")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;

        public CollectionController()
        {
            _collectionService = new CollectionManager();
        }
            [HttpGet]
        [Route("list")]
        public IActionResult GetCollections()
        {
            var collection = _collectionService.GetAllCollections();
            return Ok(collection);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetCollectionById(int id)
        {
            var collection = _collectionService.GetCollectionById(id);
            if (collection != null)
            {
                return Ok(collection);
            }
            return NotFound();//404
        }      
        [HttpGet]
        [Route("getByProjectId/{id}")]
        public IActionResult GetCollectionByProject(int id)
        {
            var collection = _collectionService.GetCollectionByProject(id);
            if (collection != null)
            {
                return Ok(collection);
            }
            return NotFound();//404
        }

        [HttpPost]
        [Route("add")]

        public IActionResult CreateCollection([FromBody] Collection collection)
        {
            var createdCollection = _collectionService.CreateCollection(collection);
            return CreatedAtAction("Get", new { id = createdCollection.CollectionId }, createdCollection);//201+data
        }

        [HttpPut]
        [Route("update")]

        public IActionResult UpdateCollection([FromBody] Collection collection)
        {
            if (_collectionService.GetCollectionById(collection.CollectionId) != null)
            {
                return Ok(_collectionService.UpdateCollection(collection));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCollection(int id)
        {
            _collectionService.DeleteCollection(id);
        }
    }
}
