using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
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
        public static void Code()
        {
            Random random = new Random();

            string[] fonts = { "微软雅黑", "宋体", "黑体", "隶书", "仿宋", "粗体", "篆书", "燕体", "楷书", "草书" };
            Color[] RandomColor = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            int[] Pen = { 44, 20, 30, 40, 33, 44, 22, 32 };
            int[] Point = { 43, 25, 35, 45, 41, 39, 29 };
            int[] line = { 100, 55, 34, 99, 34 };

            int linerandom = line[random.Next(line.Length)];
            Color tempColor = RandomColor[random.Next(RandomColor.Length)];
            string typeface = fonts[random.Next(fonts.Length)];
            int MyPen = Pen[random.Next(Pen.Length)];
            int MyPoint = Point[random.Next(Point.Length)];

            Bitmap image = new Bitmap(200, 100);  //生成一个像素图“画板”
            Graphics g = Graphics.FromImage(image);    //在画板的基础上生成一个绘图对象
            g.Clear(Color.AliceBlue);           //添加底色

            //画噪音点
            for (int j = 0; j < 100; j++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                image.SetPixel(x, y, Color);
            }

            //画噪音线
            for (int i = 0; i < linerandom; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                Color Color = RandomColor[random.Next(RandomColor.Length)];
                g.DrawLine(new Pen(Color), new Point(x1, y1), new Point(x2, y2));
            }

            g.DrawString(GenerateRandomNumber(4),       //绘制字符串
                new Font(typeface, MyPen),                //指定字体
                new SolidBrush(tempColor),      //绘制时使用的刷子
                new PointF(MyPen, MyPoint)                    //左上角定位
            );
            const string path = @"E:\17bang\hello.jpg";
            image.SetPixel(195, 95, Color.BlueViolet);  //绘制一个像素的点
            image.Save(path, ImageFormat.Jpeg);   //保存到文件
        }
        private static char[] constant = "1234567890,qwertyuiopasdfghjklzxcvbnm,QWERTYUIOPASDFGHJKLZXCVBNM".ToArray();
        private static string GenerateRandomNumber(int length)
        {
            StringBuilder newRandom = new StringBuilder(length);
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(length)]);
            }
            return newRandom.ToString();
        }
    }
}
