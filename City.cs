using System;
namespace Practice1
{
	public class City: IMessageWritter
	{
        public List<Taxi> taxiList { get; private set; }
        private PoliceStation policeStation;
		private string id;

		public City(string id, PoliceStation policeStation)
		{
			this.id = id;
			this.policeStation = policeStation;
			taxiList = new List<Taxi>();
		}

		public override string ToString()
		{
			return $"City with ID {GetId}";
		}

        public string GetId()
        {
            return id;
        }
		public void CrateTaxiLicense(Taxi taxi)
		{
			taxiList.Add(taxi);
		}
		public void RemoveTaxiLicense(Taxi taxi)
		{
			if (taxiList.Contains(taxi))
			{
				taxiList.Remove(taxi);
            }
		}
		public string WriteMessage(string message)
		{
			return $"{this} : {message}";
		}
    }
}

