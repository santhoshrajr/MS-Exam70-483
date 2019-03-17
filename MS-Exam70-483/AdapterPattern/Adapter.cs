using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.AdapterPattern
{
    //This is the input contract client has
    public interface ITarget
    {
        void Request();
    }

    public class Client
    {
        public void Invoke()
        {
            //uses request method of Adapter class to call specific request method of Adaptee
            ITarget target = new Adapter(new Adaptee());
            target.Request();
        }
    }
    //Adapter class is used in between two incompatible interfaces to make them work
    public class Adapter : ITarget
    {
       //Has a reference to Adaptee class
        public IAdaptee Adaptee { get; set; }
        public Adapter(IAdaptee adaptee)
        {
            Adaptee = adaptee;
        }
        //This method is not used to change any behaviour but to delegate it to Adaptee.
        public void Request()
        {
            Adaptee.SpecificRequest();
        }
    }
    //This is the output contract client needs.
    public interface IAdaptee
    {
        void SpecificRequest();
    }
    public class Adaptee : IAdaptee
    {
        //Method Client is expecting to invoke
        public void SpecificRequest()
        {
            Console.WriteLine("Specific Request");
        }
    }
}
