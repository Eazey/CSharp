using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    class Program
    {
        //匹配
        void Match()
        {
            //只能匹配数字串
            //原因：此处限定了匹配数字0次或者多次，且开头与结尾均限定为数字，所以必须是纯数字串，
            //     如果去掉^和$，则该串含有数字串即可
            string pattern = @"^\d*$";
            string input1 = "999";
            string input2 = "qwfsdf";
            string input3 = "9w3423";
            //只要有一个满足正则表达式的子字符串就返回true
            Console.WriteLine(Regex.IsMatch(input1, pattern));
            Console.WriteLine(Regex.IsMatch(input2, pattern));
            Console.WriteLine(Regex.IsMatch(input3, pattern));
        }

        //筛选
        void Filtrate()
        {
            string input = "34 $#%((( d 是大家 _\n";
            string pattern = @"\d|[a-z]";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match result in matches)
            {
                Console.WriteLine(result.ToString());
            }
        }

        //分割
        void Segmentation()
        {
            //给定一个包含很多名字和分隔符的字符串
            string input = "ZhangSan,LiSi;WangWu.ZhaoLiu";
            //匹配字符所包含的分隔符
            string pattern = @"[;,.]";
            //也可以利用或运算写成下面这种形式
            //string pattern = @"[,]|[;]|[.]";
            //利用此方法分割后会得到一个字符串数组
            string[] names = Regex.Split(input, pattern);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        //替换
        void Replace()
        {
            string input = "What's the f*ck!";
            string pattern = @"f*ck";
            string replacement = "****";
            string resulet = Regex.Replace(input, pattern, replacement);
            Console.WriteLine(resulet);
        }

        //正则表达式训练案例：IPv4地址识别
        void CheckoutIPv4()
        {
            //校验IPv4的地址 0-255.0-255.0-255.0-255 不能以0开头
            //string ipPattern = @"^(((2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)[.]){3}(2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d))$";
            //这里为了便于测试，可以之写出一组数字+点的组合
            string ipPattern = @"^((2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)[.])$";
            string input1 = "192.";
            string input2 = "001.";
            string input3 = "666.";
            string input4 = "104";
            string input5 = "192.192.";
            Console.WriteLine(Regex.IsMatch(input1, ipPattern));
            Console.WriteLine(Regex.IsMatch(input2, ipPattern));
            Console.WriteLine(Regex.IsMatch(input3, ipPattern));
            Console.WriteLine(Regex.IsMatch(input4, ipPattern));
            Console.WriteLine(Regex.IsMatch(input5, ipPattern));
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("----------Match----------");
            program.Match();
            Console.WriteLine("----------Filtrate----------");
            program.Filtrate();
            Console.WriteLine("----------Segmentation----------");
            program.Segmentation();
            Console.WriteLine("----------Replace----------");
            program.Replace();
            Console.WriteLine("----------CheckoutIPv4----------");
            program.CheckoutIPv4();
            Console.ReadKey();
        }
        
    }
}
