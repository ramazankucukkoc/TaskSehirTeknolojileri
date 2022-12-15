using Microsoft.AspNetCore.Identity;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Data.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

    }
}
