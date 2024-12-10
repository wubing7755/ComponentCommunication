namespace ComponentCommunication.Shared;

public class RectObject : BaseRectObject, IRectUpdate
{
    public override RectColorType RectColorType { get; set; }
    
    public void ChangeColorType()
    {
        int rectColorTypeValue = (int)RectColorType;

        rectColorTypeValue = (rectColorTypeValue + 1) % 3;
        
        this.RectColorType = (RectColorType)rectColorTypeValue;
    }

    public RectObject(int rectColor)
    {
        this.RectColorType = (RectColorType)(rectColor % 3);
    }
}