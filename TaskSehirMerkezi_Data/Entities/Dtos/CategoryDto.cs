using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSehirTeknolojileri_Core.Entities;

namespace TaskSehirTeknolojileri_Data.Entities.Dtos
{
    public class CategoryDto:EntityBaseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
