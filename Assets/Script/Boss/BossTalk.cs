using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class BossTalk : MonoBehaviour
{
    [SerializeField] List<string> ChineseTalk = new List<string>();//* 中文對話
    [SerializeField] List<string> EnglishTalk = new List<string>();//* 英文對話
    [SerializeField] List<string> JapaneseTalk = new List<string>();//* 日文對話
    Boss GetBoss;
    int TalkCount;//* 對話計次
    [SerializeField] int StartBgmCount;//* 播放bgm的對話計次
    [SerializeField] int StartFightCount;//* 開始戰鬥的對話計次
    [SerializeField] int EndTalkCount;//* 結束對話的對話計次
    [SerializeField] AudioClip MyMusic;//* Boss的bgm
    [SerializeField] string NextScene;//* 跳轉下一關
    InputControl MyInput;
    private void Awake()
    {
        MyInput = new InputControl();
    }
    private void OnEnable()
    {
        MyInput.Enable();
        MyInput.Player.Shoot.performed += ToTalk;
        MyInput.UI.SkipTalk.performed += SkipTalk;
    }
    private void OnDisable()
    {
        MyInput.Disable();
        MyInput.Player.Shoot.performed -= ToTalk;
        MyInput.UI.SkipTalk.performed -= SkipTalk;
    }
    void Start()
    {
        GetBoss = GetComponent<Boss>();
        GameRunSO.ForPlayerDontControlTrigger(true);
    }
    private void ToTalk(InputAction.CallbackContext context)
    {
        if (TalkCount < ChineseTalk.Count)
        {
            if (TalkCount == StartBgmCount)
            {
                switch (GameDataSO.Language)
                {
                    case 0: GameRunSO.UseTalkPanelTrigger(true, ChineseTalk[TalkCount]); break;
                    case 1: GameRunSO.UseTalkPanelTrigger(true, EnglishTalk[TalkCount]); break;
                    case 2: GameRunSO.UseTalkPanelTrigger(true, JapaneseTalk[TalkCount]); break;
                }
                GameRunSO.ChangeMusicTrigger(MyMusic);
                TalkCount++;
            }
            else if (TalkCount == StartFightCount)
            {
                StartCoroutine(StartFight());
            }
            else if (TalkCount == EndTalkCount)
            {
                StartCoroutine(EndTalk());
            }
            else
            {
                switch (GameDataSO.Language)
                {
                    case 0: GameRunSO.UseTalkPanelTrigger(true, ChineseTalk[TalkCount]); break;
                    case 1: GameRunSO.UseTalkPanelTrigger(true, EnglishTalk[TalkCount]); break;
                    case 2: GameRunSO.UseTalkPanelTrigger(true, JapaneseTalk[TalkCount]); break;
                }
                TalkCount++;
            }
        }
    }
    public void SkipTalk(InputAction.CallbackContext context)
    {
        if (TalkCount <= StartFightCount)
        {
            GameRunSO.ChangeMusicTrigger(MyMusic);
            TalkCount = StartFightCount;
            StartCoroutine(StartFight());
        }
        else
        {
            StartCoroutine(EndTalk());
        }
    }

    IEnumerator StartFight()
    {
        GameRunSO.UseTalkPanelTrigger(false, "");
        GameRunSO.ForPlayerDontControlTrigger(false);
        this.enabled = false;
        TalkCount++;
        yield return new WaitForSeconds(1);
        GetBoss.enabled = true;
    }
    IEnumerator EndTalk()
    {
        GameRunSO.UseTalkPanelTrigger(false, "");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(NextScene);
    }
}
