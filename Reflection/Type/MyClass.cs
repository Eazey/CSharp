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
