using System;
using System.Collections.Generic;

namespace CSharpTest
{
    class Program
    {
        class MyClass
        {
            public string Name { get; }
            public MyClass(string name)
            {
                Name = name;
            }
        }
        static void Main()
        {
            //定义及赋值方式1 + 常用方法
            Dictionary<string, int> MyDic1 = new Dictionary<string, int>();
            MyDic1.Add("AAA", 0);
            MyDic1.Add("BBB", 1);
            MyDic1.Clear(); //清空
            MyDic1["CCC"] = 2;
            MyDic1["DDD"] = 3; 
            MyDic1.Remove("CCC"); //移除Key为"CCC"的那组键值

            MyDic1.Add("AAA", 0);
            MyDic1.Add("BBB", 1);
            MyDic1.Add("CCC", 2);

            //定义及赋值方式2
            Dictionary<int, string> MyDic2 = new Dictionary<int, string>
            {
                { 0,"AAAA" },
                {1,"BBBB" },
                {2,"CCCC" }
            };

            //定义及赋值方式3 (C# 6.0及以上特性) 
            Dictionary<int, MyClass> MyDic3 = new Dictionary<int, MyClass>
            {
                [0] = new MyClass("AA"),
                [1] = new MyClass("BB"),
                [2] = new MyClass("CC")
            };

            //遍历字典1
            //字典的元素类型并不是Dictionary类型 
            //因为字典可以存储多组键值
            //而字典中的每个元素只是一组键值
            //在不清楚元素是什么类型时，可以用var关键字
            //让编译器自己去做类型推导
            foreach (var element in MyDic1)
            {
                Console.WriteLine(element.Key + " " + element.Value);
            }
            Console.WriteLine();

            //遍历字典2
            //或者显式的指定键值的类型KeyValuePair<TKey,TValue>
            //TKey表示键的类型参数
            //TValue表示值的类型参数
            //类型要与Dictionary类型一致
            foreach (KeyValuePair<int, string> element in MyDic2)
            {
                Console.WriteLine(element.Key + " " + element.Value);
            }
            Console.WriteLine();

            //遍历字典3
            foreach (var element in MyDic3)
            {
                Console.WriteLine(element.Key + " " + element.Value.Name);
            }
            Console.WriteLine();


            // Dictionary中含有Key与Value的定制集合，通过Dictionary对象的Keys和Values属性访问

            //遍历Key 通过Key找到Value
            foreach (string key in MyDic1.Keys)
            {
                Console.WriteLine(key + " " + MyDic1[key]);
            }
            Console.WriteLine();

            //直接遍历Value
            foreach (int value in MyDic1.Values)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();

            //将Key值集合通过List的构造函数转化为List集合列表（含索引）
            List<String> MyDic1_List = new List<string>(MyDic1.Keys);
            for (int i = 0; i < MyDic1_List.Count; i++)
            {
                var key = MyDic1_List[i];
                var value = MyDic1[key];
                Console.WriteLine(key + " " + value);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
