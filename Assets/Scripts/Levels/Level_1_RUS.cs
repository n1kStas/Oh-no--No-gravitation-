using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_1_RUS : MonoBehaviour
{
    public GameObject player;

    private int number;
    private GameObject gameWindow;

    private Dialog dialog;
    private Image splashImage;
    private GameObject healthUI;
    private GameObject timerUI;
    private GameObject menuButtonUI;
    private GameObject playButtonUI;
    private GameObject redacorButtonUI;

    private GameObject playerDialogUI;
    private GameObject roboDialogUI;
    private GameObject fonDialogUI;
    private GameObject textDialogUI;
    private GameObject redactorPanelUI;
    private GameObject buttonUpUI;
    private GameObject buttonDownUI;
    private GameObject buttonClearUI;

    private IEnumerator rotateIEnumerator;
    private StorageOfGameObjects storageOfGameObjects;

    private ColorBlock playButtonUIColorBlock;
    private ColorBlock redactorButtonUIColorBlock;
    private ColorBlock buttonUpUIColorBlock;
    private ColorBlock buttonDownUIColorBlock;
    private ColorBlock buttonClearUIColorBlock;

    private Color disableColor;

    private void Awake()
    {
        storageOfGameObjects = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StorageOfGameObjects>();        
        dialog = storageOfGameObjects.dialogUI.GetComponent<Dialog>();
        dialog.nextDialogButton.onClick.AddListener(LearningGame);
        dialog.HideRoboAvatar();
        gameWindow = storageOfGameObjects.gameWindowUI;
        healthUI = storageOfGameObjects.healtUI;
        healthUI.SetActive(false);
        timerUI = storageOfGameObjects.timerUI;
        timerUI.SetActive(false);
        menuButtonUI = storageOfGameObjects.menuButtonUI;
        menuButtonUI.SetActive(false);
        playButtonUI = storageOfGameObjects.playButtonUI;
        playButtonUI.SetActive(false);
        redacorButtonUI = storageOfGameObjects.redactorButtonUI;
        redacorButtonUI.SetActive(false);
        redactorPanelUI = storageOfGameObjects.redactorPanelUI;
        buttonUpUI = storageOfGameObjects.buttonUpUI;
        buttonDownUI = storageOfGameObjects.buttonDownUI;
        buttonClearUI = storageOfGameObjects.buttonClearUI;

        playerDialogUI = storageOfGameObjects.playerDialogUI;
        roboDialogUI = storageOfGameObjects.roboDialogUI;
        fonDialogUI = storageOfGameObjects.fonDialogUI;
        textDialogUI = storageOfGameObjects.textDialogUI;

        playButtonUIColorBlock = playButtonUI.GetComponent<Button>().colors;
        redactorButtonUIColorBlock = redacorButtonUI.GetComponent<Button>().colors;
        buttonUpUIColorBlock = buttonUpUI.GetComponent<Button>().colors;
        buttonDownUIColorBlock = buttonDownUI.GetComponent<Button>().colors;
        buttonClearUIColorBlock = buttonClearUI.GetComponent<Button>().colors;
        disableColor = redactorButtonUIColorBlock.disabledColor;

        rotateIEnumerator = Rotate();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(rotateIEnumerator);
        LearningGame();
        
    }

    public void LearningGame()
    {
        number++;
        if (number == 1)
        {
            StartCoroutine(Occurrence());
        }
        else if (number == 2)
        {
            dialog.ShowRoboAvatar();
            dialog.Speech(Dialog.DialogCharacters.robo, "Слышу, слышу...", 40);
        }
        else if (number == 3)
        {
            dialog.Speech(Dialog.DialogCharacters.player, "Помоги выровняться! Моя система дала сбой...", 40);
        }
        else if (number == 4)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Ох, снова? Ладно, что уж поделаешь. 50 лет не выходить в открытый космос – не шутки…", 34);
        }
        else if (number == 5)
        {
            dialog.Speech(Dialog.DialogCharacters.player, "Я же не виноват, что я 50 лет провёл в криогенном сне! Всё таки это важная миссия в другой системе…", 34);
        }
        else if (number == 6)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Да, от Земли мы довольно далеко. Нам с игроком помочь тебе будет нелегко!", 34);
        }
        else if (number == 7)
        {
            dialog.Speech(Dialog.DialogCharacters.player, "С кем? Ты опять заглючил что ли?", 40);
        }
        else if (number == 8)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Да нет, что ты! Всё отлично! Прилично! Логично!", 34);
        }
        else if (number == 9)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "На самом деле, он не в курсе, что ты с нами. Но зачем его винить – он просто здоровый человек, да…", 34);
        }
        else if (number == 10)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Ой, дорогой мой игрок, я забыл сказать - привет! Я ИЗИ — Исскуственно Запрограмированный Интелект.", 34);
        }
        else if (number == 11)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "И моя цель — помогать этому горе космонавту в его пути", 34);
        }
        else if (number == 12)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Однако, сам я не справлюсь, а потому мне потребуется твоя помощь!", 34);
        }
        else if (number == 13)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Для начала давай я покажу тебе, как создать путь, по которому наш герой полетит..", 34);
        }
        else if (number == 14)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Видишь эту кнопку, которая появилась? С помощью этой кнопки ты сможешь рисовать траекторию пути", 34);

            playerDialogUI.SetActive(false);
            redacorButtonUI.SetActive(true);
            redacorButtonUI.GetComponent<Button>().interactable = false;

            redactorButtonUIColorBlock.disabledColor = redacorButtonUI.GetComponent<Button>().colors.normalColor;
            redacorButtonUI.GetComponent<Button>().colors = redactorButtonUIColorBlock;
        }
        else if (number == 15)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Давай, нажми на неё!", 34);
        }
        else if (number == 16)
        {
            fonDialogUI.SetActive(true);
            textDialogUI.SetActive(true);

            dialog.Speech(Dialog.DialogCharacters.robo, "Итак, вот инструменты, которые позволят тебе рисовать путь.", 34);

            buttonUpUI.GetComponent<Button>().interactable = false;
            buttonDownUI.GetComponent<Button>().interactable = false;
            buttonClearUI.GetComponent<Button>().interactable = false;

            redactorPanelUI.SetActive(true);
        }
        else if (number == 17)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Эта кнопка позволит рисовать путь вверх...", 34);

            buttonUpUIColorBlock.disabledColor = buttonUpUI.GetComponent<Button>().colors.normalColor;
            buttonUpUI.GetComponent<Button>().colors = buttonUpUIColorBlock;
        }
        else if (number == 18)
        {
            buttonUpUIColorBlock.disabledColor = disableColor;
            buttonUpUI.GetComponent<Button>().colors = buttonUpUIColorBlock;

            dialog.Speech(Dialog.DialogCharacters.robo, "Эта кнопка, кто бы подумал, позволит тебе рисовать путь вниз...", 34);

            buttonDownUIColorBlock.disabledColor = buttonDownUI.GetComponent<Button>().colors.normalColor;
            buttonDownUI.GetComponent<Button>().colors = buttonDownUIColorBlock;
        }
        else if (number == 19)
        {
            buttonDownUIColorBlock.disabledColor = disableColor;
            buttonDownUI.GetComponent<Button>().colors = buttonDownUIColorBlock;

            dialog.Speech(Dialog.DialogCharacters.robo, "А эта кнопка позволит тебе удалить всё нарисованное именно там, где тебе требуется. Это волшебная вещь!", 34);

            buttonClearUIColorBlock.disabledColor = buttonClearUI.GetComponent<Button>().colors.normalColor;
            buttonClearUI.GetComponent<Button>().colors = buttonClearUIColorBlock;
        }
        else if (number == 20)
        {
            buttonUpUIColorBlock.disabledColor = buttonUpUI.GetComponent<Button>().colors.normalColor;
            buttonUpUI.GetComponent<Button>().colors = buttonUpUIColorBlock;
            buttonDownUIColorBlock.disabledColor = buttonDownUI.GetComponent<Button>().colors.normalColor;
            buttonDownUI.GetComponent<Button>().colors = buttonDownUIColorBlock;
            buttonClearUIColorBlock.disabledColor = buttonClearUI.GetComponent<Button>().colors.normalColor;
            buttonClearUI.GetComponent<Button>().colors = buttonClearUIColorBlock;
            dialog.Speech(Dialog.DialogCharacters.robo, "Что ж, теперь ты знаешь про эти инструменты. Теперь я покажу тебе — как они работают.", 34);
        }
        else if (number == 21)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Тут будет анимация, когда появится спрайт руки, не логично потом будет заново создавать анимацию", 34);
        }
        else if (number == 22)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Видел? Запомнил? Сможешь повторить? Так или иначе — у тебя будет ещё время попрактиковаться.", 34);
        }
        else if (number == 23)
        {
            redactorPanelUI.SetActive(false);
            redacorButtonUI.SetActive(false);

            playerDialogUI.SetActive(true);

            dialog.Speech(Dialog.DialogCharacters.player, "ИЗИ! ИЗИ! Ты опять сам с собой там говоришь?! Мои системы движения всё ещё не работают", 34);
        }
        else if (number == 24)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Терпение, друг! Сейчас я всё восстановлю…", 34);
        }
        else if (number == 25)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Так на чём мы остановились? Ах да, ты узнал основные инструменты. Он узнал же, да?", 34);

            playerDialogUI.SetActive(false);

            redactorPanelUI.SetActive(true);
            redacorButtonUI.SetActive(true);
        }
        else if (number == 26)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Когда путь тобой проложен, твой следующий ход – нажатие вот на эту кнопку. Она запустит движение нашего героя.", 34);

            playButtonUI.GetComponent<Button>().interactable = false;
            playButtonUIColorBlock.disabledColor = playButtonUI.GetComponent<Button>().colors.normalColor;
            playButtonUI.GetComponent<Button>().colors = playButtonUIColorBlock;

            playButtonUI.SetActive(true);
        }
        else if (number == 27)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Эта же самая кнопка позволит тебе экстренно остановиться, если вдруг тебе это понадобиться", 34);
        }
        else if (number == 28)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Почаще этим пользуйся, ведь за тебя я размышлять не смогу.", 34);
        }
        else if (number == 29)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Что же, пора вернуть нашего горе космонавта на наш борт! Наш транспорт расположен за тем мусором, что сейчас витает в космосе…", 34);
        }
        else if (number == 30)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Жду ракету для анимации", 34);
        }
        else if (number == 31)
        {
            dialog.Speech(Dialog.DialogCharacters.robo, "Хорошо, Мистер «всё сломалось» - приготовься. Сейчас мы тебе поможем, курс проложим!", 34);
        }
        else if (number == 32)
        {
            redactorPanelUI.SetActive(false);
            redacorButtonUI.SetActive(false);

            playerDialogUI.SetActive(true);

            dialog.Speech(Dialog.DialogCharacters.player, "«Не знаю о каких «ВЫ» ты говоришь, но пожалуйста – верни меня на ракету…", 34);
        }
        else
        {
            Skip();
        }
    }

    private IEnumerator Occurrence()
    {
        splashImage = gameWindow.transform.GetChild(3).GetComponentInChildren<Image>();                
        splashImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        do
        {
            splashImage.color = new Color(splashImage.color.r, splashImage.color.g, splashImage.color.b, splashImage.color.a - 0.005f);
            yield return new WaitForFixedUpdate();
        } while (splashImage.color.a >= 0);

        Destroy(splashImage.gameObject); 
        dialog.gameObject.SetActive(true);
        dialog.Speech(Dialog.DialogCharacters.player, "Алло! Алло! ИЗИ... ИЗИ! Ты меня слышишь ?", 40);
    }

    private IEnumerator Rotate()
    {
        player.GetComponent<Animator>().SetBool("Move_2", true);
        while (true)
        {
            player.transform.eulerAngles += new Vector3(0, 0, -1.75f);
            yield return new WaitForFixedUpdate();
        }
    }


    public void Skip()
    {
        StopCoroutine(rotateIEnumerator);
        player.transform.eulerAngles = Vector3.zero;
        player.GetComponent<Animator>().SetBool("Move_2", false);

        if (splashImage != null)
        {
            Destroy(splashImage.gameObject);
        }
        healthUI.SetActive(true);
        timerUI.SetActive(true);
        menuButtonUI.SetActive(true);
        playButtonUI.SetActive(true);
        redacorButtonUI.SetActive(true);
        playerDialogUI.SetActive(true);

        Destroy(dialog.gameObject);

        redacorButtonUI.GetComponent<Button>().interactable = true;
        redactorButtonUIColorBlock.disabledColor = disableColor;
        redacorButtonUI.GetComponent<Button>().colors = redactorButtonUIColorBlock;

        redactorPanelUI.SetActive(false);
        buttonUpUI.GetComponent<Button>().interactable = true;
        buttonDownUI.GetComponent<Button>().interactable = true;
        buttonClearUI.GetComponent<Button>().interactable = true;

        buttonUpUI.GetComponent<Button>().interactable = true;
        buttonUpUIColorBlock.disabledColor = disableColor;
        buttonUpUI.GetComponent<Button>().colors = buttonUpUIColorBlock;

        buttonDownUI.GetComponent<Button>().interactable = true;
        buttonDownUIColorBlock.disabledColor = disableColor;
        buttonDownUI.GetComponent<Button>().colors = buttonDownUIColorBlock;

        buttonClearUI.GetComponent<Button>().interactable = true;
        buttonClearUIColorBlock.disabledColor = disableColor;
        buttonClearUI.GetComponent<Button>().colors = buttonClearUIColorBlock;

        playButtonUI.GetComponent<Button>().interactable = true;
        playButtonUIColorBlock.disabledColor = disableColor;
        playButtonUI.GetComponent<Button>().colors = playButtonUIColorBlock;

        redacorButtonUI.SetActive(true);

        enabled = false;
    }
}
