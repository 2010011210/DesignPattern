namespace DesignPattern.Model.SingletonPattern
{
    public class SingletonPerson
    {
        /// <summary>
        /// 构造函数要私有化
        /// </summary>
        private SingletonPerson() { }

        public static  SingletonPerson instance = null;                      // 1.懒汉式，使用的时候才创建
        // private static  SingletonPerson instance = new SingletonPerson();  // 2.饿汉式，项目加载的时候直接创建
        //public static SingletonPerson instanceCreateInStaticConstruction = null;                      

        private static readonly object Sington_Lock = new object();

        static SingletonPerson()  // 静态构造函数，第一次使用静态类的时候会触发构造函数，且只触发一次。
        {
            Console.WriteLine("静态构造函数创建SingletonPerson");
            instance = new SingletonPerson();
        }

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
            // i++其实是分两步执行的。第一步i+1，第二步 i+1的只赋值给i。线程不安全，要么加锁。要用Interlocked类种的Add才行。
            lock (Sington_Lock)   // 单例的属性值改变的时候要考虑线程安全问题。
            {
                _Age++;
            }

            //System.Threading.Interlocked.Add(ref _Age, 1);  //Interlocked
            //System.Threading.Interlocked.Increment(ref _Age);  // 每次增加1个，用这个。

            //int _Age = 1;
            //var excahnge = System.Threading.Interlocked.Exchange(ref _Age, 10);
            //Console.WriteLine($"excahnge1:{excahnge}");
            //var excahnge2 = System.Threading.Interlocked.Exchange(ref _Age, 10);
            //Console.WriteLine($"excahnge2:{excahnge}");
        }

    }
}
