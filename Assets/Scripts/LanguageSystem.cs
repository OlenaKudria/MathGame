using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class Language
{
    public string[] choosingButtons;
}

public class LanguageSystem : MonoBehaviour
{
    public Image languageButtonImage;
    public Sprite[] flags;

    private string json;
    public static Language language = new Language();
    private int languageIndex = 1;
    private string[] languageArray = { "ua_UA", "en_EN" };

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Ukrainian)
                PlayerPrefs.SetString("Language", "ua_UA");
            else
                PlayerPrefs.SetString("Language", "en_EN");
        }
        LanguageLoad();

    }

    private void Start()
    {
            for (int i = 0; i < languageArray.Length; i++)
            {
                if (PlayerPrefs.GetString("Language") == languageArray[i])
                {
                    languageIndex = i + 1;
                    languageButtonImage.sprite = flags[i];
                    break;
                }
            }
    }

    void LanguageLoad()
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
        Debug.Log(json);

        language = JsonUtility.FromJson<Language>(json);
        Debug.Log(language.choosingButtons[0]);
    }

    public void SwitchFlags()
    {
        if (languageIndex != languageArray.Length) languageIndex++;
        else languageIndex = 1;

        PlayerPrefs.SetString("Language", languageArray[languageIndex - 1]);

        languageButtonImage.sprite = flags[languageIndex - 1];
        LanguageLoad();
    }

}