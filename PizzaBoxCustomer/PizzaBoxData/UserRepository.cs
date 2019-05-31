using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBoxDomain;

namespace PizzaBoxData
{
    public class UserRepository : IUserRepository
    {
        private PizzaBoxContext _db;
        public UserRepository(PizzaBoxContext db)
        {
            _db = db;
        }
        ~UserRepository()
        {
            _db.Dispose();
        }

        public void DisposeInstance()
        {
        }

        public bool PassValidation(string uname, string pwrd)
        {
            return (_db.User.Where<User>(u => u.Username == uname).FirstOrDefault().Pwrd == pwrd);
        }

        public bool UserNameTaken(string username)
        {
            var userExists = _db.User.Where<User>(u => u.Username == username).FirstOrDefault();
            if (userExists != null)
                return true;
            else
                return false;
        }

        public void AddUser(DomUser u)
        {
            _db.User.Add(DataDomainMapper.DomUser2User(u));
            _db.SaveChanges();
        }

        public void UpdateUser(DomUser u)
        {
            _db.User.Update(DataDomainMapper.DomUser2User(u));
            _db.SaveChanges();
        }

        public void RemoveUser(DomUser u)
        {
            _db.User.Remove(DataDomainMapper.DomUser2User(u));
        }

        public DomUser GetUser(string username)
        {
            User inUser = _db.User.Where(u => u.Username == username).FirstOrDefault();
            DomUser outUser = DataDomainMapper.User2DomUser(inUser);
            _db.Entry(inUser).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return outUser;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
