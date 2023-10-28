using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    public RefactoredGameController gameController; // Asegúrate de asignar una instancia de RefactoredGameController en el Inspector.

    protected override GameControllerBase GameController => gameController;

    // Añade referencias a los elementos del UI en el Inspector.
    [SerializeField]
    public GameObject gameOverOverlay;

    [SerializeField]
    public Text scoreText;

    [SerializeField]
    public Text arrowCountText;

    #region Unity lifecycle methods

    private void Start()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(false);
        }
    }

    public void OnEnable()
    {
        gameController.OnGameOver.AddListener(ShowGameOverOverlay);
        gameController.OnArrowShot.AddListener(UpdateUI);
    }

    public void OnDisable()
    {
        gameController.OnGameOver.RemoveListener(ShowGameOverOverlay);
        gameController.OnArrowShot.RemoveListener(UpdateUI);
    }

    #endregion

    #region Event handlers

    // Método para mostrar el overlay de Game Over.
    public void ShowGameOverOverlay()
    {
        if (gameOverOverlay != null)
        {
            gameOverOverlay.SetActive(true);
        }
    }

    // Método para actualizar los elementos del UI.
    public void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameController.Score.ToString();
        }

        if (arrowCountText != null)
        {
            arrowCountText.text = "Arrows: " + GameController.RemainingArrows.ToString();
        }
    }

    #endregion
}
