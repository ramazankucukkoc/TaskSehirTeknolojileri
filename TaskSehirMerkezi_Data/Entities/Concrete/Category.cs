

using TaskSehirTeknolojileri_Core.Entities;
using TaskSehirTeknolojileri_Data.Entities.Abstract;

namespace TaskSehirTeknolojileri_Data.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
