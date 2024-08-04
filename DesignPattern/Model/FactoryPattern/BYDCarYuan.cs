namespace DesignPattern.Model.FactoryPattern
{
    public class BYDCarYuan : IVehicle, ISUV
    {
        public string Name = "Yuan";
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
