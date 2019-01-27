using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.Product
{
    public class ProductModel
    {
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Carbohydrates { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public DateTime? DateUser { get; set; }
    }
}
