public class _05_BaseControlModel
{
    public int TabIndex { get; set; } = 0;
    public string Uid { get; set; } = string.Empty;
    
    public int Width { get; set; } = 100;

    public int Height { get; set; } = 30;

    public int X { get; set; } = 0;

    public int Y { get; set; } = 0;

    public int Right => X + Width;

    public int Bottom => Y + Height;

    public bool Border { get; set; } = true;

    private bool selected = false;
    public bool Selected
    {
        get { return this.selected; }
        set
        {
            this.selected = value;
            if (value == true)
            {
                ResizeModel.ActiveResizeComponent(Width, Height);
            }
            else
            {
                ResizeModel.Hidden = true;
                ResizeModel.GrapedResizeControl = false;
            }
        }
    }

    public _05_ResizeControlModel ResizeModel { get; set; } = new _05_ResizeControlModel();

    public void ApplyResize()
    {
        if (ResizeModel.IsChanged)
        {
            this.X += ResizeModel.X;
            this.Y += ResizeModel.Y;

            if (this.X < 0)
            {
                ResizeModel.Width += this.X;
                this.X = 0;
            }
            if (this.Y < 0)
            {
                ResizeModel.Height += this.Y;
                this.Y = 0;
            }
            this.Width = ResizeModel.Width;
            this.Height = ResizeModel.Height;
        }
        ResizeModel.ActionEnd();
    }
}
