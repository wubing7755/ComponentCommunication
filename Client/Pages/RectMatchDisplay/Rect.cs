using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace ComponentCommunication.Client.Pages.RectMatchDisplay;

public class Rect : ComponentBase, IDisposable
{
    [Parameter] public RectColorType Color { get; set; }
    
    [Parameter] public double RectY { get; set; }
    

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenElement(sequence, "rect");
        builder.AddAttribute(sequence++, "x", "0");
        builder.AddAttribute(sequence++, "y", RectY);
        builder.AddAttribute(sequence++, "rx", "2");
        builder.AddAttribute(sequence++, "width", "100");
        builder.AddAttribute(sequence++, "height", "20");
        builder.AddAttribute(sequence++, "fill", Color.ToString());
        builder.AddAttribute(sequence++, "onclick", OnRectClick);
        builder.AddEventStopPropagationAttribute(sequence, "onclick", true);
        builder.CloseElement();
    }

    public void OnRectClick()
    {
        this.Color = (RectColorType)(((int)this.Color + 1) % 3);
        StateHasChanged();
    }
    
    public void Dispose()
    {
        
    }
}