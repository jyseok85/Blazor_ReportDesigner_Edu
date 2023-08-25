public class _06_BaseControlModel
{
    public int TabIndex { get; set; } = 0;
    public string Uid { get; set; } = string.Empty;

    public int Width { get; set; } = 100;

    public int Height { get; set; } = 30;

    public double X { get; set; } = 0;

    public double Y { get; set; } = 0;

    public int Right => (int)X + Width;

    public int Bottom => (int)Y + Height;

    public bool Border { get; set; } = true;

    private bool selected = false;
    public bool Selected
    {
        get { return this.selected; }
        set
        {
            this.selected = value;           
        }
    }

    public bool DragAble { get; set; } = false;
}


