using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    private LanguageSystem languageSystem;
    public TMP_Dropdown dropdown;

    void Start()
    {
        languageSystem = FindObjectOfType<LanguageSystem>();
    }

    public void HandleInputData()
    {
        if(dropdown.value == 0)
        { 
            if(PlayerPrefs.GetString("Langu age") != languageSystem.languageArray[0])
            {
                languageSystem.SwitchLanguage();
            }
        }

        if(dropdown.value == 1)
        {
            if (PlayerPrefs.GetString("Language") != languageSystem.languageArray[1])
            {
                languageSystem.SwitchLanguage();
            }
        }
    }

}
