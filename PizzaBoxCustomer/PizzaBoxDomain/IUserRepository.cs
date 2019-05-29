using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBoxDomain
{
    public interface IUserRepository
    {
        void DisposeInstance();

        bool PassValidation(string uname, string pwrd);

        bool UserNameTaken(string username);

        void AddUser(DomUser u);
        //works
        void UpdateUser(DomUser u);
        //works
        void RemoveUser(DomUser u);
        //works
        DomUser GetUser(string username);
    }
}
