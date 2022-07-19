using TMPro;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    private LanguageSystem languageSystem;
    public TMP_Dropdown dropdown;

    void Start()
    {
        languageSystem = FindObjectOfType<LanguageSystem>();
        dropdown.value = PlayerPrefs.GetInt("Value");
    }

    public void HandleInputData()
    {
        if (PlayerPrefs.GetString("Language") != languageSystem.languageArray[dropdown.value])
        {
            languageSystem.SwitchLanguage();
        }
        PlayerPrefs.SetInt("Value", dropdown.value);
    }

}
