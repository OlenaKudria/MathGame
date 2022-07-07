using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    private LanguageSystem languageSystem;

    void Start()
    {
        languageSystem = FindObjectOfType<LanguageSystem>();
    }

}
