public class _04_ResizeModel
{
    public double Width { get; set; } = 100;

    public double Height { get; set; } = 30;

    public double X { get; set; } = -1;

    public double Y { get; set; } = -1;

    public bool Hidden { get; set; } = true;

    public bool GrapedResizeControl { get; set; } = false;

    double dragStartX = 0;
    double dragStartY = 0;

    string grabedControlPostion = string.Empty;

    public bool IsChanged { get; set; } = false;

    public void SetComponent(double x, double y, double width, double height)
    {
        Hidden = false;
        X = x;
        Y = y; 
        Width = width;
        Height = height;
        IsChanged = false;
    }
     
    double beforeX = 0;
    double beforeY = 0;
    double beforeRight = 0;
    double beforeBottom = 0;

    double beforeWidth = 0;
    double beforeHeight = 0;
    public void DragStart(double x, double y, string type)
    {
        dragStartX = x;
        dragStartY = y;
        beforeRight = X + Width;
        beforeBottom = Y + Height;
        beforeWidth = Width;
        beforeHeight = Height;
        beforeX = X;
        GrapedResizeControl = true;
        grabedControlPostion = type;        
    }

    public void DragMove(double dragCurrentX, double dragCurrentY)
    {
        if (Hidden)
            return;

        if (GrapedResizeControl == false)
            return;

        double moveDitanceX = dragCurrentX - dragStartX;
        double moveDitanceY = dragCurrentY - dragStartY;

        foreach(char c in this.grabedControlPostion)
        {
            switch (c)
            {
                case 'w': MoveLeft(); break;
                case 'e': MoveRight(); break;
                case 's': MoveBottom(); break;
                case 'n': MoveTop(); break;
            }
        }

        IsChanged = true;
        void MoveLeft()
        {
            //좌측 조절일때는 우측 영역을 벗어날수 없다. 
            if (beforeX + moveDitanceX >= beforeRight - 2)
                X = beforeRight - 2;
            else
                X = beforeX + moveDitanceX;

            Width = beforeRight - X;
        }
        void MoveTop()
        {
            if (beforeY + moveDitanceY >= beforeBottom - 2)
                Y = beforeBottom - 2;
            else
                Y = beforeY + moveDitanceY;

            Height = beforeBottom - Y;
        }
        void MoveRight()
        {
            if (moveDitanceX + beforeWidth < X)
                Width = 0;
            else
                Width = beforeWidth + moveDitanceX;
        }
        void MoveBottom()
        {
            if (moveDitanceY + beforeHeight < Y)
                Height = 0;
            else
                Height = beforeHeight + moveDitanceY;
        }
    }

    public void DragEnd()
    {
        GrapedResizeControl = false;
    }

    /// <summary>
    /// 사이즈 조정이 완료되면 호출한다.
    /// </summary>
    public void ResizeEnd()
    {
        IsChanged = false;
        X = 0;
        Y = 0;
    }
}
