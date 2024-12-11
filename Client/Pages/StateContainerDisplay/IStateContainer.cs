using ComponentCommunication.Shared;

namespace ComponentCommunication.Client.Pages.StateContainerDisplay;

public interface IStateContainer<T>
{
     List<T> Items { get; set; }
     event Action<List<T>>? OnChange;
     void NotifyStateChanged(List<T> newItems);
}
