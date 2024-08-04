namespace DesignPattern.Model.FactoryPattern
{
    public class BYDCarHan : IVehicle, ICar
    {
        public string Name = "Yuan";
        public string GetName()
        {
            var name = this.GetType().Name;
            Console.WriteLine(this.GetType().Name);
            return name;
        }

        public void Speed()
        {
            Console.WriteLine($"{this.GetType().Name},Speed Mode");
        }
    }
}
