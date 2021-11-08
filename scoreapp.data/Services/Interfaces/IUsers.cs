using scoreapp.model.database.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scoreapp.data.Services.Interfaces
{
    public interface IUsers
    {
        public List<User> Index();
        public User Get(int Id);
        public List<Role> Get();
        public void Post(User User,Guid RoleId);
        public Role Get(Guid RoleId);
        public List<Permission> GetAllPermissions();
        public void Post(Role Role, List<Permission> Permissions);
        public Task<int> SaveChangesAsync();
        public User edit(int Id);
        public User Update(User user);
    }
}
