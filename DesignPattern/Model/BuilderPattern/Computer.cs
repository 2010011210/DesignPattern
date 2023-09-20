namespace DesignPattern.Model.BuilderPattern
{
    public class Computer
    {
        public string Name => GetName();
        public CPU CPU { get; set; }

        public Memory Memory { get; set; }

        public HardDisk Disk { get; set; }

        public Screen Screen { get; set; }

        public Brand Brand { get; set; }

        public string GetName()
        {
            return $"Name：{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
        }
    }

    
}
