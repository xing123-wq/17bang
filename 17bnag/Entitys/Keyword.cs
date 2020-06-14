using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _17bnag.Entitys
{
    public class Keyword
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ArticleMap> Articles { get; set; }
        public IList<KeywordMiddle> Problems { get; set; }

    }
}