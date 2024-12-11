namespace ComponentCommunication.Shared;

public abstract class ObjectBase
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public abstract string Name { get; set; }
}