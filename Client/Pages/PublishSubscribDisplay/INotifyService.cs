namespace ComponentCommunication.Client.Pages.PublishSubscribDisplay;

public interface INotifyService
{
     event Action<string>? OnClickCallback;
     void OnClick(string msg);
}