public delegate void TemperatureAlert(double temp);

class TemperatureMonitor
{
    

    private double currentTemperature;
    public double CurrentTemperature {
        get {return currentTemperature;}
        set {
            if (value < -10 || value > 60) throw new Exception();
            currentTemperature = value;
        }
    }

    public event TemperatureAlert FeverDetected;

    public void Increase(double param)
    {
        CurrentTemperature += param;
        if(currentTemperature > 37.0)
        {
            FeverDetected?.Invoke(CurrentTemperature);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureMonitor tm = new TemperatureMonitor();
        TemperatureAlert alert = (temp) => {Console.WriteLine("tul sok" + temp);};
        tm.FeverDetected += alert;
        tm.CurrentTemperature = 36.5;
        tm.Increase(1.0);
    }
}