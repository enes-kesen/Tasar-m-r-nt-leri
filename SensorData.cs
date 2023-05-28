using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCC_TasarımO
{

    internal class SensorData
    {
        private static readonly Random random = new Random();

        public double Accelerometer { get; private set; } // Ivme ölçer verisi
        public double Gyroscope { get; private set; } // Gyro verisi
        public double ControllerInput { get; private set; } // Kumanda girişi
        public double Compass { get; private set; } // Pusula verisi
        public double Pressure { get; private set; } // Basınç verisi
        public double GPS { get; private set; } // GPS verisi

        // Sensör verilerini okumak için metodlar
        public void ReadAccelerometer()
        {
            // Ivme ölçer verisini oku
            Accelerometer = random.NextDouble() * 2 - 1; // -1 ile 1 arasında bir değer
        }

        public void ReadGyroscope()
        {
            // Gyro verisini oku
            Gyroscope = random.NextDouble() * 360; // 0 ile 360 arasında bir değer
        }

        public void ReadControllerInput()
        {
            // Kumanda girişini oku
            ControllerInput = random.NextDouble() * 2 - 1; // -1 ile 1 arasında bir değer
        }

        public void ReadCompass()
        {
            // Pusula verisini oku
            Compass = random.NextDouble() * 360; // 0 ile 360 arasında bir değer
        }

        public void ReadPressure()
        {
            // Basınç verisini oku
            Pressure = random.NextDouble() * 1013.25; // 0 ile 1013.25 arasında bir değer (ortalama deniz seviyesi basınç)
        }

        public void ReadGPS()
        {
            // GPS verisini oku
            GPS = random.NextDouble() * 180 - 90; // -90 ile 90 arasında bir değer (enlem veya boylam)
        }
        public override string ToString()
        {
            return $"Accelerometer: {Accelerometer}, Gyroscope: {Gyroscope}, ControllerInput: {ControllerInput}, Compass: {Compass}, Pressure: {Pressure}, GPS: {GPS}";
        }
    }

}
