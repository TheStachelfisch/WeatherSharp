namespace WeatherSharp
{
    public class TempUtils
    {
        public static double FahrenheitToCelcius(double Fahrenheit) { return (Fahrenheit - 32) * 5/9;}

        public static double KelvinToCelcius(double Kelvin) { return Kelvin - 273.15; }
    }
}