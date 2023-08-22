using Microsoft.AspNetCore.Components.Web;

public class _05_ResizeControlModel
{
    public int Width { get; set; } = 100;

    public int Height { get; set; } = 30;

    public int X { get; set; } = -1;

    public int Y { get; set; } = -1;

    public bool Hidden { get; set; } = true;

    public bool IsChanged { get; set; } = false;

    private bool grapedResizeControl = false;
    public bool GrapedResizeControl { get { return this.grapedResizeControl; } set { this.grapedResizeControl = value; } }
    private string grabedControlPostion = string.Empty;

    int beforeX = 0;
    int beforeY = 0;
    int beforeRight = 0;
    int beforeBottom = 0;

    int beforeWidth = 0;
    int beforeHeight = 0;
    public void ActiveResizeComponent(int width, int height)
    {
        Hidden = false;
        X = 0;
        Y = 0;
        Width = (int)width;
        Height = (int)height;
        IsChanged = false;
    }

    public void ActionStart(PointerEventArgs e, string type)
    {
        ActionStart(e.ClientX, e.ClientY, type);
    }
    public void ActionStart(double clientX, double clientY, string type)
    {
        Hidden = false;
        beforeX = (int)clientX;
        beforeY = (int)clientY;

        beforeRight = (int)clientX + Width;
        beforeBottom = (int)clientY + Height;
        beforeWidth = Width;
        beforeHeight = Height;

        grapedResizeControl = true;
        grabedControlPostion = type;

        //Console.WriteLine($"Resize ActionStart {beforeY},{beforeBottom}");

    }
    public void ActionMove(PointerEventArgs e)
    {
        ActionMove(e.ClientX, e.ClientY);
    }
    public void ActionMove(double clientX, double clinetY)
    {
        if (Hidden)
            return;

        if (grapedResizeControl == false)
            return;

        int moveDitanceX = (int)clientX - beforeX;
        int moveDitanceY = (int)clinetY - beforeY;

        foreach (char c in this.grabedControlPostion)
        {
            switch (c)
            {
                case 'w': MoveLeftControl(); break;
                case 'e': MoveRightControl(); break;
                case 's': MoveBottomControl(); break;
                case 'n': MoveTopControl(); break;
            }
        }

        IsChanged = true;
        void MoveLeftControl()
        {
            Console.WriteLine($"MoveTopControl {beforeX},{moveDitanceX},{beforeRight}");
            //좌측 조절일때는 우측 영역을 벗어날수 없다. 
            if (beforeX + moveDitanceX >= beforeRight)
            {

                X = beforeRight - beforeX - 1;
                Width = 0;

                //X = moveDitanceX;

                //Width = beforeRight - (beforeX + moveDitanceX);
            }
            else
            { 
                X = moveDitanceX;
                Width = beforeWidth - X;
            }
        }
        void MoveTopControl()
        {
            //Console.WriteLine($"MoveTopControl {beforeY},{moveDitanceY},{beforeBottom}");
            if (beforeY + moveDitanceY >= beforeBottom)
            {
                Y = beforeBottom - beforeY - 1;
                Height = 0;
            }
            else
            {
                Y = moveDitanceY;
                Height = beforeHeight - Y;
            }
        }
        void MoveRightControl()
        {
            if (moveDitanceX + beforeWidth < X)
                Width = 0;
            else
                Width = beforeWidth + moveDitanceX;
        }
        void MoveBottomControl()
        {
            if (moveDitanceY + beforeHeight < Y)
                Height = 0;
            else
                Height = beforeHeight + moveDitanceY;
        }

    }

    public void ActionEnd()
    {
        grapedResizeControl = false;
        IsChanged = false;
        X = 0;
        Y = 0;
    }
}
