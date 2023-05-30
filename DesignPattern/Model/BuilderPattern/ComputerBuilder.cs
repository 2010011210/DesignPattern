namespace DesignPattern.Model.BuilderPattern
{
    public class ComputerBuilder
    {
        private Computer _computer = new Computer();

        public ComputerBuilder SetCPU(string type) 
        {
            _computer.CPU = new CPU { CPUType = type};
            return this;
        }

        public ComputerBuilder SetMemory(int  size)
        {
            _computer.Memory = new Memory {  Size = size };
            return this;
        }

        public ComputerBuilder SetHardDisk(int capacity)
        {
            _computer.Disk = new HardDisk {  Capacity = capacity };
            return this;
        }

        public ComputerBuilder SetScreen(decimal size)
        {
            _computer.Screen = new Screen { Size = size  };
            return this;
        }

        public ComputerBuilder SetBrand(string name)
        {
            _computer.Brand = new Brand { Name = name };
            return this;
        }

        public Computer Build() 
        {
            return _computer;
        }

    }
}
