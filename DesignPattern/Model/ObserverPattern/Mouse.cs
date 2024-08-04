namespace DesignPattern.Model.ObserverPattern
{
    public class Mouse : IObserver
    {
        public void Action()
        {
            this.Zhi();
        }

        public void Zhi() 
        {
            Console.WriteLine("Zhi");
        }
    }
}
