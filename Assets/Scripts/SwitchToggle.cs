using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SwitchToggle : MonoBehaviour
{
    private SoundManager soundManager;

    [Header("Toggle info")]
    public Sprite[] changingThemeImage;
    public RectTransform uiHandlerRectTransform;
    public Color backgroundActiveColor;
    public Color handlerActiveColor;
    public Image themeImage;
    public Image backgroundImage, handlerImage;
    Color backgroundDefaultColor, handlerDefaultColor;
    Toggle toggle;
    Vector2 handlerPosition;

    [Header("Changing theme objects")]
    public Image[] backgrounds;
    public Image[] buttons;
    public Image messageBox;
    public Image[] exitButtons;
    public Image[] difficultyLevelButtons;
    public Image[] questionMarks;
    public TextMeshProUGUI[] buttonsText;
    public TextMeshProUGUI[] titlesText;
    public TextMeshProUGUI messageBoxText;
    [Header("Sprites")]
    public Sprite[] backgroundThemeImage;
    public Sprite[] questionMarksSprites;


    Color purple = new Color(78 / 255f, 64 / 255f, 89 / 255f);
    Color lightPurple = new Color(159 / 255f, 138 / 255f, 171 / 255f);
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();

        toggle = GetComponent<Toggle>();
        handlerPosition = uiHandlerRectTransform.anchoredPosition;
        backgroundDefaultColor = backgroundImage.color;
        handlerDefaultColor = handlerImage.color;
        toggle.onValueChanged.AddListener(OnSwitch);

        bool stateOfTheme = Convert.ToBoolean(PlayerPrefs.GetInt("Theme"));
        toggle.isOn = stateOfTheme;
        OnSwitch(stateOfTheme);

    }

    void ChangeImage(int value)
    {
        themeImage.sprite = changingThemeImage[value];
        for (int i = 0; i < questionMarks.Length; i++)
        {
            questionMarks[i].sprite = questionMarksSprites[value];
        }
    }

    void ChangeBackgroundTheme(int value)
    {
        for (int i = 0; i < backgrounds.Length; i++)
            backgrounds[i].sprite = backgroundThemeImage[value];
    }

    void OnSwitch(bool onBool)
    {
        soundManager.DoSoundOnClick();
        uiHandlerRectTransform.DOAnchorPos(onBool ? handlerPosition * -1 : handlerPosition, .4f).SetEase(Ease.InOutBack);
        backgroundImage.DOColor(onBool ? backgroundActiveColor : backgroundDefaultColor, 4f);
        handlerImage.DOColor(onBool ? handlerActiveColor : handlerDefaultColor, 1f);

        if (onBool)
        {
            messageBox.color = purple;
            messageBoxText.color = Color.white;
            for (int i = 0; i < exitButtons.Length; i++)
                exitButtons[i].color = purple;

            for (int i = 0; i < difficultyLevelButtons.Length; i++)
                difficultyLevelButtons[i].color = lightPurple;

            for (int i = 0; i < buttons.Length; i++)
                buttons[i].color = purple;

            for (int i = 0; i < buttonsText.Length; i++)
                buttonsText[i].color = Color.white;

            for (int i = 0; i < titlesText.Length; i++)
                titlesText[i].color = Color.white;

        }
        else
        {
            messageBox.color = Color.white;
            messageBoxText.color = Color.black;
            for (int i = 0; i < exitButtons.Length; i++)
                exitButtons[i].color = Color.white;

            for (int i = 0; i < difficultyLevelButtons.Length; i++)
                difficultyLevelButtons[i].color = Color.white;

            for (int i = 0; i < buttons.Length; i++)
                buttons[i].color = Color.white;

            for (int i = 0; i < buttonsText.Length; i++)
                buttonsText[i].color = Color.black;

            for (int i = 0; i < titlesText.Length; i++)
                titlesText[i].color = Color.black;
        }

        int onInt = Convert.ToInt32(onBool);
        ChangeImage(onInt);
        ChangeBackgroundTheme(onInt);
        PlayerPrefs.SetInt("Theme", onInt);
    }

}
