using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.RectMatchDisplay;

public class RectMatch : ComponentBase
{
    private int _inputRectCount = 0;
    
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenElement(sequence, "input");
        builder.AddAttribute(sequence, "type", "text");
        builder.AddAttribute(sequence++, "value", _inputRectCount);
        builder.AddAttribute(sequence, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder<int>(this, value =>
        {
            ChangeInputRectCount(value);
            StateHasChanged();
        }, _inputRectCount));
        
        builder.CloseElement();
        
        builder.OpenComponent<RectSet>(sequence++);
        builder.AddAttribute(sequence, "RectCount", _inputRectCount);
        builder.CloseComponent();
        
    }

    private void ChangeInputRectCount(int value)
    {
        _inputRectCount = value;
    }
}