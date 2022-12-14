namespace TaskSehirTeknolojileri_Data.Entities.Dtos
{
    public class ProductDto : EntityBaseDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
    }
}
