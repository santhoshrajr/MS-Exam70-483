using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.StateDesignPattern
{
    public class Gate
    {
        GateState gateState;

        public Gate()
        {
            this.gateState = new ClosedGateState(this);
        }

        public void Enter()
        {
            this.gateState.Enter();
        }

        public void PayOk()
        {
            this.gateState.PayOk();
        }
        public void PayFailed()
        {
            this.gateState.PayFailed();
        }

        public void ChangeState(GateState gateState)
        {
            this.gateState = gateState;
        }
      
    }

    public interface GateState
    {
        void Enter();
        void PayOk();
        void PayFailed();
    }
    
    public class OpenGateState : GateState
    {
        Gate gate;
        public OpenGateState(Gate gate)
        {
            this.gate = gate;
        }
        public void Enter()
        {
            //Do something
            this.gate.ChangeState(new ClosedGateState(this.gate));
        }

        public void PayFailed()
        {
            //Do Something

        }

        public void PayOk()
        {
            //Do Soemthing

        }
    }

    public class ClosedGateState : GateState
    {
        Gate gate;
        public ClosedGateState(Gate g)
        {
            this.gate = g;
        }
        public void Enter()
        {
            //Do something
        }

        public void PayFailed()
        {
            //Do something
        }

        public void PayOk()
        {
            //Do something
            this.gate.ChangeState(new OpenGateState(this.gate));
        }
    }
}
