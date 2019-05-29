using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class UserRepository : IUserRepository
    {

        public void DisposeInstance()
        {
            DBSingle.Instance.ResetInstance();
        }

        public bool PassValidation(string uname, string pwrd)
        {
            return (DBSingle.Instance.dbInstance.User.Where<User>(u => u.Username == uname).FirstOrDefault().Pwrd == pwrd);
        }

        public bool UserNameTaken(string username)
        {
            var userExists = DBSingle.Instance.dbInstance.User.Where<User>(u => u.Username == username).FirstOrDefault();
            if (userExists != null)
                return true;
            else
                return false;
        }

        public void AddUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Add(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void UpdateUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Update(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public void RemoveUser(DomUser u)
        {
            DBSingle.Instance.dbInstance.User.Remove(DataDomainMapper.DomUser2User(u));
            DBSingle.Instance.dbInstance.SaveChanges();
        }

        public DomUser GetUser(string username)
        {
            return DataDomainMapper.User2DomUser(DBSingle.Instance.dbInstance.User.Where(u => u.Username == username).FirstOrDefault());
        }
    }
}
