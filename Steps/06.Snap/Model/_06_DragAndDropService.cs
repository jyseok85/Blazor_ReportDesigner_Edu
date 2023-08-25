public class _06_DragAndDropService
{

    public int Width { get; set; } = 100;

    public int Height { get; set; } = 30;
    public int Right => (int)X + Width;

    public int Bottom => (int)Y + Height;

    public double X { get; set; } = 0;

    public double Y { get; set; } = 0;

    public bool Hidden { get; set; } = true;

    private double diffX;
    private double diffY;
    public void StartDrag(double objectPosX, double objectPosY, double mouseClientX, double mouseClientY)
    {
        diffX = mouseClientX - objectPosX;
        diffY = mouseClientY - objectPosY;
    }

    public void Move(double mouseClientX, double mouseClientY)
    {
        X = mouseClientX - diffX;
        Y = mouseClientY - diffY;
    }
}
