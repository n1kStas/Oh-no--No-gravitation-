using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public enum DialogCharacters
    {
        player,
        robo
    }

    public Animator playerAnimator;
    public Animator roboAnimator;

    public Image playerImage;
    public Image roboImage;

    public RectTransform fonDialogRectTransform;
    public Text dialogText;

    public Color playerColorDialog;
    public Color roboColorDialog;

    public Button nextDialogButton;

    private GameObject gameWindow;
    private RectTransform rectTransform;

    private void Awake()
    {
        gameWindow = GameObject.FindGameObjectWithTag("GameWindow");
        transform.parent = gameWindow.transform.parent;
        rectTransform = GetComponent<RectTransform>();        
        rectTransform.localScale = Vector3.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

    }

    public void Speech(DialogCharacters dialogCharacter, string phrase, int fontSize)
    {
        switch (dialogCharacter)
        {
            case DialogCharacters.player:
                fonDialogRectTransform.localScale = new Vector3(1, 1, 1);
                dialogText.color = playerColorDialog;
                dialogText.text = phrase;
                roboAnimator.SetBool("Dialog", false);
                playerAnimator.SetBool("Dialog", true);

                playerImage.color = new Color(255, 255, 255);
                roboImage.color = Color.grey;
                break;

            case DialogCharacters.robo:
                fonDialogRectTransform.localScale = new Vector3(-1, 1, 1);
                dialogText.color = roboColorDialog;
                dialogText.text = phrase;
                playerAnimator.SetBool("Dialog", false);
                roboAnimator.SetBool("Dialog", true);

                playerImage.color = Color.grey;
                roboImage.color = new Color(255, 255, 255);
                break;
        }

        dialogText.fontSize = fontSize;
    }

    public void HideRoboAvatar()
    {
        roboImage.gameObject.SetActive(false);
    }

    public void ShowRoboAvatar()
    {
        roboImage.gameObject.SetActive(true);
    }
    
}
