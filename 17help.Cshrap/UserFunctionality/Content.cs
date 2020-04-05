using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    //让User类无法被继承
    //观察一起帮的求助（Problem）、文章（Article）和意见建议（Suggest），
    //根据他们的特点，抽象出一个父类：内容（Content）
    //Content中有一个字段：kind，
    //记录内容的种类（problem/article/suggest等），只能被子类使用
    //确保每个Content对象都有kind的非空值
    //Content中的createTime，不能被子类使用，
    //但只读属性PublishTime使用它为外部提供内容的发布时间
    //其他方法和属性请自行考虑，尽量贴近一起帮的功能实现。
    //实例化文章和意见建议，调用他们：
    //继承自父类的属性和方法
    //自己的属性和方法
    //再为之前所有类（含User、HelpMoney等）抽象一个基类：
    //Entity，包含一个只读的Id属性。试一试，Suggest能有Id属性么？
    public class Content : Entity<int>
    {
        protected string Kind;
        private User author;
        private string _title;
        private DateTime _publishTime;
        public DateTime PublishDateTime { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public User Author { get; set; }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("标题不能为null或空值");
                }

                _title = value.Trim();
            }
        }
        public void PublishDateTimre()
        {
            if (Author == null)
            {
                throw new ArgumentException("不能没有作者");
            }
            _publishTime = DateTime.Now;//在发布时调用此方法为PublishTime赋值
            Author.HelpMoney += 1;
        }
        public Content(string kind)
        {

        }
        public void Publish()
        {

        }
        static void headline()
        {

        }//标题
        static string describe(string indetail)
        {
            return indetail;
        }
    }
    //之前的Content类，其中的CreateTime（创建时间）和PublishTime（发布时间）都是只读的属性，想一想他们应该在哪里赋值比较好，并完成相应代码
    //在Content之外封装一个方法，可以修改Content的CreateTime和PublishTime
    //自定义一个特性HelpMoneyChanged（帮帮币变化）：
    //该特性只能用于方法
    //有一个构造函数，可以接受一个int类型的参数amount，表示帮帮币变化的数量
    //有一个string类型的Message属性，记录帮帮币变化的原因
    //将HelpMoneyChanged应用于Publish()方法
    //用反射获取Publish()上的特性实例，输出其中包含的信息
}
