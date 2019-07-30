using System;
using System.Device.Gpio;

namespace AspNetCore3LedOnOff
{
    public class LedClient : IDisposable
    {
        private const int LedPin = 17;

        private GpioController _controller = new GpioController();
        private bool disposedValue = false;
        private object _locker = new object();

        public LedClient()
        {
            _controller.OpenPin(LedPin, PinMode.Output);
            _controller.Write(LedPin, PinValue.Low);

            IsLedOn = false;
        }

        public bool IsLedOn { get; private set; }

        public void LedOn()
        {
            lock (_locker)
            {
                _controller.Write(LedPin, PinValue.High);

                IsLedOn = true;
            }
        }

        public void LedOff()
        {
            lock (_locker)
            {
                _controller.Write(LedPin, PinValue.Low);

                IsLedOn = false;
            }
        }       
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _controller.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
