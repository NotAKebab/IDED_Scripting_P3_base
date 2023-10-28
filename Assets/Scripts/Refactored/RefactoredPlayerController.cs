using UnityEngine;

public class RefactoredPlayerController : PlayerControllerBase
{
    public RefactoredGameController gameController;
    public interface ICommand
    {
        void Execute();
    }

    protected override void Start()
    {
        ArrowCount = RefactoredGameController.Instance.Arrows;
        base.Start();
    }
    public static RefactoredPlayerController Instance { get; private set; }
    

    protected virtual void Awake()
    {
        Instance = this;
    }

    protected override void ProcessShot(Vector3 point)
    {
        ICommand command = new ShotCommand(point);
        command.Execute();
    }
}
public class ShotCommand : RefactoredPlayerController.ICommand
{
    private Vector3 aimPoint;

    public ShotCommand(Vector3 aimPoint)
    {
        this.aimPoint = aimPoint;
    }

    public void Execute()
    {
        RefactoredGameController.Instance.ProcessShot(aimPoint);
        RefactoredGameController.Instance.OnArrowShot.Invoke();
    }
}
