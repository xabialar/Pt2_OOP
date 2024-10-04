namespace Practice1
{
    class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(MatricVehicle vehicle)
        {
            plate = vehicle.GetPlate();
            speed = vehicle.GetSpeed();
            SpeedHistory.Add(speed);
        }

        public bool GetLastReading()
        {
            bool above_speed;
            if (speed > legalSpeed)
            {
                above_speed = true;
            }
            else
            {
                above_speed = false;
            }
            return above_speed;
        }

        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}