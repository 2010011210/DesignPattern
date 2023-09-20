namespace DesignPattern.Model.StatePattern
{
    public class RedLight : LightBase
    {
        public override void Show()
        {
            Console.WriteLine("目前是红灯，禁止通行");
        }

        public override void TurnContext(Context context)
        {
            context.CurrentLight = new GreenLight();
        }
    }
}
