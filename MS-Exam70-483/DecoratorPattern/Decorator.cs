using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.DecoratorPattern
{
    //Component Base class
    public abstract class Beverage
    {
        public abstract int Cost();
    }
    //AddonDecorator is a component and has a component
    public abstract class AddOnDecorator : Beverage
    {
        public abstract override int Cost();
    }
    //Concrete Component
    public class Espresso : Beverage
    {
        public override int Cost()
        {
            return 1;
        }
    }
    //Concrete decorator 
    public class CaramelDecorator : AddOnDecorator
    {
        Beverage beverage;
        public CaramelDecorator(Beverage b)
        {
            beverage = b;
        }
        //Decorator wraps the component or an other decorator
        public override int Cost()
        {
            return this.beverage.Cost() + 1;
        }
    }
   
}
