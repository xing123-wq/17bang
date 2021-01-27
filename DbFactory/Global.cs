using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    static class Global
    {
        internal static SqlContext context = new SqlContext();
        public static DateTime Time { get => DateTime.Now; }

        #region article
        public const string Article_Title = "文章标题";

        #region article_body
        public const string Article_Body = "　关于朋友离别的文章美文二、与知己一路相伴我一路在寻找知己，并且想与我的知己一路相伴，" +
         "已养成习惯，静静地等待知己灰色的头像变成彩色的，习惯了你的迟到甚至缺席，习惯了不在线时相互的留言，" +
         "习惯了等你的时候……习惯了你不在线时的失落，更习惯了你在线时的点点惊喜，早已习惯了你的一切，我要告诉自己" +
         "，习惯了以你为圆心，以我们彼此的心为半径画圆，爱圈中没有了你，就像圆没有了圆心，没办法完成一个完整的圆。" +
         "在过去的交友岁月里，我的朋友确实不少，有一些要好的朋友，为此我也写过不少有关《朋友》和《人际关系》的文章，" +
         "得到众友的认可，但在我心里，朋友是一个无法固定的代名词，可以是公众场合，可以是利益均沾的，很难贴近灵魂深处，很难交心，" +
         "我不希望公众的朋友当我的知己，因为公友对知己不公。一个人一生能有一个知己此生足矣，更何况我有了你这个朋友做为知己，所以，" +
         "无论我栖身在哪里，无论我是遭受怎样的境遇，那心中的一方净土都会有你的存在，如果说在我们以后相往的过程中，认为时间会冲淡一切地话" +
         "，那这日日夜夜思念的这份挚情就已经不存在了。　　我们都不希望看到这样的结局。我们说过也有约定，知己之情不受任何时间的变化而受其影" +
         "响我们的关系，不管社会如何变迁，人们追求多么现实，都不能影响彼此坚实的基础。当知己绿叶变黄时，我们都要自觉自愿负起责任，按期浇灌，施肥，长有杂" +
         "草及时清除，让我们这颗绿苗茁壮成长。在人生最灰暗的日子里，我并不孤单，因为有你的陪伴，有你在电话旁或视频前默默地听我讲话，在" +
         "心中有你在漆黑的夜里陪我走过那段人生路，也许没有哭泣，但心中却充满了泪水，直到无法抑制时，它便喷涌出来，但我的知己，我并没有让你看见我的" +
         "泪水，因为我想给你一个微笑，有了你，我便不再畏惧，有了你，我便可以露出最灿烂的笑容，因为有你在，更值得我去安抚，有你值得我去给予。" +
         "友谊是两颗心真诚相待，而不是一颗心对另一颗心的敲打。没有一个词比朋友这个词用的更广泛，也没什么比真正的知己更为罕见。无论命运把我们带到何方，" +
         "相吸引的知己情谊纽带总会把我们紧紧相连。我相信知己的友情来自你我的真诚，来自你我那两颗永远相印的心，更来自你我的细微经营！" +
         "不管世事如何变迁，你始终是我的知己，把知己的真情深深地烙印在我的心底，让我永远珍藏，与知己一路相伴。" +
         "亲人是上天注定，恋人是前世安排，爱人是缘分融合，知己是感情归宿。" +
         "有时候，人们往往都渴望有一份真感情。在熙熙攘攘的街道中，在闪闪烁烁的霓虹灯下，在孤清寂静的田野里，在风雨飘摇的季节，渴望着一个人，" +
         " 一颗心，一份情……知己是什么？从没有过具体的答案，也没有统一的形象。知己是一种感觉，是一份思念，是一个牵挂，知己是白天的守侯，是黑夜的等待，知己是一生的甜蜜。" +
         "知己的感觉是什么？谁也说不清楚道不明，是酸，酸的让你无奈；是甜，甜的让你回味；是苦，苦的让你流泪；是辣，辣的让你振奋。拥有了知己就拥有了人生百味，拥有了知己就拥有了全部的感情世界。" +
         "于是，就有了牵挂。";
        #endregion

        #endregion

        #region Category
        public const string category_title = "系列——标题";
        public const string category_body = "系列——内容";
        #endregion

        #region AdInWidget     
        public static string WeChatShop_Text = "微商宣传广告语 日加1000精准";
        public static string Finger_Text = "如果五指一样长，怎能满足用户不同需求？";
        public static string Class_Text = "如果你听了一课之后发现不喜欢这门课程，那你可以要求退回你的学费，但必须用法语说。";
        public static string Hero_Text = "煮酒论英雄才子赢天下";
        public static string Yafang_Text = "雅芳比女人更了解女人";

        public static string Common_Url = "http://task.zyfei.net/";

        #endregion

        #region comment
        public static string comment_article1 = "写得好！太棒了！";
        public static string comment_article2 = "楼主棒棒哒！楼主加油！";
        public static string comment_article3 = "我爱你楼主！楼主真厉害！";
        public static string comment_article4 = "有点菜，看不懂！楼主能解释一下吗？";

        #endregion
    }
}
