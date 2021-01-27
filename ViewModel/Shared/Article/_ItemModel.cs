using System;

namespace ViewModel.Shared.Article
{
    public class _ItemModel
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public CommentBodyModel Body { get; set; }
        public _UserModel Author { get; set; }
        public bool Handpicked { get; set; }
        public AppraiseManagerModel AppraiseManager { get; set; }
        public int ReplyId { get; set; }
    }
}
