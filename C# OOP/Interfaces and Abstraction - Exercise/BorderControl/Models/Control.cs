namespace BorderControl.Models;

public class Control
{
    private List<BaseEntity> entities;
    public List<BaseEntity> Entities { get => entities; }

    public Control()
    {
        entities = new();
    }

    public void AddEntityCheck(BaseEntity entity)
    {
        entities.Add(entity);
    }

}
