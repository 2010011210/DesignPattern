namespace DesignPattern.Model.ObserverPattern
{
    public class Child : IObserver
    {
        public void Action()
        {
            this.WA();
        }

        public void WA() 
        {
            Console.WriteLine("WA");
        }
    }
}
