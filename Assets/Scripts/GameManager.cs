using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameController GameController;
    public CameraControl CameraControl;
    public DrawAPath DrawAPath;
    public ButtonClickEffect buttonClickEffect;
    public MapController mapController;

    public GameObject playerPrefab;
    public GameObject player;

    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject resultUI;
    public GameObject gameCanvas;
    public GameObject level;
    public GameObject map;

    public Camera mainCamera;

    public void StartLevel(GameObject levelPrefab)
    {
        GameController.timer.ResetTimer();
        gameCanvas.SetActive(true);
        mainCamera.transform.position = new Vector3(0, 0, -10);
        level = Instantiate(levelPrefab);
        player = Instantiate(playerPrefab);
        GameController.heroFly = player.GetComponent<HeroFly>();
        GameController.player = player;
        GameController.health.text = "Здоровье: " + player.GetComponent<Player>().health;
        player.GetComponent<HeroFly>().gameController = GameController;
        CameraControl.SetMinAndMaxCameraPosition(level.GetComponent<LevelData>().minPositionCamera, level.GetComponent<LevelData>().maxPositionCamera);
        DrawAPath.SetTranformPlayer(player.transform);
    } 

    public void ExitLevel()
    {
        StartCoroutine(ExitLevelIEnumerator());
    }

    private IEnumerator ExitLevelIEnumerator()
    {
        yield return new WaitForSeconds(0.25f);
        mainCamera.transform.position = new Vector3(0, 0, -10);
        Destroy(player);
        Destroy(level);
        DrawAPath.ClearDrawPath();
        resultUI.SetActive(false);
        map.SetActive(true);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        GameController.CloseTheControlPanel();
        gameCanvas.SetActive(false);
        mapController.SetMinAndMaxCameraPosition();
        mapController.ShowOpenLevels();
    }

    public void Save(bool[] achivment)
    {
        GetComponent<SaveLoadGame>().SaveGame(level.GetComponent<LevelData>().nameLevel, achivment);
    }
}
