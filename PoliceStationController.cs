using System;
namespace Practice1
{
	public class PoliceStationController
	{
        public List<PoliceCar> policeCars;
        private bool alert;
        public PoliceStationController(List<PoliceCar> policeCars)
		{
			this.policeCars = policeCars;
		}

        public void SetAlert(bool alert)
        {
            this.alert = alert;
        }
        public bool GetAlert()
        {
            return alert;
        }
        public void SetPlate(string plate)
        {
            if (GetAlert())
            {
                OrderFollowPlate(plate);
            }
        }
        private void OrderFollowPlate(string plate)
        {
            foreach (PoliceCar police in policeCars)
            {
                if (police.IsPatrolling())
                {
                    police.StartFollowing(plate);
                }
            }
        }
    }
}

