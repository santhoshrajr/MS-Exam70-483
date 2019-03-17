using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.DependencyInjection.DIAfter
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
        ISpeakBehavior behavior;
        //Constructor Injection
        public Cat(ISpeakBehavior speakBehavior)
        {
            behavior = speakBehavior;
        }
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    public class Dog : IAnimal
    {
        ISpeakBehavior behavior;
        public Dog(ISpeakBehavior speakBehavior)
        {
            behavior = speakBehavior;
        }
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    public class Cow : IAnimal
    {
        ISpeakBehavior behavior;
        public Cow(ISpeakBehavior speakBehavior)
        {
            behavior = speakBehavior;
        }
        public string Speak()
        {
            return behavior.Speak();
        }
    }
   
    public class DIAfter
    {
        public void AfterDI()
        {
            //Constructor injection
            Cat cat = new Cat(new CatSpeakBehavior());
            Dog dog = new Dog(new DogSpeakBehavior());
            Cow cow = new Cow(new CowSpeakBehavior());
            cat.Speak();
            dog.Speak();
            cow.Speak();
        }
    }
}
