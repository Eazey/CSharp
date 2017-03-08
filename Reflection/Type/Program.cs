using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass("Eazey", 21);
            Type t = mc.GetType();

            //只反射类中的公共成员 包括静态方法 反射的是类不是对象

            Console.WriteLine(t.Name);//类
            Console.WriteLine(t.Namespace);//命名空间
            Console.WriteLine(t.Assembly);//程序集
            //字段
            FieldInfo[] fieldInfos = t.GetFields();
            foreach(FieldInfo info in fieldInfos)
            {
                Console.Write(info.Name+" ");
            }
            Console.WriteLine();
            //属性
            PropertyInfo[] propertyInfos = t.GetProperties();
            foreach (var info in propertyInfos)
            {
                Console.Write(info.Name + " ");
            }
            Console.WriteLine();
            //方法 包含属性的get set方法 成员方法 以及 继承方法
            MethodInfo[] methodInfos = t.GetMethods();
            foreach (var info in methodInfos)
            {
                Console.Write(info.Name + " ");
            }
            Console.WriteLine();
        }
    }

    public class MyClass
    {
        //定义属性
        public string Name { get;private set;}
        public int Age { get; private set;}
        //定义字段
        public string Habit;
        public int Grade;

        // 构造方法
        public MyClass(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //成员方法
        public void MyMethod1() { }
        public void MyMethod2() { }

        public static void MyStaticMethod(){ }
    }
}
