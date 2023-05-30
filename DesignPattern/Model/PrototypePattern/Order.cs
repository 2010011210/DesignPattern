namespace DesignPattern.Model.PrototypePattern
{
    public class Order : IClone<Order>
    {
        public string Name { get; set; } 
        public Order Clone()
        {
            return (Order)this.MemberwiseClone();
        }

        public List<Item> Items = new List<Item>();

        public void SetName(string name) { 
            this.Name = name;
        }

        public string Print() 
        {
            Console.WriteLine(this.Name);
            return this.Name;
        }
    }
}
