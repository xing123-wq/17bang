using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class ContentService
    {
        //修改之前的属性验证：problem.Reward为负数时直接抛出“参数越界”异常
        //内容（Content）发布（Publish）的时候检查其作者（Author）是否为空，如果为空抛出“参数为空”异常
        //在ContentService中捕获异常
        //如果是参数为空异常，Console.WriteLine() 输出：内容的作者不能为空，将当前异常封装进新异常的InnerException，再将新异常抛出
        //如果是参数越界异常，Console.WriteLine() 输出：求助的Reward为负数（-XX），不再抛出异常
        //ContentService中无论是否捕获异常，均要Console.WriteLine() 输出：XXXX年XX月XX日 XX点XX分XX秒（当前时间），请求发布内容（Id=XXX）
        //在Main()函数调用ContentService时，捕获一切异常，并记录（）异常的消息和堆栈信息
        public static void Publish(Content content)
        {
            try
            {
                content.Publish();
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine("内容的作者不能为空" + e1.InnerException);

            }
            catch (ArgumentException e2)
            {
                //Console.WriteLine();
                //e2.InnerException = e2;
                throw (new Exception("求助的Reward为负数（-XX）", e2));
            }
            finally
            {
                Console.WriteLine($"{DateTime.Now}请求发布内容（id={content.Author.Id})");
            }
        }
    }
}