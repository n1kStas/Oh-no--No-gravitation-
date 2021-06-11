using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickEffect : MonoBehaviour, IPointerDownHandler
{
    public GameManager gameManager;
    public GameObject diminishedButton;

    public bool changeColor;
    
    [SerializeField] private bool _activated;

    [SerializeField] private Vector2 _defaultScale;

    public bool replacementButton;
    public GameObject enabledButton;
    public GameObject disabledButton;
    public Sprite pressDownSprite;
    public Sprite defaultSprite;

    private IEnumerator _restoreTheButtonToItsOriginalStateIEnumerator;

    private void Start()
    {
        _defaultScale = diminishedButton.transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_restoreTheButtonToItsOriginalStateIEnumerator != null)
        {
            StopCoroutine(_restoreTheButtonToItsOriginalStateIEnumerator);
            RestoreTheButtonToItsOriginalState();
        }
        if (diminishedButton.GetComponent<Image>())
        {
            if (pressDownSprite != null)
            {
                diminishedButton.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
                diminishedButton.GetComponent<Image>().sprite = pressDownSprite;
            }
            else
            {
                diminishedButton.transform.localScale = new Vector2(diminishedButton.transform.localScale.x * 0.9f, diminishedButton.transform.localScale.y * 0.9f);
            }
        }
        else
        {
            //diminishedButton.transform.localScale = new Vector2(diminishedButton.transform.localScale.x * 0.9f, diminishedButton.transform.localScale.y * 0.9f);
            //diminishedButton.GetComponent<SpriteRenderer>().color = new Color32(102, 102, 102, 255);
        }
        _restoreTheButtonToItsOriginalStateIEnumerator = RestoreTheButtonToItsOriginalStateIEnumerator();
        StartCoroutine(_restoreTheButtonToItsOriginalStateIEnumerator);
    }

    private IEnumerator RestoreTheButtonToItsOriginalStateIEnumerator()
    {
        yield return new WaitForSeconds(0.15f);
        RestoreTheButtonToItsOriginalState();
        if (changeColor)
        {
            ChangeButtonColor();
        }
        ReplacementButton();
    }

    public void RestoreTheButtonToItsOriginalState()
    {

        if (diminishedButton.GetComponent<Image>())
        {
            if (defaultSprite != null)
            {
                diminishedButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                diminishedButton.GetComponent<Image>().sprite = defaultSprite;
            }
            else
            {
                diminishedButton.transform.localScale = _defaultScale;
            }
        }
        else
        {
            //diminishedButton.transform.localScale = _defaultScale;
            //diminishedButton.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void ChangeButtonColor()
    {
        if (_activated)
        {
            DeactivationEffect();
        }
        else
        {
            ActivationEffect();
        }
    }

    public void ReplacementButton()
    {
        if (replacementButton)
        {
            enabledButton.SetActive(true);
            disabledButton.SetActive(false);
        }
    }

    private void ActivationEffect()
    {
        _activated = true;
        GetComponent<Image>().sprite = pressDownSprite;
        diminishedButton.GetComponent<Image>().color = new Color32(102, 102, 102, 255);
    }

    public void DeactivationEffect()
    {
        _activated = false;
        GetComponent<Image>().sprite = defaultSprite;
        diminishedButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
}
