
using TaskSehirTeknolojileri_Core.Entities;
using TaskSehirTeknolojileri_Data.Entities.Abstract;

namespace TaskSehirTeknolojileri_Data.Entities.Concrete
{
    public class Product : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
