
//Mainly just data that will be given to hitboxes
public struct BoxRectStruct
{
    public float OffsetX { get; }
    public float OffsetY { get; }
    public float OffsetScaleX { get; }
    public float OffsetScaleY { get; }
    public BoxRectStruct(int offsetX,float offsetY,float offsetScaleX,float offsetScaleY)
    {
        OffsetX = offsetX;
        OffsetY = offsetY;
        OffsetScaleX = offsetScaleX;
        OffsetScaleY = offsetScaleY;

    }
}
