namespace DesignPattern.Model.FactoryPattern
{
    public class TeslaFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new TeslaCarModel3(); ;
        }

        public ISUV CreateSUV()
        {
            return new TeslaCarModelY();
        }
    }
}
