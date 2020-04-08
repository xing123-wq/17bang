using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    ////声明一个委托：打水（ProvideWater），可以接受一个Person类的参数，返回值为int类型
    ////使用：方法，匿名方法，lambda表达式
    /// 给上述委托赋值，并运行该委托
    ////声明一个方法GetWater()，该方法接受ProvideWater作为参数，并能将ProvideWater的返回值输出
    public delegate int ProvideWater(Person person);
    public class Person
    {
        public int age { get; set; }
        public string Name { get; set; }
    }
}
