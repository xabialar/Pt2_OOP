using System;
namespace Practice1
{
	public class PoliceStation
	{
		private List<PoliceCar> policeCars;
		private bool alert;

		public PoliceStation()
		{
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

		public void AddPoliceCar(PoliceCar police)
		{
			policeCars.Add(police);
		}
		public void OrderFollowPlate(string plate)
		{
			foreach (PoliceCar police in policeCars)
			{
				if (police.IsPatrolling == true)
				{
					police.StartFollowing(plate);
				}
			}
		}

	}
}

