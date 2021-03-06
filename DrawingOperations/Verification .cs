﻿using EO.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrawingOperations
{
    public class Verification
    {
        //作业：
        //参考一起帮的登录页面，绘制一个验证码图片，存放到当前项目中。验证码应包含：
        //随机字符串
        //混淆用的各色像素点
        //混淆用的直线（或曲线）
        static Random random = new Random();
        static string[] fonts = { "微软雅黑", "宋体", "黑体", "隶书", "仿宋", "粗体", "篆书", "燕体", "楷书", "草书" };
        static Color[] RandomColor = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
        static int[] Pen = { 1, 3, 4, 5, 7, 8, 9, 10, 11, 12 };
        static int[] Point = { 1, 3, 4, 5, 7, 8, 9, 10, 11, 12 };
        static int[] line = { 10, 11, 12, 14, 15, 16, 17, 18, 19, 20, 30 };
        private static char[] constant = "1234567890,qwertyuiopasdfghjklzxcvbnm,QWERTYUIOPASDFGHJKLZXCVBNM".ToArray();
        public static int Width = 200;
        public static int Hight = 100;
        static int linerandom = line[random.Next(line.Length)];
        static Color tempColor = RandomColor[random.Next(RandomColor.Length)];
        static string typeface = fonts[random.Next(fonts.Length)];
        static int MyPen = Pen[random.Next(Pen.Length)];
        static int MyPoint = Point[random.Next(Point.Length)];
        public static Bitmap image;
        static Graphics g;
        public static void Do()
        {
            Task<Bitmap>.Run(() => NewBitmap()).Wait();
            Console.Read();
            Task.Run(() => SetPixels()).Wait();
            Console.Read();
            Task.Run(() => DrawLines());
            Console.Read();
        }
        public static void NewBitmap()
        {
            //生成一个像素图“画板”
            //在一个任务（Task）中生成画布
            image = new Bitmap(Width, Hight);
            g = Graphics.FromImage(image);    //在画板的基础上生成一个绘图对象
            Console.WriteLine($"imagethread:{Thread.CurrentThread.ManagedThreadId}");
        }
        //使用生成的画布，用两个任务完成：
        public static void SetPixels()
        {
            //在画布上添加干扰线条
            for (int j = 0; j < linerandom; j++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                image.SetPixel(x, y, Color);
            }
            //Console.WriteLine($"point:{Thread.CurrentThread.ManagedThreadId}");
            //Console.Read();

        }
        public static void DrawLines()
        {
            //在画布上添加干扰点
            for (int i = 0; i < linerandom; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                g.DrawLine(new Pen(Color), new Point(x1, y1), new Point(x2, y2));
            }
            //Console.WriteLine($"line:{Thread.CurrentThread.ManagedThreadId}");
            //Console.Read();

        }
        public static string GenerateRandomNumber(int length)
        {
            if (length > 4 || 4 < length)
            {
                throw new ArgumentException("字符串长度不能超过4");
            }
            StringBuilder newRandom = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[random.Next(length)]);
            }
            return newRandom.ToString();
        }

        public static void Captcha(string Length)
        {
            image = new Bitmap(55, 32);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.AliceBlue);           //添加底色
            g.DrawString(Length,       //绘制字符串
                new Font(typeface, 15),                //指定字体
                new SolidBrush(tempColor),      //绘制时使用的刷子
                new PointF(5, 5));                    //左上角定位
            for (int i = 0; i < linerandom; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                g.DrawLine(new Pen(Color), new Point(x1, y1), new Point(x2, y2));
            }
            for (int j = 0; j < linerandom; j++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                image.SetPixel(x, y, Color);
            }
            image.SetPixel(15, 15, Color.BlueViolet);  //绘制一个像素的点
            //image.Save(@"E:\17bang\\.jpg", ImageFormat.Jpeg);   //保存到文件
        }
        //重构之前的验证码作业：
        //以上作业，需要在控制台输出线程和Task的Id，以演示异步并发的运行。
        public static async void Code()
        {
            //创建一个新的前台线程（Thread），在这个线程上运行生成随机字符串的代码
            Thread thread = new Thread(() =>
            {
                Thread.SpinWait(100);
                try
                {
                    GenerateRandomNumber(4);
                }
                catch (ArgumentException e)
                {
                    Sava(e);
                    throw new ArgumentException("参数异常");
                }
            });
            thread.IsBackground = true;
            Console.WriteLine($"thread:{Thread.CurrentThread.ManagedThreadId}");
            thread.Start();
            //能捕获抛出的若干异常，并相应的处理
            try
            {
                Do();
                g.Clear(Color.AliceBlue);           //添加底色
                g.DrawString(GenerateRandomNumber(4),       //绘制字符串
                    new Font(typeface, MyPen),                //指定字体
                    new SolidBrush(tempColor),      //绘制时使用的刷子
                    new PointF(MyPen, MyPoint));                    //左上角定位
                image.SetPixel(195, 95, Color.BlueViolet);  //绘制一个像素的点
            }
            catch (ArgumentNullException e)
            {
                Sava(e);
                throw new ArgumentNullException("参数null异常");
            }
            catch (ArgumentException e1)
            {
                Sava(e1);
                //重新抛出
                throw new ArgumentException("参数异常");
            }
            catch (OutOfMemoryException e2)
            {
                Sava(e2);
                throw new OutOfMemoryException("内存空间异常");
            }
            catch (Generateabnormal e2)
            {
                Sava(e2);
                throw new Generateabnormal("生成异常");
            }
            //将生成的验证码图片异步的存入文件
            await Task.Run(() =>
            {
                Console.WriteLine($"imagesave:{Thread.CurrentThread.ManagedThreadId}");
                image.Save(@"E:\17bang\\.jpg", ImageFormat.Jpeg);   //保存到文件
            });
        }
        public static void Sava(Exception Record)
        {
            const string path = @"E:\17bang\\.txt";
            using (StreamWriter writer = File.AppendText(path))
            {
                DateTime date = DateTime.Now;//设置日志时间
                string time = date.ToString("yyyy年MM月dd日HH点mm分ss秒");
                writer.WriteLine("异常时间" + time);
                writer.WriteLine("异常对象" + Record.Source);
                writer.WriteLine("调用堆栈" + Record.StackTrace.Trim());
                writer.WriteLine("调用堆栈" + Record.ToString());
                writer.Flush();
            }
        }

        [Serializable] //声明为可序列化的 因为要写入文件中
        public class Generateabnormal : Exception//由用户程序引发，用于派生自定义的异常类型
        {
            /// <summary>
            /// 默认构造函数
            /// </summary>
            public Generateabnormal() { }
            public Generateabnormal(string message)
                : base(message) { }
            public Generateabnormal(string message, Exception inner)
                : base(message, inner) { }

            protected Generateabnormal(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}
