using System;
namespace Practice1
{
	public class PoliceStation
	{
		private List<PoliceCar> policeCars;
		private bool alert;
		private string id;

		public PoliceStation(string id)
		{
			this.id = id;
			alert = false;
			policeCars = new List<PoliceCar>();
		}

		public void SetAlert(bool alert)
		{
			this.alert = alert;
		}
		public bool GetAlert()
		{
			return alert;
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
            Console.WriteLine(WriteMessage($"{police.GetPlate()}"));
            policeCars.Add(police);
		}
		public void OrderFollowPlate(string plate)
		{
            Console.WriteLine(WriteMessage($"The following police cars, which were patrolling, follow the plate: {plate}:"));

            foreach (PoliceCar police in policeCars)
			{
				if (police.IsPatrolling())
				{
					Console.WriteLine($"{police.GetPlate()}");
					police.StartFollowing(plate);
				}
			}
		}
        public string WriteMessage(string message)
        {
            return $"{this} : {message}";
        }

    }
}

