using System;
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
            MyClass my = new MyClass("Eazye", 21);
            //通过类的type对象获取他所在的程序集
            Assembly assem = my.GetType().Assembly;
            //获取程序集的完整名称
            Console.WriteLine(assem.FullName);
            //获取该程序集下的所有类型  这里有MyClass和Program两个类
            Type[] types = assem.GetTypes();
            foreach (var type in types)
            {
                //打印类型+类名
                Console.WriteLine(type + type.Name);
            }
            Console.ReadKey();
        }
    }
}
