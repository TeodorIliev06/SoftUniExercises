﻿namespace Raiding;

public class Druid : BaseHero
{
    public Druid(string name) : base(name, 80)
    {
    }

    public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
}