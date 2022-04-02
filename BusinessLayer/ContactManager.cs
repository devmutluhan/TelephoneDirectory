using DataAccessLayer;
using Model;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ContactManager
    {
        private readonly IContactRepos _contactRepos;

        public ContactManager(IContactRepos contactRepos)
        {
            this._contactRepos = contactRepos;  
        }

        public List<Contact> Get()
        {
            return _contactRepos.Get();
        }
        public Contact Get(int id)
        {
            return _contactRepos.Get(id);
        }

        public void Add(Contact contact)
        {
            _contactRepos.Add(contact);
        }
        public void Delete(int id)
        {
            _contactRepos.Delete(id);
        }
        public void Update(Contact contact, int id)
        {
            _contactRepos.Update(contact, id);
        }
    }
}
