namespace MilitaryElite.Interfaces;

public interface ILieutenantGeneral : IPrivate
{
    ICollection<IPrivate> Privates { get; }
    void AddPrivate(IPrivate @private);
}
