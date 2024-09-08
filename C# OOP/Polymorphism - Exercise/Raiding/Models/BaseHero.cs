namespace Raiding;

public abstract class BaseHero
{
    private string name;
    private int power;

    protected BaseHero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name
    {
        get => name;
        protected set => name = value;
    }

    public int Power
    {
        get => power;
        protected set => power = value;
    }

    public abstract string CastAbility();
}
