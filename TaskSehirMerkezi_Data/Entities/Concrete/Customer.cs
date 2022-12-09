
using TaskSehirTeknolojileri_Core.Entities;
using TaskSehirTeknolojileri_Data.Entities.Abstract;

namespace TaskSehirTeknolojileri_Data.Entities.Concrete
{
    public class Customer : EntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
    }
}
