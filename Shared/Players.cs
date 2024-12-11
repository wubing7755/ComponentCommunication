namespace ComponentCommunication.Shared;

public class Players
{
    public List<Player> Items { get; private set; } = new();
    
    public int ItemCount => Items.Count;

    public Players()
    {
    }

    public Players(int count)
    {
        InitializePlayers(count);
    }

    public void InitializePlayers(int count)
    {
        if(count > 10) throw new ArgumentException("Players count must be less than 10");
        
        Items = new List<Player>(count);
        for (int i = 0; i < count; i++)
        {
            Items.Add(new Player("Player_" + i));
        }
    }

    public void AddPlayer(Player player)
    {
        Items.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        if (Items.Contains(player))
        {
            Items.Remove(player);
        }
    }
    
    public void Reset()
    {
        Items.Clear();
    }
}