using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerUpHandler
{
    public enum Paragraph
    {
        none,
        maps,
        settings,
        shop
    }

    public Paragraph paragraph;

    public GameObject maps;
    public GameObject mainMenu;
    public MapController mapController;

    public GameObject settings;


    public void OnPointerUp(PointerEventData eventData)
    {
        switch (paragraph)
        {
            case Paragraph.maps:
                StartCoroutine(OpenMapsGame());
                break;

            case Paragraph.settings:
                StartCoroutine(OpenSettings());
                break;
        }
    }

    IEnumerator OpenMapsGame()
    {
        yield return new WaitForSeconds(0.25f);
        maps.SetActive(true);
        mapController.ShowOpenLevels();
        mainMenu.SetActive(false);
    }

    private IEnumerator OpenSettings()
    {
        yield return new WaitForSeconds(0.25f);
        settings.SetActive(true);
        mainMenu.SetActive(false);
    }
}
