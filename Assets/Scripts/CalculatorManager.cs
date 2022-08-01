using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalculatorManager : MonoBehaviour
{
    public TextMeshProUGUI inputFieldUGUI;
    public TextMeshProUGUI taskField;
    private SoundManager soundManager;

    string inputStringField;
    string pressedButtonValue;
    int resultOfRandom;
    string resultOfTask;
    int valueOne;
    int valueTwo;

    public void DoRandomRange()
    {//
        valueOne = Random.Range(0, 100);
        valueTwo = Random.Range(0, 100);
    }
    public void ClearString()
    {
        inputStringField = string.Empty;
        inputFieldUGUI.text = inputStringField;
    }

    public void ShowTask()
    {
        DoRandomRange();
        resultOfRandom = valueOne + valueTwo;
        resultOfTask = $"{valueOne} + {valueTwo}";
        taskField.text = resultOfTask;
    }

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        ShowTask();
    }

    public void ButtonPressed()
    {
        soundManager.DoSoundOnClick();
        pressedButtonValue = EventSystem.current.currentSelectedGameObject.name;

        if (pressedButtonValue != "=")
        {
            if (pressedButtonValue == "X")
            {
                pressedButtonValue = string.Empty;
                ClearString();
            }
            inputStringField += pressedButtonValue;
            inputFieldUGUI.text = inputStringField;
        }
        else
        {
            if (inputFieldUGUI.text == resultOfRandom.ToString())
            {
                ClearString();
                ShowTask();
            }
            else
            {
                ClearString();
            }
        }
    }
}
