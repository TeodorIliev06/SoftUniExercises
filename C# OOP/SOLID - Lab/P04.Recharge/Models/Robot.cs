namespace P04.Recharge;

public class Robot : Worker, IRechargeable
{
    private int capacity;
    private int currentPower;

    public Robot(string id, int capacity) : base(id)
    {
        this.capacity = capacity;
    }

    public int Capacity => capacity;

    public int CurrentPower
    {
        get => currentPower;
        set => currentPower = value;
    }

    public void Recharge()
    {
        this.currentPower = this.capacity;
    }

    public void Work(int hours)
    {
        if (hours > currentPower)
        {
            hours = currentPower;
        }

        base.Work(hours);
        currentPower -= hours;
    }
}