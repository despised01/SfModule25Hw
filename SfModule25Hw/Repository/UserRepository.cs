using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfModule25Hw.Models;
using SfModule25Hw.AppContext;
using SfModule25Hw.Repository;

namespace SfModule25Hw.Repository
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        private AppContext.AppContext DB;

        public UserRepository(AppContext.AppContext appContext)
        {
            DB = appContext;
        }

        public void CreateNewRecord(User record)
        {
            DB.Users.Add(record);
            DB.SaveChanges();
        }

        public void DeleteById(int id)
        {

            DB.Users.Remove(DB.Users.FirstOrDefault(u => u.Id == id));
            DB.SaveChanges();
        }

        public List<User> GetAll()
        {
            return DB.Users.ToList();
        }

        public User GetById(int id)
        {
            return DB.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateNameById(int id, string name)
        {
            var user = GetById(id);
            user.Name = name;
            DB.SaveChanges();
        }
    }

    public interface IUserRepository
    {
        void UpdateNameById(int id, string name);
    }
}
