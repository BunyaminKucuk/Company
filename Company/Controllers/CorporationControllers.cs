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
    [Route("api/corporation")]
    public class CorporationControllers : ControllerBase
    {
        private readonly ICorporationService _corporationService;

        public CorporationControllers()
        {
            _corporationService = new CorporationManager();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetCorporations()
        {
            var corporations = _corporationService.GetAllCorporations();
            return Ok(corporations);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetCorporationById(int id)
        {
            var corporations = _corporationService.GetCorporationById(id);
            if (corporations != null)
            {
                return Ok(corporations);
            }
            return NotFound();//404
        }

        [HttpPost]
        [Route("add")]

        public IActionResult CreateCorporation([FromBody] Corporation corporation)
        {
            var createdCorporation = _corporationService.CreateCorporation(corporation);
            return CreatedAtAction("Get", new { id = createdCorporation.CompanyId }, createdCorporation);//201+data
        }

        [HttpPut]
        [Route("update")]

        public IActionResult UpdateCorporation([FromBody] Corporation corporation)
        {
            if (_corporationService.GetCorporationById(corporation.CompanyId) != null)
            {
                return Ok(_corporationService.UpdateCorporation(corporation));//201+data
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCorporation(int id)
        {
            _corporationService.DeleteCorporation(id);
        }
    }
}
