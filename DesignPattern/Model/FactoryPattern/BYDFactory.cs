namespace DesignPattern.Model.FactoryPattern
{
    public class BYDFactory : ICarFactory
    {
        public IVehicle CreateCar(BYDCarTypeEnum bydEnum) 
        {
            switch (bydEnum) 
            {
                case BYDCarTypeEnum.Yuan:
                    return new BYDCarYuan();
                case BYDCarTypeEnum.Song: 
                    return new BYDCarSong();
                default: 
                    return new BYDCarYuan();
            }
        }

        public ICar CreateCar()
        {
            return new BYDCarHan(); ;
        }

        public ISUV CreateSUV()
        {
            return new BYDCarYuan();
        }
    }
}
