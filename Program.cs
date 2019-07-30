using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3LedOnOff
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var pin = 17;
            //var lightTimeInMilliseconds = 1000;
            //var dimTimeInMilliseconds = 200;

            //using (GpioController controller = new GpioController())
            //{
            //    controller.OpenPin(pin, PinMode.Output);
            //    Console.WriteLine($"GPIO pin enabled for use: {pin}");
            //    Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs eventArgs) =>
            //    {
            //        controller.Dispose();
            //    };

            //    while (true)
            //    {
            //        Console.WriteLine($"Light for {lightTimeInMilliseconds}ms");
            //        controller.Write(pin, PinValue.High);
            //        Thread.Sleep(lightTimeInMilliseconds);
            //        Console.WriteLine($"Dim for {dimTimeInMilliseconds}ms");
            //        controller.Write(pin, PinValue.Low);
            //        Thread.Sleep(dimTimeInMilliseconds);
            //    }
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
			        webBuilder.UseUrls("http://*:5001/");
                });
    }
}
