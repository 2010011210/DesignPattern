namespace DesignPattern.Model.StatePattern
{
    public abstract class LightBase
    {
        public LightBase _LightBase;
        public virtual void Show() 
        {
            _LightBase.Show();
            //Console.WriteLine("子类继承实现自己的功能");
        }

        public abstract void TurnContext(Context context);
    }
}
