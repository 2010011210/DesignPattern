using System.Xml.Linq;

namespace DesignPattern.Model.FactoryPattern
{
    public class TeslaCarModelY : IVehicle, ISUV
    {
        public string GetName()
        {
            var name = this.GetType().Name;
            Console.WriteLine(this.GetType().Name);
            return name;
        }

        public void Sport()
        {
            Console.WriteLine($"{this.GetType().Name},Sport Mode");
        }
    }
}
