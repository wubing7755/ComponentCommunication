namespace ComponentCommunication.Shared;

public class Player : ObjectBase
{
    public Player(string name, int initialHealth = 100) : base(name)
    {
        Health = initialHealth;
    }

    private string _name;

    public override string Name
    {
        get => _name;
        set
        {
            if (value.Length <= 10)
            {
                _name = value;
            }
            else
            {
                _name = "XXX";
            }
        }
    }
    
    public int Health { get; private set; }
    
    public bool IsAlive => Health > 0;
}