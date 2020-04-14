using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Article : Content
    {

        //在现有作业的基础上，观察一起帮的文章板块，以此为蓝本，补充（如果还没有的话）声明：
        //评论（Comment）类
        //评价（Appraise）类：包括“赞”和“踩”
        //关键字（Keyword）类
        //并构建以下关系：
        //一篇文章可以有多个评论
        //一个评论必须有一个它所评论的文章
        //每个文章和评论都有一个评价
        //一篇文章可以有多个关键字，一个关键字可以对应多篇文章
        public Article(string kind) : base(kind)
        {
       
        }
        public Article()
        {

        }
        public static void MoneyAeount(int reward)
        {
            Console.WriteLine("覆盖" + reward + "了");
        }

    }
    //确保文章（Article）的标题不能为null值，
    //也不能为一个或多个空字符组成的字符串，而且如果标题前后有空格，也予以删除
    //设计一个适用的机制，能确保用户（User）的昵称（Name）不能含有admin、
    //17bang、管理员等敏感词。
    //确保用户（User）的密码（Password）：
    //长度不低于6
    //必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成
    //实现GetCount(string container, string target)方法，
    //可以统计出container中有多少个target
    //不使用string自带的Join()方法，定义一个mimicJoin()方法，
    //能将若干字符串用指定的分隔符连接起来，
    //比如：mimicJoin("-","a","b","c","d")，其运行结果为：a-b-c-d
}
