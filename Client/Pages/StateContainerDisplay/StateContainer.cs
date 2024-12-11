using ComponentCommunication.Shared;

namespace ComponentCommunication.Client.Pages.StateContainerDisplay;

public class StateContainer : IStateContainer<Player>
{
    public List<Player> Items { get; set; }
    
    public event Action<List<Player>>? OnChange;
    public void NotifyStateChanged(List<Player> players) => OnChange?.Invoke(players);
}