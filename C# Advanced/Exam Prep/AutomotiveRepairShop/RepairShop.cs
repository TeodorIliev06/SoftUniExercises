using System.Text;

namespace AutomotiveRepairShop;

public class RepairShop
{
    public RepairShop(int capacity)
    {
        Capacity = capacity;
        Vehicles = new();
    }

    public int Capacity { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public void AddVehicle(Vehicle vehicle)
    {
        if(Capacity > Vehicles.Count)
        {
            Vehicles.Add(vehicle);
        }
    }
    public bool RemoveVehicle(string vin)
    {
        Vehicle vehicleToRemove = Vehicles.FirstOrDefault(v => v.VIN == vin);
        return Vehicles.Remove(vehicleToRemove);
    }
    public int GetCount()
    {
        return Vehicles.Count;
    }
    public Vehicle GetLowestMileage()
    {
        return Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
    }
    public string Report()
    {
        StringBuilder sb = new();
        sb.AppendLine("Vehicles in the preparatory:");
        foreach (var vehicle in Vehicles)
        {
            sb.AppendLine(vehicle.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
