namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            PoliceStation policeStation = new PoliceStation("001");
            City city = new City("Madrid", policeStation);

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", policeStation.psController, true);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", policeStation.psController, true);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", policeStation.psController, true);
            PoliceCar policeCar4 = new PoliceCar("0004 CNP", policeStation.psController);

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));
            Console.WriteLine(policeCar4.WriteMessage("Created"));

            city.CrateTaxiLicense(taxi1);
            city.CrateTaxiLicense(taxi2);

            policeStation.AddPoliceCar(policeCar1);
            policeStation.AddPoliceCar(policeCar2);
            policeStation.AddPoliceCar(policeCar3);
            policeStation.AddPoliceCar(policeCar4);



            policeCar4.StartPatrolling();
            policeCar4.JudgeMatricVehicle(taxi1);

            policeCar3.StartPatrolling();

            policeCar1.StartPatrolling();
            policeCar1.JudgeMatricVehicle(taxi1);

            taxi2.StartRide();
            policeCar2.JudgeMatricVehicle(taxi2);
            policeCar2.StartPatrolling();
            policeCar2.JudgeMatricVehicle(taxi2);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.JudgeMatricVehicle(taxi1);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

            city.RemoveTaxiLicense(taxi1);

        }
    }
}

