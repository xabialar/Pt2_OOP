namespace Practice1
{
    class PoliceCar : MatricVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private PoliceStation policeStation;
        private SpeedRadar? speedRadar;
        private string followedPlate;
        private bool isFollowing;
        private bool hasRadar;
        private bool isPatrolling;
        
        

        public PoliceCar(string plate, PoliceStation policeStation, bool hasRadar=false) : base(typeOfVehicle, plate)
        {
            this.policeStation = policeStation;
            followedPlate = "";
            isPatrolling = false;
            isFollowing = false;
            this.hasRadar = hasRadar;
            if (hasRadar == false)
            {
                speedRadar = null;
            }
            else
            {
                speedRadar = new SpeedRadar();
            }
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (sppedRadar == null)
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
            else
            {
                if (isPatrolling)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (meassurement == "Catched above legal speed.")
                    {
                        NotifyPoliceStation(vehicle.GetPlate());
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage($"has no active radar."));
                }
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
            if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage("has no radar"));
            }
            else
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
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