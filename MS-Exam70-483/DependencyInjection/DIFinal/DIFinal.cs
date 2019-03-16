using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.DependencyInjection.DIFinal
{
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
    //One class - Composition over inheritance
    public class Animal 
    {
        ISpeakBehavior behavior;
        //Constructor Injection
        public Animal(ISpeakBehavior speakBehavior)
        {
            behavior = speakBehavior;
        }
        public string Speak()
        {
            return behavior.Speak();
        }
    }
    class DIFinal
    {
        public void FinalDI()
        {
            Animal cat = new Animal(new CatSpeakBehavior());
            Animal dog = new Animal(new DogSpeakBehavior());
            Animal cow = new Animal(new CowSpeakBehavior());
            cat.Speak();
            dog.Speak();
            cow.Speak();
        }
    }
}
