using Microsoft.AspNetCore.Components.Web;
using System;

public class _05_CreateControlModel
{
    public int Width { get; set; } = 100;

    public int Height { get; set; } = 30;

    public int X { get; set; } = -1;

    public int Y { get; set; } = -1;

    public bool Hidden { get; set; } = true;

    private int diffX;
    private int diffY;

    public int ClientX { get; set; }
    public int ClientY { get; set; }
    public void ActionStart(PointerEventArgs e)
    {
        ActionStart(e.OffsetX, e.OffsetY, e.ClientX, e.ClientY);
    }

    public void ActionStart( double offsetX, double offsetY, double clientX, double clientY)
    {
        Hidden = false;
        X = (int)offsetX;
        Y = (int)offsetY;
        Width = 0;
        Height = 0;

        ClientX = (int)clientX;
        ClientY = (int)clientY;

        diffX = (int)clientX - X;
        diffY = (int)clientY - Y;
    }  
    public void ActionMove(PointerEventArgs e)
    {
        ActionMove(e.ClientX, e.ClientY);
    }
    public void ActionMove(double clientX, double clinetY) 
    {
        //계산을 offset 이 아닌 client로 하는 이유는
        //offset 계산할경우 마우스를 역방향으로 이동해서 현재 생성하는 컨트롤 안으로 이동할때 offset 이 달라지기 때문에
        //전체 페이지에대한 client 좌표를 사용해서 계산한다. 
        if (Hidden)
            return;

        double x = clientX - diffX;
        double y = clinetY - diffY;  

        Width = (int)(x - X);
        Height = (int)(y - Y);
        Console.WriteLine($"ActionMove {x} {X} {Width},{Height}");
    }

    public void ActionEnd()
    {
        Width = 0;
        Height = 0;
        Hidden = true;
    }
}
