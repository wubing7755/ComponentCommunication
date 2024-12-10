using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace ComponentCommunication.Client.Pages.RectMatchDisplay;

public class RectSet : ComponentBase
{
    public List<RectObject> RectObjects { get; set; } = new();
    
    [Parameter]
    public int RectCount { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;

        builder.OpenElement(sequence, "svg");
        
        for (int i = 0; i < RectCount; i++)
        {
            double rectY = i * 20;
            
            RectObject rectObject = new RectObject(i);
            RectObjects.Add(rectObject);
            
            builder.OpenComponent<Rect>(sequence++);
            builder.AddAttribute(sequence++ , "Color", rectObject.RectColorType);
            builder.AddAttribute(sequence++, "RectY", rectY);
            builder.CloseComponent();
        }
        
        builder.CloseElement();
        
    }
}