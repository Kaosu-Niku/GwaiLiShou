using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] AudioSource BGMAudio;
    [SerializeField] AudioSource SoundAudio;
    //? 玩家方UI
    [SerializeField] GameObject StopPanel;
    [SerializeField] GameObject DeathPanel;
    [SerializeField] TMPro.TextMeshProUGUI ModeText;
    [SerializeField] TMPro.TextMeshProUGUI ScoreText;
    [SerializeField] TMPro.TextMeshProUGUI PowerText;
    [SerializeField] TMPro.TextMeshProUGUI PointText;
    [SerializeField] TMPro.TextMeshProUGUI GrazeText;
    [SerializeField] List<Image> HpImage = new List<Image>();
    [SerializeField] List<Image> BombImage = new List<Image>();
    [SerializeField] Image SkillImage;
    [SerializeField] TMPro.TextMeshProUGUI FpsText;
    float FpsTime;
    [SerializeField] GameObject TalkPanel;
    [SerializeField] TMPro.TextMeshProUGUI TalkText;

    //? 敵方UI
    [SerializeField] TMPro.TextMeshProUGUI BossNameText;
    [SerializeField] TMPro.TextMeshProUGUI CardNameText;
    [SerializeField] TMPro.TextMeshProUGUI CardTimeText;
    [SerializeField] Slider BossHp1Slider;
    [SerializeField] Slider BossHp2Slider;

    private void ChangeMusic(AudioClip bgm)
    {
        BGMAudio.clip = bgm;
        BGMAudio.Play();
    }
    private void ChangeScoreText()
    {
        ScoreText.text = "" + GameDataSO.Score;
    }
    private void ChangePowerText()
    {
        PowerText.text = "" + GameDataSO.PlayerPower + " / 4.00";
    }
    private void ChangePointText()
    {
        PointText.text = "" + GameDataSO.Point;
    }
    private void ChangeGrazeText()
    {
        GrazeText.text = "" + GameDataSO.Graze;
    }
    private void ChangeHpImage()
    {
        for (int x = 0; x < 10; x++)
        {
            if (x < GameDataSO.PlayerHp)
            {
                HpImage[x].enabled = true;
                HpImage[x].fillAmount = 1;
            }
            else
                HpImage[x].enabled = false;
        }
        if (GameDataSO.PlayerHp < 10 && GameDataSO.PlayerSmallHp != 0)
        {
            HpImage[GameDataSO.PlayerHp].enabled = true;
            HpImage[GameDataSO.PlayerHp].fillAmount = GameDataSO.PlayerSmallHp / 6;
        }
    }
    private void ChangeBombImage()
    {
        for (int x = 0; x < 10; x++)
        {
            if (x < GameDataSO.PlayerBomb)
            {
                BombImage[x].enabled = true;
                BombImage[x].fillAmount = 1;
            }
            else
                BombImage[x].enabled = false;
        }
        if (GameDataSO.PlayerBomb < 10 && GameDataSO.PlayerSmallBomb != 0)
        {
            BombImage[GameDataSO.PlayerBomb].enabled = true;
            BombImage[GameDataSO.PlayerBomb].fillAmount = GameDataSO.PlayerSmallBomb / 6;
        }
    }
    private void ChangeSkillImage()
    {
        SkillImage.fillAmount = GameDataSO.PlayerSkill / 9;
    }
    private void OpenStopPanel()
    {
        Time.timeScale = 0;
        StopPanel.SetActive(true);
    }
    private void OpenDeathPanel()
    {
        Time.timeScale = 0;
        DeathPanel.SetActive(true);
    }
    private void UseTalkPanel(bool u, string t)
    {
        if (u == true)
        {
            TalkPanel.SetActive(true);
            TalkText.text = t;
        }
        else
        {
            TalkPanel.SetActive(false);
            TalkText.text = "";
        }
    }
    private void OpenAllBossUI()
    {
        BossNameText.gameObject.SetActive(true);
        CardNameText.gameObject.SetActive(true);
        CardTimeText.gameObject.SetActive(true);
        BossHp1Slider.gameObject.SetActive(true);
        BossHp2Slider.gameObject.SetActive(true);
    }
    private void CloseAllBossUI()
    {
        BossNameText.gameObject.SetActive(false);
        CardNameText.gameObject.SetActive(false);
        CardTimeText.gameObject.SetActive(false);
        BossHp1Slider.gameObject.SetActive(false);
        BossHp2Slider.gameObject.SetActive(false);
    }
    private void ChangeBossNameText(string s)
    {
        BossNameText.text = s;
    }
    private void ChangeCardNameText(string s)
    {
        CardNameText.text = s;
    }
    private void ChangeCardTimeText(int t)
    {
        CardTimeText.text = "" + t;
    }
    private void ChangeBossHpSlider(float hp1, float hp2)
    {
        BossHp1Slider.value = hp1;
        BossHp2Slider.value = hp2;
    }
    private void OnEnable()
    {
        GameRunSO.ChangeMusicAction += ChangeMusic;
        GameUiSO.ChangeScoreAction += ChangeScoreText;
        GameUiSO.ChangePowerAction += ChangePowerText;
        GameUiSO.ChangePointAction += ChangePointText;
        GameUiSO.ChangeGrazeAction += ChangeGrazeText;
        GameUiSO.ChangeHpImageAction += ChangeHpImage;
        GameUiSO.ChangeBombImageAction += ChangeBombImage;
        GameUiSO.ChangeSkillImageAction += ChangeSkillImage;
        GameUiSO.OpenStopPanelAction += OpenStopPanel;
        GameUiSO.OpenDeathPanelAction += OpenDeathPanel;
        GameUiSO.UseTalkPanelAction += UseTalkPanel;
        GameUiSO.OpenAllBossUIAction += OpenAllBossUI;
        GameUiSO.CloseAllBossUIAction += CloseAllBossUI;
        GameUiSO.ChangeBossNameTextAction += ChangeBossNameText;
        GameUiSO.ChangeCardNameTextAction += ChangeCardNameText;
        GameUiSO.ChangeCardTimeTextAction += ChangeCardTimeText;
        GameUiSO.ChangeBossHpSliderAction += ChangeBossHpSlider;
    }
    private void OnDisable()
    {
        GameRunSO.ChangeMusicAction -= ChangeMusic;
        GameUiSO.ChangeScoreAction -= ChangeScoreText;
        GameUiSO.ChangePowerAction -= ChangePowerText;
        GameUiSO.ChangePointAction -= ChangePointText;
        GameUiSO.ChangeGrazeAction -= ChangeGrazeText;
        GameUiSO.ChangeHpImageAction -= ChangeHpImage;
        GameUiSO.ChangeBombImageAction -= ChangeBombImage;
        GameUiSO.ChangeSkillImageAction -= ChangeSkillImage;
        GameUiSO.OpenStopPanelAction -= OpenStopPanel;
        GameUiSO.OpenDeathPanelAction -= OpenDeathPanel;
        GameUiSO.UseTalkPanelAction -= UseTalkPanel;
        GameUiSO.OpenAllBossUIAction -= OpenAllBossUI;
        GameUiSO.CloseAllBossUIAction -= CloseAllBossUI;
        GameUiSO.ChangeBossNameTextAction -= ChangeBossNameText;
        GameUiSO.ChangeCardNameTextAction -= ChangeCardNameText;
        GameUiSO.ChangeCardTimeTextAction -= ChangeCardTimeText;
        GameUiSO.ChangeBossHpSliderAction -= ChangeBossHpSlider;
    }
    private void Start()
    {
        switch (GameDataSO.GameDifficulty)
        {
            case 0: ModeText.text = "Easy"; break;
            case 1: ModeText.text = "Normal"; break;
            case 2: ModeText.text = "Hard"; break;
            case 3: ModeText.text = "Lunatic"; break;
        }
        ChangeScoreText();
        ChangePowerText();
        ChangePointText();
        ChangeGrazeText();
        ChangeHpImage();
        ChangeBombImage();
        ChangeSkillImage();
        UseTalkPanel(false, "");
        CloseAllBossUI();
    }
    void Update()
    {
        FpsTime += Time.deltaTime;
        if (FpsTime > 1)
        {
            float f = 1 / Time.deltaTime;
            FpsText.text = "" + ((int)f);
            FpsTime = 0;
        }
    }
}
