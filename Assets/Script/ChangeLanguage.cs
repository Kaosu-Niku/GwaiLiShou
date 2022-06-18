using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ChangeLanguage : MonoBehaviour
{
    TMPro.TextMeshProUGUI GetText;
    [SerializeField] List<string> Chinese = new List<string>();
    [SerializeField] List<string> English = new List<string>();
    [SerializeField] List<string> Japanese = new List<string>();
    [SerializeField] AllEventSO GetAllEventSO;
    private void Awake()
    {
        GetText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        AllEventSO.ChangeLanguageEvent += TextChangeLanguage;
        TextChangeLanguage();
    }
    private void OnDisable()
    {
        AllEventSO.ChangeLanguageEvent -= TextChangeLanguage;
    }

    private void TextChangeLanguage()
    {
        if (GetText)
        {
            StringBuilder sb = new StringBuilder();
            switch (GameDataSO.Language)
            {
                case 0:
                    GetText.font = GetAllEventSO.ChineseFontAsset;
                    for (int x = 0; x < Chinese.Count; x++)
                    {
                        sb.AppendLine(Chinese[x]);
                    }
                    GetText.text = sb.ToString();
                    break;
                case 1:
                    GetText.font = GetAllEventSO.EnglishFontAsset;
                    for (int x = 0; x < English.Count; x++)
                    {
                        sb.AppendLine(English[x]);
                    }
                    GetText.text = sb.ToString();
                    break;
                case 2:
                    GetText.font = GetAllEventSO.JapaneseFontAsset;
                    for (int x = 0; x < Japanese.Count; x++)
                    {
                        sb.AppendLine(Japanese[x]);
                    }
                    GetText.text = sb.ToString();
                    break;
            }
        }
    }
}
