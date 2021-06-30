using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Services
{

    public class PersonService : IPersonService
    {
        private List<Person> listMember =  new List<Person>();
        public PersonService()
        {
            listMember = new List<Person>
            {
                new Person { FirstName = "Ngo", LastName = "Huy", Gender = true, DateOfBirth = new DateTime(1998, 06, 21), BirthPlace = "Ha Noi"},
                new Person { FirstName = "Tran", LastName = "Thuy", Gender = false, DateOfBirth = new DateTime(2001, 04, 11), BirthPlace = "Ha Noi"},
                new Person { FirstName = "Nguyen", LastName = "Phong", Gender = true, DateOfBirth = new DateTime(2001, 03, 11), BirthPlace = "Ha Tinh"},
                new Person { FirstName = "Le", LastName = "Ha", Gender = false, DateOfBirth = new DateTime(2000, 03, 11), BirthPlace = "Ha Nam"},
                new Person { FirstName = "Dao", LastName = "Tuan", Gender = true, DateOfBirth = new DateTime(1999, 03, 11), BirthPlace = "Ha Noi"},
            };
            
        }

        public IEnumerable<Person> GetPersons()
        {
            return listMember;
        }

        public List<Person> Create(Person member)
        {
            listMember.Add(member);
            return listMember;
        }
        public List<Person> Edit(Person member, string firstname, string lastname, DateTime date, string place)
        {
            var person = listMember.Find(x => x.FirstName == firstname);
            person.LastName = lastname;
            person.DateOfBirth = (DateTime)date;
            if(person.Gender == true){
                person.Gender = false;
            }else{
                person.Gender = true;
            }
            person.BirthPlace = place;

            return listMember;
        }
        public List<Person> Delete(string name)
        {
            listMember.RemoveAll(p => p.FirstName == name || p.LastName == name);
            return listMember;
        }
        public List<Person> Name(string name)
        {
            var filterName = listMember.Where(p => p.FirstName.ToLower().Contains(name) || p.LastName.ToLower().Contains(name) ).ToList();
            return filterName;
        }

        public List<Person> Gender(bool gender)
        {
            var filterName = listMember.Where(p => p.Gender == gender).ToList();
            return filterName;
        }

        public List<Person> Place(string place)
        {
            var filterPLace = listMember.Where(p => p.BirthPlace.ToLower().Contains(place) ).ToList();
            return filterPLace;
        }

        public List<Person> Filter(string name,bool gender,string place)
        {
            var filterPLace = listMember.Where(p =>p.FirstName.ToLower().Contains(name) || p.Gender == gender || p.BirthPlace.ToLower().Contains(place) ).ToList();
            return filterPLace;
        }


    }

}