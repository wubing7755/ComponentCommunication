using ComponentCommunication.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentCommunication.Client.Pages.CascadingParameterDisplay;

public class CP_ChildComponent : ComponentBase
{
    [CascadingParameter(Name = "Players")]
    public Players Players { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        if (Players.ItemCount > 0)
        {
            int sequence = 0;
            builder.OpenElement(sequence ++, "table");
            builder.OpenElement(sequence ++, "tr");
            builder.OpenElement(sequence ++, "th");
            builder.AddAttribute(sequence ++, "scope", "col");
            builder.AddContent(sequence ++, "Name");
            builder.CloseElement();
            builder.OpenElement(sequence ++, "th");
            builder.AddAttribute(sequence ++, "scope", "col");
            builder.AddContent(sequence ++, "Health");
            builder.CloseElement();
            builder.OpenElement(sequence ++, "th");
            builder.AddAttribute(sequence ++, "scope", "col");
            builder.AddContent(sequence ++, "IsAlive");
            builder.CloseElement();
            builder.CloseElement();

            foreach (var player in Players.Items)
            {
                builder.OpenElement(sequence ++, "tr");
                builder.OpenElement(sequence ++, "th");
                builder.AddAttribute(sequence ++, "scope", "row");
                builder.AddContent(sequence ++, player.Name);
                builder.CloseElement();
                builder.OpenElement(sequence ++, "td");
                builder.AddContent(sequence ++, player.Health);
                builder.CloseElement();
                builder.OpenElement(sequence ++, "td");
                builder.AddContent(sequence ++, player.IsAlive);
                builder.CloseElement();
                builder.CloseElement();
            }
            
            builder.CloseElement();
        }
    }
}