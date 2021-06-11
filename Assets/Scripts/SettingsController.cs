using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;
    public void CloseSettings()
    {
        StartCoroutine(CloseSettingsIenumerator());
    }
    private IEnumerator CloseSettingsIenumerator()
    {
        yield return new WaitForSeconds(0.25f);
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
}
