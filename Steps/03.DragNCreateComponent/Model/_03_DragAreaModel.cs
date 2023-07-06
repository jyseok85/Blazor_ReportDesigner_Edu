
public class _03_DragAreaModel
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Left { get; set; }
    public double Top { get; set; }
    public bool Hidden { get; set; } = true;

    public void DragStart(double x, double y)
    {
        Left = X = x;
        Top = Y = y;
        Width = 0;
        Height = 0;

        //드래그 시작시 드래그영역을 보여지도록 설정.
        Hidden = false;
    }

    public void DragMove(double x, double y)
    {
        if (Hidden)
            return;       

        double width = Math.Max(x - X, X - x);
        double left = Math.Min(X, x);

        double height = Math.Max(y - Y, Y - y);
        double top = Math.Min(Y, y);

        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public void DragEnd()
    {
        Width = 0;
        Height = 0;
        Hidden = true;
    }
}
