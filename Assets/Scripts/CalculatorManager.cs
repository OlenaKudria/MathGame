using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalculatorManager : MonoBehaviour
{
    public TextMeshProUGUI inputFieldUGUI;
    public TextMeshProUGUI taskField;
    private SoundManager soundManager;
    private UIManager uiManager;

    private string inputStringField;
    private string pressedButtonValue;
    private int resultOfRandom;
    private string resultOfTask;
    private int valueOne = 1;
    private int valueTwo = 1;
    private int randomSign;

    public void DoRandomRange()
    {
        switch (uiManager.selectedLevel)
        {
            case "Mix":
                valueOne = Random.Range(1, 1001);
                valueTwo = Random.Range(1, 1001);
                break;

            case "Level1<100Button":
                valueOne = Random.Range(1, 101);
                valueTwo = Random.Range(1, 101);
                break;

            case "Level100<500Button":
                valueOne = Random.Range(100, 501);
                valueTwo = Random.Range(100, 501);
                break;

            case "Level500<1000Button":
                valueOne = Random.Range(500, 1001);
                valueTwo = Random.Range(500, 1001);
                break;
        }
    }

    public void DecideOnSign()
    {
        randomSign = Random.Range(1, 5);
        switch (randomSign)
        {
            case 1:
                if (valueOne > valueTwo)
                {
                    valueOne = valueTwo * Random.Range(1, 10);
                    resultOfRandom = valueOne / valueTwo;
                    resultOfTask = $"{valueOne} / {valueTwo}";
                }
                else
                {
                    valueTwo = valueOne * Random.Range(1, 10);
                    resultOfRandom = valueTwo / valueOne;
                    resultOfTask = $"{valueTwo} / {valueOne}";
                }
                break;

            case 2:
                if (valueOne > valueTwo)
                {
                    resultOfRandom = valueOne - valueTwo;
                    resultOfTask = $"{valueOne} - {valueTwo}";
                }
                else
                {
                    resultOfRandom = valueTwo - valueOne;
                    resultOfTask = $"{valueTwo} - {valueOne}";
                }
                break;

            case 3:
                resultOfRandom = valueOne * valueTwo;
                resultOfTask = $"{valueOne} * {valueTwo}";
                break;

            case 4:
                resultOfRandom = valueOne + valueTwo;
                resultOfTask = $"{valueOne} + {valueTwo}";
                break;

        }

    }
    public void ClearString()
    {
        inputStringField = string.Empty;
        inputFieldUGUI.text = inputStringField;
    }

    public void ShowTask()
    {
        DoRandomRange();
        DecideOnSign();
        taskField.text = resultOfTask;
    }

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        uiManager = FindObjectOfType<UIManager>();
        ShowTask();
    }

    public void ButtonPressed()
    {
        soundManager.DoSoundOnClick();
        pressedButtonValue = EventSystem.current.currentSelectedGameObject.name;

        if (pressedButtonValue == "=")
        {
            if (inputFieldUGUI.text == resultOfRandom.ToString())
            {
                ShowTask();
            }
            else
            {
                if (inputFieldUGUI.text.Length != 0)
                {
                    soundManager.DoTryAgainSound();
                    uiManager.ShowTryAgainMessage();
                }
            }
            ClearString();
        }
        else
        {
            if (pressedButtonValue == "X")
            {
                if (inputStringField.Length > 0)
                {
                    pressedButtonValue = string.Empty;
                    inputStringField = inputStringField.Remove(inputStringField.Length - 1);
                    inputFieldUGUI.text = inputStringField;
                }
            }
            else
            {
                inputStringField += pressedButtonValue;
                inputFieldUGUI.text = inputStringField;
            }
        }
    }
}
