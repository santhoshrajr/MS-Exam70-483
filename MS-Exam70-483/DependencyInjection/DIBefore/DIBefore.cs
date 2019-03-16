using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.DependencyInjection.DIBefore
{
    public interface IAnimal
    {
        string Speak();
    }

    public interface ISpeakBehavior
    {
        string Speak();
    }
    class CatSpeakBehavior : ISpeakBehavior
    {
        public string Speak()
        {
            return "meow";
        }
    }
    class CowSpeakBehavior : ISpeakBehavior
    {
        public string Speak()
        {
            return "moo";
        }
    }
    class DogSpeakBehavior : ISpeakBehavior
    {
        public string Speak()
        {
            return "woof";
        }
    }

    public class Cat : IAnimal
    {
        //Bad- instead use dependency injection
        CatSpeakBehavior behavior = new CatSpeakBehavior();
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    public class Dog : IAnimal
    {
        //Bad- instead use dependency injection
        DogSpeakBehavior behavior = new DogSpeakBehavior();
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    public class Cow : IAnimal
    {
        //Bad- instead use dependency injection
        CowSpeakBehavior behavior = new CowSpeakBehavior();
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    public class BeforeDI
    {
        public void DIBeefore()
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
