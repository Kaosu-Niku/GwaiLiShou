using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicRoom : MonoBehaviour
{
    [SerializeField] AudioSource MyAudio;
    [SerializeField] TMPro.TextMeshProUGUI MyText;
    [SerializeField] List<TMPro.TextMeshProUGUI> MusicNameText = new List<TMPro.TextMeshProUGUI>();
    [SerializeField] List<AudioClip> MusicClip = new List<AudioClip>();
    List<string> MusicName = new List<string>()
    {
        "遊藝霜走的妖獸","報恩者的白色季節","雪下的白翼少女 ~ Twilight Crane","期盼的聖夜嫻吟","來自北方之禮 ~ Xmas gift",
        "冰晶河畔的午夜茶會","Legend of Commander Re'em","六文斷離的躇步","葉隱疾走的孤鳴","Laputa Skirmish",
        "天翔地遁,否之乾坤門衛","金碧輝煌的深邃地宮","日本一傳說的討鬼凶劍","血起云湧的大洞窟","世人誤解的巨足妖怪",
        "迎接睦月的霓虹燈籠","亞卦麻氏手~Crimson Greetings","??????????","??????????","??????????"
    };
    private void Awake()
    {
        for (int x = 0; x < 20; x++)
        {
            if (PlayerDataSO.AllMusic[x] == true)
                MusicNameText[x].text = "N0." + (x + 1) + " " + MusicName[x];
            else
                MusicNameText[x].text = "N0." + (x + 1) + " " + "??????????";
        }
    }
    private void OnDisable()
    {
        //? 關閉音樂房頁面時回復主選單BGM
        MyAudio.clip = MusicClip[0];
        MyAudio.Play();
    }
    public void PlayMusic(int which)
    {
        if (PlayerDataSO.AllMusic[which] == true)
        {
            // MyAudio.clip = MusicClip[which];
            // MyAudio.Play();
            //SetMusicIntroduce(which);
        }
        else
        {
            MyAudio.Pause();
            MyText.text = "";
        }
        MyAudio.clip = MusicClip[which];
        MyAudio.Play();
        SetMusicIntroduce(which);
    }
    void SetMusicIntroduce(int which)
    {
        switch (which)
        {
            case 0:
                MyText.text = "遊戲主題曲。" + "\n" + "用以表現冬天飄渺意象編寫而成的曲子。";
                break;
            case 1:
                MyText.text = "輕鬆的開場。" + "\n" + "旋律中帶有一些日本特色的半音階，" + "\n" + "或許跟接下來遇到的敵人有關。";
                break;
            case 2:
                MyText.text = "是位害羞的妖怪。" + "\n" + "副歌想表現出BOSS雖然不擅長戰鬥，" + "\n" + "但還是全力以赴對抗的感覺。";
                break;
            case 3:
                MyText.text = "與妖怪時而狂躁，時而憂鬱的心情相呼應，" + "\n" + "是首帶有懷念感覺的曲子。" + "\n" + "參考曲:Santa Claus Is Coming To Town.";
                break;
            case 4:
                MyText.text = "特別矮小的妖怪，喜歡玩耍，感覺就像個小孩子，" + "\n" + "所以選用了短促的音色來塑造那種調皮的形象。";
                break;
            case 5:
                MyText.text = "冬天的妖怪之山。" + "\n" + "想像了在這種氣候下自由飛行的感覺，非常愜意。";
                break;
            case 6:
                MyText.text = "作為司令且個性直接" + "\n" + "又帶領了一群䑏疏，想像起來就感覺特別有氣勢呢~";
                break;
            case 7:
                MyText.text = "";
                break;
            case 8:
                MyText.text = "";
                break;
            case 9:
                MyText.text = "";
                break;
            case 10:
                MyText.text = "";
                break;
            case 11:
                MyText.text = "";
                break;
            case 12:
                MyText.text = "";
                break;
            case 13:
                MyText.text = "";
                break;
            case 14:
                MyText.text = "";
                break;
            case 15:
                MyText.text = "";
                break;
            case 16:
                MyText.text = "";
                break;
            case 17:
                MyText.text = "";
                break;
            case 18:
                MyText.text = "";
                break;
            case 19:
                MyText.text = "";
                break;
        }
    }
}
