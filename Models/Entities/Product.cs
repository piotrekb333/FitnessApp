using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Carbohydrates { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public DateTime? DateUser { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
