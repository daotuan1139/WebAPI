using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet("Persons")]
        public IEnumerable<Person> GetList()
        {
            return _personService.GetPersons();
        }

        [HttpPost("Person")]
        public IActionResult Create(Person person)
        {
            var add = _personService.Create(person);
            if (!add.Any())
            {
                return NotFound();
            }
            return Ok(add);
        }

        [HttpPut("Person/{name}")]
        public IActionResult Update(Person person, string name, string lastname, DateTime date, string place)
        {
            var edit = _personService.Edit(person, name, lastname, date, place);
            if (!edit.Any())
            {
                return NotFound();
            }
            return Ok(edit);
        }

        [HttpDelete("Person/{name}")]
        public IActionResult Delete(string name)
        {
            var del = _personService.Delete(name);
            if (!del.Any())
            {
                return NotFound();
            }
            return Ok(del);
        
        }

        [HttpGet("Filter/Name={name}")]
        public IActionResult FilterName(string name)
        {
            var filterName = _personService.Name(name);
            if (!filterName.Any())
            {
                return NotFound();
            }
            return Ok(filterName);
        }

        [HttpGet("Filter/Gender={gender}")]
        public IActionResult FilterGender(bool gender)
        {
            var filterGender = _personService.Gender(gender);
            if (!filterGender.Any())
            {
                return NotFound();
            }
            return Ok(filterGender);
        }

        [HttpGet("Filter/Place={place}")]
        public IActionResult FilterPlace(string place)
        {
            var filterPlace = _personService.Place(place);
            if (!filterPlace.Any())
            {
                return NotFound();
            }
            return Ok(filterPlace);
        }

        [HttpGet("Filter/Place={place}/Gender={gender}/Name={name}")]
        public IActionResult Filter(string name, bool gender, string place)
        { 
            var filter = _personService.Filter(name, gender, place);
            if (!filter.Any())
            {
                return NotFound();
            }
            return Ok(filter);
        }
    }
}