using datalayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.Interface
{
    public interface IPersonsService
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<IEnumerable<Person>> GetPersonById(int id);
        Task<IEnumerable<Person>> GetPersonByName(string name);
        IActionResult PostPerson(Person person);
        IActionResult PutPerson(Person person);
        IActionResult DeletePerson(int id);

    }
}
