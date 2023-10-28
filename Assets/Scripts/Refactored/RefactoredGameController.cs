using System;
using UnityEngine;
using UnityEngine.Events;

public class RefactoredGameController : GameControllerBase
{
    public static RefactoredGameController Instance { get; private set; }

    [SerializeField]
    private RefactoredPlayerController playerController;
    public override PlayerControllerBase PlayerController => playerController;
    public UnityEvent OnGameOver { get; private set; } = new UnityEvent();
    public UnityEvent OnArrowShot { get; private set; } = new UnityEvent();

    protected override void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (CheckGameOver())
        {
            OnGameOver.Invoke();
        }
    }

    private bool CheckGameOver()
    {
        return RemainingArrows <= 0;
    }

    public UnityEvent OnGameOverEvent
    {
        get { return OnGameOver; }
    }

    public UnityEvent OnArrowShotEvent
    {
        get { return OnArrowShot; }
    }
}
