namespace ComponentCommunication.Client.Pages.PublishSubscribDisplay;

public class NotifyService : INotifyService
{
    public event Action<string>? OnClickCallback;

    public void OnClick(string msg)
    {
        OnClickCallback?.Invoke(msg);
    }
}