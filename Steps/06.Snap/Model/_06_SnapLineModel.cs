using Microsoft.AspNetCore.Components;

public class _06_SnapLineModel
{
    public bool LeftHidden { get; set; } = true;
    public bool TopHidden { get; set; } = true;
    public bool RightHidden { get; set; } = true;
    public bool BottomHidden { get; set; } = true;
    public int LeftPos { get; set; }
    public int TopPos { get; set; }
    public int RightPos { get; set; }
    public int BottomPos { get; set; }

    public void HideSnapLine()
    {
        LeftHidden= true;
        TopHidden= true;
        RightHidden= true;
        BottomHidden= true;
    }

    public void ShowSnapLine(string direction, bool isShowSnapLine, int value)
    {
        switch (direction)
        {
            case "left":
                LeftHidden = !isShowSnapLine;
                LeftPos = value;
                break;
            case "top":
                TopHidden = !isShowSnapLine;
                TopPos = value;
                break;
            case "right":
                RightHidden = !isShowSnapLine;
                RightPos = value;
                break;
            case "bottom":
                BottomHidden = !isShowSnapLine;
                BottomPos = value;
                break;
        }
    }
}
