using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.Command_Pattern
{
    
    public class Invoker
    {
        ICommand on, off;
        public Invoker(ICommand on, ICommand off)
        {
            this.on = on;
            this.off = off;
        }
        public void ClickOn()
        {
            this.on.Execute();
        }
        public void ClickOff()
        {
            this.off.Execute();
        }
    }
    public interface ICommand
    {
        void Execute();
        void Unexecute();

    }
    public class LightOnCommand : ICommand
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            //Encapuslatiing the Action
            light.On();
        }

        public void Unexecute()
        {
            //Encapsualting the action
            light.Off();
        }
    }
    public class LightOffCommand : ICommand
    {
        Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            this.light.Off();
        }

        public void Unexecute()
        {
            this.light.On();
        }
    }
    public class Light
    {
        public void On()
        {
            //Do Something
        }

        public void Off()
        {
            //Do Something
        }
    }
}
