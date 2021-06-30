using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Models
{

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public bool? Gender { get; set; }

        public string BirthPlace { get; set; }

    }

}