namespace Composite.Models.Contracts;

public interface IGiftOperations
{
    void Add(BaseGift gift);
    void Remove(BaseGift gift);
}
