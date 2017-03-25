using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static IEnumerable<int> TestStateChange()
        {
            Console.WriteLine("First");
            Console.WriteLine("1 Before");
            yield return 1;

            Console.WriteLine("1 Later");
            Console.WriteLine("2 Before");
            yield return 2;

            Console.WriteLine("2 Later");
        }
        
        static void Main()
        {
            Console.WriteLine("Call TestStateChnage");
            IEnumerable<int> iteratorable = TestStateChange();

            Console.WriteLine("Call GetEnumerator");
            IEnumerator<int> iterator = iteratorable.GetEnumerator();

            Console.WriteLine("First Call MoveNext()");
            bool hasNext1 = iterator.MoveNext();
            Console.WriteLine( " " + iterator.Current);

            Console.WriteLine("Second Call MoveNext()");
            bool hasNext2 = iterator.MoveNext();
            Console.WriteLine(hasNext2 + " " + iterator.Current);

            Console.WriteLine("Third Call MoveNext()");
            bool hasNext3 = iterator.MoveNext();
            Console.WriteLine(hasNext3 + " " + iterator.Current);
            
            /////////////////////////////////////////////////////////

            MyClass1 mc1 = new MyClass1();

            foreach (var element in mc1)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            foreach (var element in mc1.EvenForRange(1, 20))
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            MyClass2 mc2 = new MyClass2();

            foreach (var element in mc2)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            
            //////////////////////////////////////////////////////////

            Zoo myZoo = new Zoo();

            myZoo.AddBird("Bird1");
            myZoo.AddBird("Bird2");
            myZoo.AddFish("Fish1");
            myZoo.AddFish("Fish2");

            foreach (var ani in myZoo)
            {
                Console.Write(ani + " ");
            }
            Console.WriteLine();

            foreach (var bird in myZoo.Birds)
            {
                Console.Write(bird + " ");
            }
            Console.WriteLine();

            foreach (var fish in myZoo.Fishs)
            {
                Console.Write(fish + " ");
            }
            Console.WriteLine();
        }
    }

    class MyClass1 : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }

        public IEnumerable EvenForRange(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }

    class MyClass2 : IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            yield return "Eazey";
            yield return "is very";
            yield return "beautiful.";
        }
    }

    class Zoo : IEnumerable
    {

        private List<Animal> animals = new List<Animal>();

        public void AddBird(string name)
        {
            animals.Add(new Animal { Name = name, animalTpye = Animal.AnimalsType.Bird });
        }

        public void AddFish(string name)
        {
            animals.Add(new Animal { Name = name, animalTpye = Animal.AnimalsType.Fish });
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var animal in animals)
            {
                yield return animal.Name;
            }
        }

        public IEnumerable Birds
        {
            get { return AnimalsForType(Animal.AnimalsType.Bird); }
        }

        public IEnumerable Fishs
        {
            get { return AnimalsForType(Animal.AnimalsType.Fish); }
        }

        private IEnumerable AnimalsForType(Animal.AnimalsType aniType)
        {
            foreach (var animal in animals)
            {
                if (animal.animalTpye == aniType)
                {
                    yield return animal.Name;
                }
            }
        }

        private class Animal
        {
            public enum AnimalsType { Bird, Fish }

            public string Name;
            public AnimalsType animalTpye;
        } 
    }
}
