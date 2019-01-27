using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.Product
{
    public class AddProductModel : ProductModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int? UserId { get; set; }
    }
}
