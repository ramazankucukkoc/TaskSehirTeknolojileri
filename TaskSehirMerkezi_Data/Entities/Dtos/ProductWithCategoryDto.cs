﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSehirTeknolojileri_Data.Entities.Dtos
{
    public class ProductWithCategoryDto:ProductDto
    {
        public string CategoryName { get; set; }

    }
}