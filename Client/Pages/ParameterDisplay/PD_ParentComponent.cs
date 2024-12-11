using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.ParameterDisplay;

public class PD_ParentComponent : ComponentBase
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

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenElement(sequence ++, "h3");
        builder.AddContent(sequence ++, "组件参数");
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
        
        builder.OpenComponent<PD_ChildComponent>(sequence ++);
        builder.AddAttribute(sequence, "Players", _players);
        builder.CloseComponent();
    }
}