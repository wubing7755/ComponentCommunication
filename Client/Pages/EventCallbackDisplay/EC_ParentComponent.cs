using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.EventCallbackDisplay;

public class EC_ParentComponent : ComponentBase
{
    private Players _players = new Players();
    private int PlayerNumber { get; set; } = 0;
    
    private void NumChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int number))
        {
            PlayerNumber = number;

            try
            {
                _players = new Players(PlayerNumber);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            StateHasChanged();
        }
    }

    public void DeletePlayer(Player player)
    {
        _players.RemovePlayer(player);
        
        StateHasChanged();
    }
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenElement(sequence ++, "h3");
        builder.AddContent(sequence ++, "事件回调");
        builder.CloseElement();
        
        builder.OpenElement(sequence ++, "label");
        builder.AddContent(sequence ++, "Please input the count of players:");
        builder.CloseElement();
        
        builder.OpenElement(sequence ++, "input");
        builder.AddAttribute(sequence ++, "type", "number");
        builder.AddAttribute(sequence ++, "value", PlayerNumber);
        builder.AddAttribute(sequence ++, "onchange", NumChanged);
        builder.AddAttribute(sequence ++, "placeholder", "Player's count must be lower than 10");
        builder.CloseElement();
        
        builder.OpenComponent<EC_ChildComponent>(sequence ++);
        builder.AddAttribute(sequence ++, "Players", _players);
        builder.AddAttribute(sequence, "DeletePlayerCallback", EventCallback.Factory.Create<Player>(this, DeletePlayer));
        builder.CloseComponent();
    }
}