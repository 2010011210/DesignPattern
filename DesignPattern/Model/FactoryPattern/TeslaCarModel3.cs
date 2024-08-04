namespace DesignPattern.Model.FactoryPattern
{
    public class TeslaCarModel3 : IVehicle, ICar
   {
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
