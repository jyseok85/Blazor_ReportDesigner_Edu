public class _04_ComponentModel
{
    public string Uid { get; set; } = string.Empty;
    public double Width { get; set; } = 100;

    public double Height { get; set; } = 30;

    public double X { get; set; } = 0;

    public double Y { get; set; } = 0;

    public bool Focused { get; set; } = false;


    public bool Border { get; set; } = true;

    public _04_ResizeModel ResizeModel { get; set; } = new _04_ResizeModel();

    public void ApplyResize()
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

        ResizeModel.ResizeEnd();
    }
}
