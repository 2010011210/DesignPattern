namespace DesignPattern.Model.StatePattern
{
    public class GreenLight : LightBase
    {
        public override void Show()
        {
            Console.WriteLine("目前是绿灯，通行");
        }

        public override void TurnContext(Context context)
        {
            context.CurrentLight = new YellowLight();
        }
    }
}
