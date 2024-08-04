using Microsoft.IdentityModel.Tokens;

namespace DesignPattern.Model.ObserverPattern
{
    public class Cat 
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer) 
        {
            _observers.Add(observer);   
        }

        public void MiaoObserver() 
        {
            Console.WriteLine($"{this.GetType().Name}, Miao");
            if (!_observers.IsNullOrEmpty()) 
            {
                foreach (var item in _observers) 
                {
                    item.Action();
                }
            }
        }

        // 通过事件实现

        public event Action observeEvent;
        public void MiaoObserverByEvent()
        {
            Console.WriteLine($"{this.GetType().Name}, Miao By Event");
            if (observeEvent != null)
            {
                foreach (Action item in observeEvent.GetInvocationList())
                {
                    item.Invoke();
                }
            }
        }

    }
}
