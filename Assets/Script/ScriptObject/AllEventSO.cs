using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AllEvent", menuName = "ScriptObject/AllEvent")]
public class AllEventSO : ScriptableObject
{
    [SerializeField] AudioMixer GetAudioMixer;
    public TMPro.TMP_FontAsset ChineseFontAsset;
    public TMPro.TMP_FontAsset EnglishFontAsset;
    public TMPro.TMP_FontAsset JapaneseFontAsset;

    public static void ChangeTime(float t)//? 更改遊戲時間
    {
        Time.timeScale = t;
    }
    public static void QuitGame()//? 退出遊戲
    {
        Application.Quit();
    }

    public static void GameStart()//? 進入遊戲(根據資料保存的場景名稱)
    {
        SceneManager.LoadSceneAsync(GameDataSO.GameStage);
    }
    public static void ChangeScene(string scene)//? 自行決定跨場景
    {
        SceneManager.LoadSceneAsync(scene);
    }
    // public IEnumerator _loading_game(string _scene)
    // { //? 加載場景
    //     AsyncOperation _a = SceneManager.LoadSceneAsync(_scene);
    //     int _load_long = ((int)_a.progress * 100);
    //     _load_back.SetActive(true);
    //     _load_slider.gameObject.SetActive(true);
    //     while (_a.isDone == false)
    //     { //? 場景是否加載完畢
    //         _load_long = ((int)_a.progress * 100);//? 加載場景的進度
    //         _load_slider.value = _load_long;
    //         yield return null;
    //     }
    // }
    public static UnityAction ChangeLanguageEvent;//? 改變語言事件
    public static void ChangeLanguageTrigger()//? 改變語言事件觸發
    {
        if (ChangeLanguageEvent != null)
        {
            ChangeLanguageEvent.Invoke();
        }
    }
    //? 改變視窗模式
    public static void ChangeWindowMode(bool isFull)
    {
        if (isFull == true)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    //? 改變聲音大小
    public void ChangeAudioMixerMasterValue(Slider getSlider)
    {
        GetAudioMixer.SetFloat("MasterValue", getSlider.value);
    }
    public void ChangeAudioMixerBGMValue(Slider getSlider)
    {
        GetAudioMixer.SetFloat("BGMValue", getSlider.value);
    }
    public void ChangeAudioMixerSEValue(Slider getSlider)
    {
        GetAudioMixer.SetFloat("SEValue", getSlider.value);
    }
}
