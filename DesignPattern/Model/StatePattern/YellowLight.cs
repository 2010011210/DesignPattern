namespace DesignPattern.Model.StatePattern
{
    public class YellowLight : LightBase
    {
        public override void Show()
        {
            Console.WriteLine("目前是黄灯，禁止通行");
        }

        public override void TurnContext(Context context)
        {
            context.CurrentLight = new RedLight();
        }
    }
}
