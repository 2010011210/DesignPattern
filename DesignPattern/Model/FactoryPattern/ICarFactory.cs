namespace DesignPattern.Model.FactoryPattern
{
    public interface ICarFactory
    {
        ICar CreateCar();
        ISUV CreateSUV();
    }
}
