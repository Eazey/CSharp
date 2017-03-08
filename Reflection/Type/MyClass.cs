using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class MyClass
    {
        //定义属性
        public string Name
        {
            get { return name; }
        }
        public int Age 
        {
            get { return age; }
        }
        private float height { get; set; }

        //定义字段
        public string Habit;
        public int Grade;
        private string name;
        private int age;

        // 构造方法
        public MyClass(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        //成员方法
        public void MyMethod1() { }
        public void MyMethod2() { }
        private void MyMethod3() { }

        public static void MyStaticMethod1() { }
        private static void MyStaticMethod2() { }
    }
}
