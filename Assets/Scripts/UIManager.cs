using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{
    private SoundManager soundManager;
    private CalculatorManager calculatorManager;
    private TractenbergSystemUIManager tractenbergSystemUIManager;
    public RectTransform mainMenu, arithmeticMenu, trachtenbergMenu, chooseDifficultyMenu, tryAgainMessage, title;
    public string selectedLevel;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        calculatorManager = FindObjectOfType<CalculatorManager>();
        tractenbergSystemUIManager = FindObjectOfType<TractenbergSystemUIManager>();
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void ShowTryAgainMessage()
    {
        tryAgainMessage.DOAnchorPos(new Vector2(282, -434), 0.45f);
        tryAgainMessage.DOAnchorPos(new Vector2(-1090, -434), 0.90f).SetDelay(0.90f);
    }
    public void ChooseDifficultyMenu()
    {
        chooseDifficultyMenu.DOAnchorPos(Vector2.zero, 0.45f);
        soundManager.DoSoundOnClick();
    }
    public void CloseChooseDifficultyMenu()
    {
        chooseDifficultyMenu.DOAnchorPos(new Vector2(0, 4195), 0.45f);
        soundManager.DoSoundOnClick();
    }

    public void ArithmeticMenu()
    {
        selectedLevel = EventSystem.current.currentSelectedGameObject.name;
        calculatorManager.ShowTask();
        arithmeticMenu.DOAnchorPos(Vector2.zero, 0.25f);
        mainMenu.DOAnchorPos(new Vector2(-2770, 0), 0.25f);
        CloseChooseDifficultyMenu();
        soundManager.DoSoundOnClick();
    }

    public void CloseArithmeticMenu()
    {
        arithmeticMenu.DOAnchorPos(new Vector2(-2770, 0), 0.25f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
        soundManager.DoSoundOnClick();
    }

    public void TrachtenbergMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(2770, 0), 0.25f);
        trachtenbergMenu.DOAnchorPos(Vector2.zero, 0.25f);
        tractenbergSystemUIManager.TrachtenbergUI();
        soundManager.DoSoundOnClick();
    }

    public void CloseTrachtenbergMenu()
    {
        trachtenbergMenu.DOAnchorPos(new Vector2(2770, 0), 0.25f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
        soundManager.DoSoundOnClick();
    }
}
