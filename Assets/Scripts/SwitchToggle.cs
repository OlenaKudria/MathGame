using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SwitchToggle : MonoBehaviour
{
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
    public Image background;
    public Image[] buttons;
    public TextMeshProUGUI[] buttonsText;
    [Header("Sprites of themes")]
    public Sprite[] backgroundThemeImage;

    Color purple = new Color(78 / 255f, 64 / 255f, 89 / 255f);
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlerPosition = uiHandlerRectTransform.anchoredPosition;
        backgroundDefaultColor = backgroundImage.color;
        handlerDefaultColor = handlerImage.color;
        toggle.onValueChanged.AddListener(OnSwitch);

        bool stateOfTheme = Convert.ToBoolean(PlayerPrefs.GetInt("Theme"));
        toggle.isOn = stateOfTheme;
        OnSwitch(stateOfTheme);

    }

    void ChangeThemeImage(int value)
    {
        themeImage.sprite = changingThemeImage[value];
    }

    void ChangeBackgroundTheme(int value)
    {
        background.sprite = backgroundThemeImage[value];
    }

    void OnSwitch(bool onBool)
    {
        uiHandlerRectTransform.DOAnchorPos(onBool ? handlerPosition * -1 : handlerPosition, .4f).SetEase(Ease.InOutBack);
        backgroundImage.DOColor(onBool ? backgroundActiveColor : backgroundDefaultColor, 4f);
        handlerImage.DOColor(onBool ? handlerActiveColor : handlerDefaultColor, 1f);

        if (onBool)
        {

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].color = purple;
                buttonsText[i].color = Color.white;
            }

        }
        else
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].color = Color.white;
                buttonsText[i].color = Color.black;
            }
        }

        int onInt = Convert.ToInt32(onBool);
        ChangeThemeImage(onInt);
        ChangeBackgroundTheme(onInt);
        PlayerPrefs.SetInt("Theme", onInt);
    }

}
