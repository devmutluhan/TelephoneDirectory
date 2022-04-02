using Model;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IContactRepos
    {
        public List<Contact> Get();
        public Contact Get(int id);
        public void Add(Contact contact);
        public void Delete(int id);
        public void Update(Contact contact, int id);
    }
}
