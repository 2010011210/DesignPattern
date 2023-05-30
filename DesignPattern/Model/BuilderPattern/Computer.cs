namespace DesignPattern.Model.BuilderPattern
{
    public class Computer
    {
        public CPU CPU { get; set; }

        public Memory Memory { get; set; }

        public HardDisk Disk { get; set; }

        public Screen Screen { get; set; }

        public Brand Brand { get; set; }
    }
}
