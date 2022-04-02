using Dapper;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ContactRepos : BaseRepos, IContactRepos
    {
        public ContactRepos(Settings settings): base(settings.ConnectionString)
        {

        }

        public void Add(Contact contact)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"Insert Into Contact (FullName,MobileNumber, CompanyNumber, HomeNumber, Address, Email)
                    Values (@FullName, @MobileNumber, @CompanyNumber, @HomeNumber, @Address, @Email)", contact);
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute($"Delete From Contact Where ContactId= {id}");
            }
        }

        public List<Contact> Get()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Contact>("Select*From Contact Order By FullName").ToList();
            }
        }

        public Contact Get(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Contact>($"Select*From Contact Where ContactId={id}").FirstOrDefault();
            }
        }

        public void Update(Contact contact, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@$"Update Contact Set FullName=@FullName, MobileNumber=@MobileNumber,
                        CompanyNumber=@CompanyNumber, HomeNumber=@HomeNumber, Address=@Address, Email=@Email Where ContactId={id}", contact);
            }
        }
    }
}
