using ComponentCommunication.Shared;

namespace ComponentCommunication.Client.Pages.StateContainerDisplay;

public class StateContainer<T> : IStateContainer<T>
{
    public List<T> Items { get; set; }
    
    public event Action<List<T>>? OnChange;
    
    public void NotifyStateChanged(List<T> items) => OnChange?.Invoke(items);
}