public class _03_DragAndDropService
{
    public string Uid { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public void StartDrag(string Uid, int posX, int posY)
    {
        this.Uid = Uid;
        this.PosX = posX;
        this.PosY = posY;
    }
}

