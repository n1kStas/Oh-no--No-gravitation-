using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelsMap : MonoBehaviour
{
    public GameObject star_1;
    public GameObject star_2;
    public GameObject star_3;

    public void OpenLevel(bool[] achivment)
    {
        if (achivment[0])
        {
            star_1.SetActive(true);
        }
        if (achivment[1])
        {
            star_2.SetActive(true);
        }
        if (achivment[2])
        {
            star_3.SetActive(true);
        }
    }


}
