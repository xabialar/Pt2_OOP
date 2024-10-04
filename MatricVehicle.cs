using System;
namespace Practice1
{
    public abstract class MatricVehicle : Vehicle
    {
        private string plate;
        public MatricVehicle(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
        }

        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }
        public string GetPlate()
        {
            return plate;
        }
    }
}