using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace datalayer.Repository
{
    public class PersonRepository
    {
        private ApplicationDataContext _context;

        public  PersonRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.Where(p => p.Id > 0).ToArrayAsync();
        }
        public async Task<IEnumerable<Person>> GetPersonById(int id)
        {
            return await _context.Persons.Where(p => p.Id == id).ToArrayAsync();
        }
        public async Task<IEnumerable<Person>> GetPersonByName(string name)
        {
            return await _context.Persons.Where(p => p.FirstName.Contains(name)).ToArrayAsync();
        }
        public async Task<int>  PostPerson(Person person)
        {
            Person UpdPerson =  _context.Persons.Where(p => p.Id == person.Id).FirstOrDefault();
            UpdPerson = person;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> PutPerson(Person person)
        {
            _context.Persons.Remove(person);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeletePerson(int id)
        {
            Person DeletePerson = _context.Persons.Where(p => p.Id == id).FirstOrDefault();
            _context.Persons.Remove(DeletePerson);
            return await _context.SaveChangesAsync();
        }




    }
}
