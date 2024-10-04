using System;
namespace Practice1
{
    public class PoliceStation
    {
        private List<PoliceCar> policeCars;
        public PoliceStationController psController;
        private string id;

        public PoliceStation(string id)
        {
            this.id = id;
            policeCars = new List<PoliceCar>();
            psController = new PoliceStationController(policeCars);
        }


        public string GetId()
        {
            return id;
        }
        public override string ToString()
        {
            return $"Police Station with ID {GetId()}";
        }
        public void AddPoliceCar(PoliceCar police)
        {
            Console.WriteLine(WriteMessage($"{police.GetPlate()} joined the Police Station"));
            policeCars.Add(police);
            psController.policeCars.Add(police);
        }

        public string WriteMessage(string message)
        {
            return $"{this} : {message}";
        }

    }
}
