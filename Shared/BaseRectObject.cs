namespace ComponentCommunication.Shared;

public abstract class BaseRectObject
{
    public Guid Id { get; protected set; }
    public string Description { get; set; }
    public abstract RectColorType RectColorType { get; set; }

    protected BaseRectObject()
    {
        Id = Guid.NewGuid();
        Description = string.Empty;
    }
}

public enum RectColorType
{
    Red,
    Green,
    Blue
}