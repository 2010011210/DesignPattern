namespace DesignPattern.Model.FactoryPattern
{
    public class BYDCarSong : IVehicle
    {
        public string Name = "Song";
        public string GetName()
        {
            var name = this.GetType().Name;
            Console.WriteLine(this.GetType().Name);
            return name;
        }
    }
}
