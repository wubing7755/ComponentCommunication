namespace ComponentCommunication.Shared;

public class Player : ObjectBase
{
    public Player(string name, int initialHealth = 100)
    {
        Name = name;
        Health = initialHealth;
    }

    private string _name;

    public override string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 10)
            {
                _name = value;
            }
            else
            {
                _name = "XXX";
            }
        }
    }
    
    public virtual int Health { get; protected set; }
    
    public virtual bool IsAlive => Health > 0;
}