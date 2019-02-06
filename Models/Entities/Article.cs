using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool Enabled { get; set; }
        public int? ArticleCategoryId { get; set; }
        public int Visit { get; set; }
        public virtual ArticleCategory ArticleCategory { get; set; }

    }
}
