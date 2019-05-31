using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface IUserRepository
    {
        void DisposeInstance();
        void Save();

        bool PassValidation(string uname, string pwrd);

        bool UserNameTaken(string username);

        void AddUser(DomUser u);
        void UpdateUser(DomUser u);
        void RemoveUser(DomUser u);
        DomUser GetUser(string username);
    }
}
