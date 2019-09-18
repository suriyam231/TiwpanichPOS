using Dashboard.DTOs;
using Dashboard.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Service
{
    public class PersonService : IPerson
    {
        public List<PersonDTO> GetPerson()
        {
            List<PersonDTO> Person = new List<PersonDTO>();
            PersonDTO Person1 = new PersonDTO()
            {
                task = "Presentation",
                status = "Inprogress",
                quater = 1,
                names = 1
            };
            Person.Add(Person1);
            PersonDTO Person2 = new PersonDTO()
            {
                task = "design",
                status = "Inprogress",
                quater = 1,
                names = 2
            };
            Person.Add(Person2);
            PersonDTO Person3 = new PersonDTO()
            {
                task = "design",
                status = "Success",
                quater = 1,
                names = 3
            };
            Person.Add(Person3);
            PersonDTO Person4 = new PersonDTO()
            {
                task = "design",
                status = "Waiting",
                quater = 1,
                names = 4
            };
            Person.Add(Person4);
            PersonDTO Person5 = new PersonDTO()
            {
                task = "design",
                status = "Cancel",
                quater = 2,
                names = 1
            };
            Person.Add(Person5);
            PersonDTO Person6 = new PersonDTO()
            {
                task = "design",
                status = "Inprogress",
                quater = 2,
                names = 2
            };
            Person.Add(Person6);
            PersonDTO Person7 = new PersonDTO()
            {
                task = "design",
                status = "Success",
                quater = 2,
                names = 3
            };
            Person.Add(Person7);
            PersonDTO Person8 = new PersonDTO()
            {
                task = "design",
                status = "Waiting",
                quater = 2,
                names = 4
            };
            Person.Add(Person8);
            PersonDTO Person9 = new PersonDTO()
            {
                task = "design",
                status = "Inprogress",
                quater = 3,
                names = 1
            };
            Person.Add(Person9);
            PersonDTO Person10 = new PersonDTO()
            {
                task = "design",
                status = "Cancel",
                quater = 3,
                names = 2
            };
            Person.Add(Person10);
            PersonDTO Person11 = new PersonDTO()
            {
                task = "design",
                status = "Waiting",
                quater = 3,
                names = 3
            };
            Person.Add(Person11);
            PersonDTO Person12 = new PersonDTO()
            {
                task = "design",
                status = "Success",
                quater = 3,
                names = 4
            };
            Person.Add(Person12);
            PersonDTO Person13 = new PersonDTO()
            {
                task = "design",
                status = "Waiting",
                quater = 4,
                names = 1
            };
            Person.Add(Person13);
            PersonDTO Person14 = new PersonDTO()
            {
                task = "design",
                status = "Cancel",
                quater = 4,
                names = 2
            };
            Person.Add(Person14);
            PersonDTO Person15 = new PersonDTO()
            {
                task = "design",
                status = "Inprogress",
                quater = 4,
                names = 3
            };
            Person.Add(Person15);
            PersonDTO Person16 = new PersonDTO()
            {
                task = "design",
                status = "Success",
                quater = 4,
                names = 4
            };
            Person.Add(Person16);

            return Person;
        }
    }
}
