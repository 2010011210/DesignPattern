namespace DesignPattern.Model.ObserverPattern
{
    public class Dog : IObserver
    {
        public void Action()
        {
            this.Wang();
        }

        public void Wang() 
        {
            Console.WriteLine("Wang");
        }

    }
}
