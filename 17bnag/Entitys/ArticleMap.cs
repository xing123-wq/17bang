using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace _17bnag.Entitys
{
    public class ArticleMap
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public int ArticleId { get; set; }
        public PublishArticle Article { get; set; }
    }
}