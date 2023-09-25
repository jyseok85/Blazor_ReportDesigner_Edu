public enum ActionType
{ 
    None,
    Move,
    Resize,
    Create,
    Delete,
    Undo,
    Redo
}

public class _07_Manager
{


    private _07_Manager() { }
    //private static 인스턴스 객체
    private static readonly Lazy<_07_Manager> _instance = new Lazy<_07_Manager>(() => new _07_Manager());
    //public static 의 객체반환 함수
    public static _07_Manager Instance { get { return _instance.Value; } }


    UndoRedoHistory<_07_BaseControlModel> undoRedoHistory = new UndoRedoHistory<_07_BaseControlModel>(10);
    public _07_BaseControlModel? CurrentSelectedModel { get; set; }

    public ActionType CurrentAction { get; set; } = ActionType.None;
    public void SaveState(bool start = false)
    {
        //두가지 단계로 나뉘게 된다.
        //첫번째 메인
        //두번재 서브
        //서브의경우 선택한 컨트롤의 변경사항이 들어간다(이동, 사이즈조절)

        if(CurrentSelectedModel is not null)
        {
            if (start == true )                
            {
                if (undoRedoHistory.IsCanUndo == false)
                {
                    undoRedoHistory.AddState((_07_BaseControlModel)CurrentSelectedModel.Clone());
                    Console.WriteLine($"AddState {CurrentSelectedModel.Uid} {start} {CurrentSelectedModel.X} {CurrentSelectedModel.Y}");
                }
            }
            else
            {
                undoRedoHistory.AddState((_07_BaseControlModel)CurrentSelectedModel.Clone());
                Console.WriteLine($"AddState {CurrentSelectedModel.Uid} {start} {CurrentSelectedModel.X} {CurrentSelectedModel.Y}");
            }

        }
    }

    public void ClearHistory()
    {
        undoRedoHistory.Clear();
    }
    public _07_BaseControlModel Undo()
    {
        if (this.undoRedoHistory.IsCanUndo)
        {
            _07_BaseControlModel model = this.undoRedoHistory.Undo();
            if (model != null)
            {
                return (_07_BaseControlModel)model.Clone();
            }
        }

        return null;
    }
    public _07_BaseControlModel Redo()
    {
        if (this.undoRedoHistory.IsCanRedo)
        {
            _07_BaseControlModel model = this.undoRedoHistory.Redo();

            if (model != null)
            {
                return (_07_BaseControlModel)model.Clone();
            }
        }

        return null;
    }
}
