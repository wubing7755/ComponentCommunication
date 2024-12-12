using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.StateContainerDisplay;

public class Component_A : ComponentBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Classes that act as code-behind classes for Razor components -
    /// those that derive from ComponentBase or that implement IComponent -
    /// do not support constructor injection. 
    /// </remarks>>
    [Inject]
    public IStateContainer<Player> _stateContainer { get; set; } = null!;
    
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
                
                _stateContainer.NotifyStateChanged(_players.Items);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            StateHasChanged();
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenElement(sequence ++, "h4");
        builder.AddContent(sequence ++, "Component_A");
        builder.CloseElement();
        
        builder.OpenElement(sequence ++, "label");
        builder.AddContent(sequence ++, "Please input the count of players:");
        builder.CloseElement();
        
        builder.OpenElement(sequence ++, "input");
        builder.AddAttribute(sequence ++, "type", "number");
        builder.AddAttribute(sequence ++, "value", PlayerNumber);
        builder.AddAttribute(sequence ++, "onchange", NumChanged);
        builder.AddAttribute(sequence, "placeholder", "Player's count must be lower than 10");
        builder.CloseElement();
    }
}