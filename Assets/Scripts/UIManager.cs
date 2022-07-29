using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, arithmeticMenu, trachtenbergMenu, chooseDifficultyMenu;
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void ChooseDifficultyMenu()
    {
        chooseDifficultyMenu.DOAnchorPos(Vector2.zero, 0.45f);
    }
    public void CloseChooseDifficultyMenu()
    {
        chooseDifficultyMenu.DOAnchorPos(new Vector2(0, 2480), 0.45f);
    }

    public void ArithmeticMenu()
    {
        arithmeticMenu.DOAnchorPos(Vector2.zero, 0.25f);
        mainMenu.DOAnchorPos(new Vector2(-1394, 0), 0.25f);
        CloseChooseDifficultyMenu();
    }

    public void CloseArithmeticMenu()
    {
        arithmeticMenu.DOAnchorPos(new Vector2(-1394, 0), 0.25f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void TrachtenbergMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(1394, 0), 0.25f);
        trachtenbergMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void CloseTrachtenbergMenu()
    {
        trachtenbergMenu.DOAnchorPos(new Vector2(1394, 0), 0.25f);
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }
}
