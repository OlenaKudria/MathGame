using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private SoundManager soundManager;
    public RectTransform mainMenu, arithmeticMenu, trachtenbergMenu, chooseDifficultyMenu;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
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
        soundManager.DoSoundOnClick();
    }

    public void CloseTrachtenbergMenu()
    {
        trachtenbergMenu.DOAnchorPos(new Vector2(2770, 0), 0.25f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
        soundManager.DoSoundOnClick();
    }
}
