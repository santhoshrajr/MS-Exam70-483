using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.ObserverPattern
{
    //Iobserver
    public interface IObserver
    {
        void Update();
    }
    //Iobservable having methods to add & update an Iobserver and to notify
    public interface IObservable
    {
        void Add(IObserver observer);
        void Remove(IObserver observer);
        void Notify();

    }
    //Concreate Observable 
    public class WeatherStation : IObservable
    {
        int temperature;
        List<IObserver> observers = new List<IObserver>();
        public void Add(IObserver observer)
        {
            this.observers.Add(observer);
        }
        //Heart of Observer pattern. Notifying each observer about the change
        public void Notify()
        {
            foreach(IObserver observer in observers)
            {
                observer.Update();
            }
        }

        public void Remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public int GetTemperature()
        {
            return temperature;
        }
    }
    //Concrete Observer
    public class PhoneDisplay : IObserver
    {
        WeatherStation station;
        public PhoneDisplay(WeatherStation weatherStation)
        {
            station = weatherStation;
        }
        public void Update()
        {
            station.GetTemperature();
        }
    }
    
}
