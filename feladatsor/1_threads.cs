class Program
{

    static object objectLock = new object();
    static int random = 0;
    static ManualResetEvent mre = new ManualResetEvent(false);

    static void Main(string[] args)
    {
        Thread generator_t = new Thread(GeneratorFun);
        Thread monitor_t = new Thread(MonitorFun);
        generator_t.IsBackground = true;
        monitor_t.IsBackground = true;
        generator_t.Start();
        monitor_t.Start();
        for(int i = 0; i < 8; i++)
        {
            mre.WaitOne();
            Console.WriteLine("Data arrived:" + random);
            mre.Reset();
        }
    }

    static void GeneratorFun()
    {
        while(true){
            lock(objectLock)
            {
                random = Random.Shared.Next(50);
                mre.Set();
            }
            Thread.Sleep(500);
        }
        
    }

    static void MonitorFun()
    {
        while(true)
        {
            Thread.Sleep(Random.Shared.Next(3)*1000);
            lock (objectLock)
            {
                Console.WriteLine("Analyzing value:" + random);
                Thread.Sleep(10);
            }
        }
    }
}