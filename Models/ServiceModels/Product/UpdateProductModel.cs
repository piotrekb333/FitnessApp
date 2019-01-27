using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.Product
{
    public class UpdateProductModel : ProductModel
    {
        public int Id { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
