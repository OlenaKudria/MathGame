using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Language
{
    public string[] choosingButtons;
    public string headerOfMessageBox;
}

public class LanguageSystem : MonoBehaviour
{
    public TextMeshProUGUI[] buttons;
    public TextMeshProUGUI headerMessageBox;
    private SoundManager soundManager;

    private string json;
    public static Language language = new Language();
    private int languageIndex = 1;
    public string[] languageArray = { "ua_UA", "en_EN" };

    private void Awake()
    {

        if (!PlayerPrefs.HasKey("Language"))
        {
            int language = 0;
            if (Application.systemLanguage != SystemLanguage.Ukrainian)
            {
                 language = 1;
            }
            PlayerPrefs.SetString("Language", languageArray[language]);
        }
        LanguageLoad();
    }

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        for (int i = 0; i < languageArray.Length; i++)
        {
            if (PlayerPrefs.GetString("Language") == languageArray[i])
            {
                languageIndex = i + 1;
                break;
            }
        }
        SwitchButtons();
        SwitchHeaderOfMessageBox();
    }

    void LanguageLoad()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.streamingAssetsPath, "Languages/" + PlayerPrefs.GetString("Language") + ".json");
        WWW reader = new WWW(path);
        while(!reader.isDone) { }
        json = reader.text;
#endif

#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
#endif
        language = JsonUtility.FromJson<Language>(json);
    }

    void SwitchButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].text = language.choosingButtons[i];
        }
    }

    void SwitchHeaderOfMessageBox()
    {
        headerMessageBox.text = language.headerOfMessageBox;
    }

    public void SwitchLanguage()
    {
        if (languageIndex != languageArray.Length) languageIndex++;
        else languageIndex = 1;

        PlayerPrefs.SetString("Language", languageArray[languageIndex - 1]);
        LanguageLoad();
        SwitchButtons();
        SwitchHeaderOfMessageBox();
        soundManager.DoSoundOnClick();
    }

}