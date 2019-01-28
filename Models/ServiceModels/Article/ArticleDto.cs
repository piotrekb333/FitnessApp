using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.Article
{
    public class ArticleDto : ArticleModel
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
