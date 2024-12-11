using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.CascadingParameterDisplay;

public class CP_ParentComponent : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        int sequence = 0;
        
        builder.OpenComponent<CP_ChildComponent>(sequence);
        builder.CloseComponent();
    }
}