using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.DependencyInjection
{
    public interface IAnimal
    {
        string Speak();
    }
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "meow";
        }
    }
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "woof";
        }
    }
    public class Cow : IAnimal
    {
        public string Speak()
        {
            return "moo";
        }
    }

    public class Initial
    {
        public void CallSpeak()
        {
            IAnimal cat = new Cat();
            IAnimal dog = new Dog();
            IAnimal cow = new Cow();

            cat.Speak(); //meow
            dog.Speak(); //woof
            cow.Speak(); //moo

        }
    }
}
