public class _01_DragAndDropService
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public void StartDrag(int posX, int posY)
    {
        this.PosX = posX;
        this.PosY = posY;
    }
}

