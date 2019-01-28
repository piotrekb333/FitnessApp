using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.Product
{
    public class ProductGroupsDto
    {
        public DateTime Date { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
