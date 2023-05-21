namespace DesignPattern.Model.SingletonPattern
{
    public class SingletonPerson
    {
        /// <summary>
        /// 构造函数要私有化
        /// </summary>
        private SingletonPerson() { }

        private static  SingletonPerson instance = null;                      // 懒汉式，使用的时候才创建
        // private static  SingletonPerson instance = new SingletonPerson();  // 饿汉式，项目加载的时候直接创建
        private static readonly object Sington_Lock = new object();
        public static SingletonPerson GetInstance() 
        {
            if (instance == null)   // 提高性能，不为null，就直接返回。就不用再锁,去创建对象了。
            {
                lock (Sington_Lock) 
                {
                    if (instance == null) 
                    {
                        Console.WriteLine("创建SingletonPerson");
                        instance = new SingletonPerson();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// 下面这个写法更优雅 
        /// </summary>
        /// <returns></returns>
        public static SingletonPerson GetInstanceBetter()
        {
            if (instance != null)   // 提高性能，不为null，就直接返回。就不用再锁,去创建对象了。
            {
                return instance;
            }

            lock (Sington_Lock)
            {
                if (instance == null)
                {
                    instance = new SingletonPerson();
                }
            }

            return instance;
        }

        private int _Age;
        public int Age 
        {   get
            {
                return _Age;
            }
        }

        public void GrowOneYear() 
        {
            lock (Sington_Lock)   // 单例的属性值改变的时候要考虑线程安全问题。
            {
                _Age ++;
            }
        }

    }
}
