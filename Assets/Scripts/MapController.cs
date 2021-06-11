using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameManager GameManager;
    public CameraControl cameraControl;

    public Vector2 maxPositionCamera;
    public Vector2 minPositionCamera;

    public List<ButtonLevelsMap> buttonsLevelsMaps = new List<ButtonLevelsMap>();
    public SaveLoadGame saveLoadGame;

    public GameObject levelMap;
    public GameObject menu;

    private void Awake()
    {
        SetMinAndMaxCameraPosition();
    }

    public void SetMinAndMaxCameraPosition()
    {
        cameraControl.SetMinAndMaxCameraPosition(minPositionCamera, maxPositionCamera);
    }

    public void SelectLevel(GameObject levelPrefab)
    {
        StartCoroutine(SelectLevelIEnumerator(levelPrefab));
    }

    private IEnumerator SelectLevelIEnumerator(GameObject levelPrefab)
    {
        yield return new WaitForSeconds(0.25f);
        GameManager.StartLevel(levelPrefab);
        gameObject.SetActive(false);
    }

    public void ShowOpenLevels()
    {        
        saveLoadGame.LoadGame();
        for(int i = 0; i < buttonsLevelsMaps.Count; i++)
        {
            if(i < saveLoadGame.save.levelsName.Count)
            {
                buttonsLevelsMaps[i].OpenLevel(saveLoadGame.save.levelsAchivments[i]);
            }
        }
    }
    public void CloseMap()
    {
        StartCoroutine(CloseMapIenumerator());
    }
    private IEnumerator CloseMapIenumerator()
    {
        yield return new WaitForSeconds(0.25f);
        menu.SetActive(true);
        levelMap.SetActive(false);
    }

}
