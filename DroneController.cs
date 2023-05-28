using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCC_TasarımO
{

    public class DroneController
    {
        private SensorData sensorData;
        private CommunicationModule communicationModule;
        private DroneMode currentMode;

        public DroneController()
        {
            sensorData = new SensorData();
            communicationModule = new CommunicationModule();
            currentMode = DroneMode.Stable; // İlk mod olarak Stabil modu seçiyoruz
        }

        public void ControlDrone()
        {
            // Klavye girdisini ayrı bir thread'de kontrol et
            Task.Run(() =>
            {
                while (true) // Sonsuz döngü
                {
                    // Klavyeden giriş al
                    ConsoleKey key = Console.ReadKey(true).Key;

                    // Tuşa basılmasına göre mod geçişleri yap
                    switch (key)
                    {
                        case ConsoleKey.S:
                            currentMode = DroneMode.Stable;
                            break;
                        case ConsoleKey.A:
                            currentMode = DroneMode.AutoHome;
                            break;
                        case ConsoleKey.M:
                            currentMode = DroneMode.Manual;
                            break;
                        case ConsoleKey.C:
                            currentMode = DroneMode.Circle;
                            break;
                    }
                }
            });

            // Ana thread sürekli döner
            while (true)
            {
                // Sensör verilerini oku
                sensorData.ReadAccelerometer();
                sensorData.ReadGyroscope();
                sensorData.ReadControllerInput();
                sensorData.ReadCompass();
                sensorData.ReadPressure();
                sensorData.ReadGPS();

                // Sensör verilerini şifrele
                string encryptedData = EncryptData(sensorData);

                // Şifrelenmiş verileri haberleşme modülüne ilet
                communicationModule.SendData(encryptedData);

                // Durum makinesi
                switch (currentMode)
                {
                    case DroneMode.Stable:
                        // Stabil mod algoritmasını uygula
                        Console.WriteLine($"Mod: Stable, Sensor Data: {sensorData.ToString()}");
                        break;
                    case DroneMode.AutoHome:
                        // Otomatik ev modu algoritmasını uygula
                        Console.WriteLine($"Mod: AutoHome, Sensor Data: {sensorData.ToString()}");
                        break;
                    case DroneMode.Manual:
                        // Manuel mod algoritmasını uygula
                        Console.WriteLine($"Mod: Manual, Sensor Data: {sensorData.ToString()}");
                        break;
                    case DroneMode.Circle:
                        // Daire modu algoritmasını uygula
                        Console.WriteLine($"Mod: Circle, Sensor Data: {sensorData.ToString()}");
                        break;
                }
                Thread.Sleep( 100 );
            }
        }

        private string EncryptData(SensorData data)
        {
            // Sensör verilerini şifrele
            // Bu örnekte, basit bir yer tutucu olarak veriye dönüştürülüyor
            return data.ToString();
        }
        public enum DroneMode
        {
            Stable,
            AutoHome,
            Manual,
            Circle
        }

    }


}
