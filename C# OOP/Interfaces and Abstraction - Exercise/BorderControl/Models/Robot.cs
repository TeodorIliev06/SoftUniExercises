namespace BorderControl.Models;

public class Robot : BaseEntity
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
    public string Model { get; set; }
}
