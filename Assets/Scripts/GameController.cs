using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [HideInInspector] public DrawAPath drawAPath;
    public HeroFly heroFly;
    public CameraControl cameraControl;
    public GameManager gameManager;

    public GameObject controlPanel;
    public List<ButtonClickEffect> buttonClickEffectControl;
    public ButtonClickEffect buttonStopped;
    public GameObject player;
    public Timer timer;
    public Text health;
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject resultUI;
    public ButtonClickEffect pressedDrawingButton;
    public FinishResult finishResult;

    private void Start()
    {
        drawAPath = GetComponent<DrawAPath>();
    }

    private IEnumerator activeEnumerator;

    public void PlayerFlies()
    {
        cameraControl.enabledControl = false;
        CloseTheControlPanel();
        drawAPath.MakeThePathTransparent();
        cameraControl.StartCameraToMovementPlayer(player.transform);
        activeEnumerator = PlayerFliesIEnumerator();
        StartCoroutine(activeEnumerator);
        
    }

    public void PlayerStopped()
    {
        buttonStopped.ReplacementButton();
        cameraControl.StopCameraToMovementPlayer();
        timer.StopTimer();
        cameraControl.enabledControl = true;
        drawAPath.ReturnToStandardImageThePath();        
        heroFly.StopFly();
    }

    public void OpenOrCloseTheControlPanel()
    {
        activeEnumerator = OpenOrCloseTheControlPanelIEnumerator();
        StartCoroutine(activeEnumerator);
    }

    private void ReturnTheStateOfThePressedDrawingButton()
    {
        if (pressedDrawingButton != null)
        {
            pressedDrawingButton.DeactivationEffect();
        }
    }

    public void DrawTheWayUp()
    {
        if (drawAPath.drawingDirection == DrawAPath.DrawingDirection.DrawUp)
        {
            cameraControl.enabledControl = true;
            drawAPath.DoNotDraw();
        }
        else
        {
            ReturnTheStateOfThePressedDrawingButton();
            pressedDrawingButton = buttonClickEffectControl[0];
            cameraControl.enabledControl = false;
            drawAPath.DrawTheWayUp();
        }
    }

    public void DrawTheWayDown()
    {
        if (drawAPath.drawingDirection == DrawAPath.DrawingDirection.DrawDown)
        {
            cameraControl.enabledControl = true;
            drawAPath.DoNotDraw();
        }
        else
        {
            ReturnTheStateOfThePressedDrawingButton();
            pressedDrawingButton = buttonClickEffectControl[1];
            cameraControl.enabledControl = false;
            drawAPath.DrawTheWayDown();
        }
    }

    public void ClearPath()
    {
        if (drawAPath.drawingDirection == DrawAPath.DrawingDirection.ClearPath)
        {
            cameraControl.enabledControl = true;
            drawAPath.DoNotDraw();
        }
        else
        {
            ReturnTheStateOfThePressedDrawingButton();
            pressedDrawingButton = buttonClickEffectControl[2];
            cameraControl.enabledControl = false;
            drawAPath.ClearPath();
        }
    }

    private IEnumerator PlayerFliesIEnumerator()
    {
        yield return WaitForTheButtonAnimationToFinish();
        drawAPath.enabled = true;
        heroFly.Fly(drawAPath);
        timer.StartTimer();
    }

    private IEnumerator WaitForTheButtonAnimationToFinish()
    {
        yield return new WaitForSeconds(0.25f);
    }

    private IEnumerator OpenOrCloseTheControlPanelIEnumerator()
    {
        yield return StartCoroutine(WaitForTheButtonAnimationToFinish());
        if (controlPanel.activeSelf)
        {
            CloseTheControlPanel();
        }
        else
        {
            buttonStopped.ReplacementButton();
            drawAPath.enabled = true;
            controlPanel.SetActive(true);
        }
    }

    public void CloseTheControlPanel()
    {
        foreach (ButtonClickEffect buttonClickEffect in buttonClickEffectControl)
        {
            buttonClickEffect.RestoreTheButtonToItsOriginalState();
            buttonClickEffect.DeactivationEffect();
        }
        ReturnTheStateOfThePressedDrawingButton();
        drawAPath.drawingDirection = DrawAPath.DrawingDirection.NotDraw;
        drawAPath.enabled = false;
        controlPanel.SetActive(false);
    }

    public void PauseGame()
    {
        activeEnumerator = PauseGameIEnumerator();
        StartCoroutine(activeEnumerator);
    }

    private IEnumerator PauseGameIEnumerator()
    {
        buttonStopped.ReplacementButton();
        cameraControl.enabledControl = false;
        PlayerStopped();
        yield return WaitForTheButtonAnimationToFinish();
        gameUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void ReturnPlayGame()
    {
        activeEnumerator = ReturnPlayGameIEnumerator();
        StartCoroutine(activeEnumerator);
    }

    private IEnumerator ReturnPlayGameIEnumerator()
    {
        yield return WaitForTheButtonAnimationToFinish();
        cameraControl.enabledControl = true;
        gameUI.SetActive(true);
        menuUI.SetActive(false);
    }


    public void RestartLevel()
    {
        activeEnumerator = RestartLevelIEnumerator();
        StartCoroutine(activeEnumerator);
    }

    private IEnumerator RestartLevelIEnumerator()
    {
        yield return WaitForTheButtonAnimationToFinish();
        drawAPath.ClearDrawPath();
        timer.ResetTimer();
        Camera.main.transform.position = new Vector3(0, 0, -10);
        player.transform.position = Vector2.zero;
        drawAPath.SetTranformPlayer(player.transform);
        resultUI.SetActive(false);
        gameUI.SetActive(true);
        menuUI.SetActive(false);
    }

    public void ExitLevel()
    {
        activeEnumerator = ExitLevelIEnumerator();
        StartCoroutine(activeEnumerator);
    }

    private IEnumerator ExitLevelIEnumerator()
    {
        yield return WaitForTheButtonAnimationToFinish();
        gameManager.ExitLevel();
    }

    public void EndLevel()
    {
        PlayerStopped();
        drawAPath.ClearDrawPath();
        gameUI.SetActive(false);
        resultUI.SetActive(true);
        bool[] achivment=  finishResult.ShowResult(gameManager.level.GetComponent<LevelData>(), player.GetComponent<Player>());
        gameManager.Save(achivment);
    }
}
