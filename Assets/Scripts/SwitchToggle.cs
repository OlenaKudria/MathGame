using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
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
        if(toggle.isOn)
        {
            OnSwitch(true);
        }
    }

    void OnSwitch(bool on)
    {
        uiHandlerRectTransform.DOAnchorPos(on ? handlerPosition * -1 : handlerPosition, .4f).SetEase(Ease.InOutBack);
        backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor, 4f);
        handlerImage.DOColor(on ? handlerActiveColor : handlerDefaultColor, 1f);

        if (on)
        {
            themeImage.sprite = changingThemeImage[1];
            background.sprite = backgroundThemeImage[1];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].color = purple;
                buttonsText[i].color = Color.white;
            }

        }
        else
        {
            themeImage.sprite = changingThemeImage[0];
            background.sprite = backgroundThemeImage[0];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].color = Color.white;
                buttonsText[i].color = Color.black;
            }
        }
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
