namespace DesignPattern.Model.PrototypePattern
{
    public interface IClone<T> where T: class
    {
        T Clone();
    }
}
