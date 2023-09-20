namespace DesignPattern.Model.StatePattern
{
    public class Context
    {
        public LightBase CurrentLight;

        public Context(LightBase lightBase)
        {
            this.CurrentLight = lightBase;
        }

        public void Show() 
        {
            this.CurrentLight.Show();
        }

        public void Turn() 
        {
            this.CurrentLight.TurnContext(this);
        }


    }
}
