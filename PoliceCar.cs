namespace Practice1
{
    class PoliceCar : MatricVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private string followedPlate;
        private bool isFollowing;
        private PoliceStation policeStation;

        public PoliceCar(string plate, PoliceStation policeStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            followedPlate = "";
            isFollowing = false;
            speedRadar = new SpeedRadar();
            this.policeStation = policeStation;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                if (meassurement== "Catched above legal speed.")
                {
                    NotifyPoliceStation(vehicle.GetPlate());
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
        public void StartFollowing(string plate)
        {
            isFollowing = true;
            followedPlate = plate;
        }
        public void StopFollowing()
        {
            isFollowing = false;
        }

        public void NotifyPoliceStation(string plate)
        {
            policeStation.OrderFollowPlate(plate);
        }
    }
}