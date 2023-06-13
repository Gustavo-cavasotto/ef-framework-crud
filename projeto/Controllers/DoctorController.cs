using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto.Domain;
using projeto.Data.Repositories;
using projeto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository repositiory;

        public DoctorController()
        {
            this.repositiory = new DoctorRepository();
        }

        [HttpGet]
        public IEnumerable<Doctor>Get()
        {
            return repositiory.GetAll();
        }
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            return repositiory.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Doctor item)
        {
            repositiory.Save(item);
            return Ok( new {
                statusCode=200,
                message = "Cadastrado com sucesso",
                item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repositiory.Delete(id);
            return Ok( new {
                statusCode=200,
                message = "Pessoa excluída com sucesso"
            });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Doctor item)
        {
            repositiory.Update(item);
            return Ok( new {
                statusCode=200,
                message = item.name + " atualizado com sucesso",
                item
            });
        }
    }
}