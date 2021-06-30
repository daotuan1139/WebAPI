using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Services
{

    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        List<Person> Create(Person member);
        List<Person> Edit(Person member, string firstname, string lastname, DateTime date, string place);
        List<Person> Delete(string name);
        List<Person> Name(string name);
        List<Person> Gender(bool gender);
        List<Person> Place(string place);
        List<Person> Filter(string name,bool gender,string place);

    }

}