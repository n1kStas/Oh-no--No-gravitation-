using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMainMenu : MonoBehaviour, IPointerDownHandler
{
    private IEnumerator _restoreTheButtonToItsOriginalStateIEnumerator;
    public Image variableImage;
    public Sprite defaultImage;
    public Sprite preesDownImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_restoreTheButtonToItsOriginalStateIEnumerator != null)
        {
            StopCoroutine(_restoreTheButtonToItsOriginalStateIEnumerator);
            RestoreTheButtonToItsOriginalState();
        }
        variableImage.sprite = preesDownImage;
        _restoreTheButtonToItsOriginalStateIEnumerator = RestoreTheButtonToItsOriginalStateIEnumerator();
        StartCoroutine(_restoreTheButtonToItsOriginalStateIEnumerator);
    }

    private IEnumerator RestoreTheButtonToItsOriginalStateIEnumerator()
    {
        yield return new WaitForSeconds(0.15f);
        RestoreTheButtonToItsOriginalState();
    }

    public void RestoreTheButtonToItsOriginalState()
    {
        variableImage.sprite = defaultImage;
    }
}
