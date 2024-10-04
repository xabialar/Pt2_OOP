namespace Practice1
{
    public class PoliceCar : MatricVehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private static string typeOfVehicle = "Police Car";
        private PoliceStationController policeStation;
        private SpeedRadar? speedRadar;
        private string followedPlate;
        private bool isFollowing;
        private bool hasRadar;
        private bool isPatrolling;



        public PoliceCar(string plate, PoliceStationController policeStation, bool hasRadar = false) : base(typeOfVehicle, plate)
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

        private bool UseRadar(MatricVehicle vehicle)
        {
            bool above_speed;

            speedRadar.TriggerRadar(vehicle);
            above_speed = speedRadar.GetLastReading();

            return above_speed;

        }
        public void JudgeMatricVehicle(MatricVehicle vehicle)
        {
            if (speedRadar == null)
            {
                Console.WriteLine(WriteMessage($"tried to use radar, but has no radar."));
            }
            else if (IsPatrolling() == false)
            {
                Console.WriteLine(WriteMessage($"tried to use radar, but is no patrolling, so has no active radar."));
            }
            else
            {
                bool above_speed = UseRadar(vehicle);
                string meassurement;
                if (above_speed)
                {
                    Console.WriteLine(WriteMessage($"Triggered radar to {vehicle.GetPlate()} :Catched driving ilegally"));
                    NotifyPoliceStation(vehicle.GetPlate());
                }
                else
                {
                    Console.WriteLine(WriteMessage($"Triggered radar to {vehicle.GetPlate()} :Driving legally"));
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
                Console.WriteLine(WriteMessage("tried to report radar history, but has no radar"));
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
            Console.WriteLine(WriteMessage($"Following plate {plate}"));
        }
        public void StopFollowing(string plate)
        {
            isFollowing = false;
            followedPlate = "";
            Console.WriteLine(WriteMessage($"Stopped following plate {plate}"));
        }

        private void NotifyPoliceStation(string plate)
        {
            policeStation.SetAlert(true);
            policeStation.SetPlate(plate);
        }
    }
}