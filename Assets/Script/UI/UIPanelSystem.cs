using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIPanelSystem : MonoBehaviour
{
    [SerializeField] EventSystem GetEventSystem;
    List<GameObject> AllPanel = new List<GameObject>();
    [SerializeField] GameObject DefaultCurrentButton;
    List<GameObject> AllCurrentButton = new List<GameObject>();
    InputControl GetInput;
    private void Awake()
    {
        GetInput = new InputControl();
        AllCurrentButton.Add(DefaultCurrentButton);
    }
    private void OnEnable()
    {
        GetInput.Enable();
        GetInput.UI.Back.performed += BackLastPanel;
        GetInput.UI.ChangeWindow.performed += ChangeWindowMode;
    }
    private void OnDisable()
    {
        GetInput.Disable();
        GetInput.UI.Back.performed -= BackLastPanel;
        GetInput.UI.ChangeWindow.performed -= ChangeWindowMode;
    }
    public void OpenNewPanel(GameObject p)//? 開啟新頁面並記錄
    {
        p.SetActive(true);
        AllPanel.Add(p);
    }
    public void SetNewCurrentButton(GameObject b)//? 激活新頁面的按紐
    {
        GetEventSystem.SetSelectedGameObject(null);
        GetEventSystem.SetSelectedGameObject(b);
        AllCurrentButton.Add(b);
    }
    void BackLastPanel(InputAction.CallbackContext context)//? 按X關閉最後的頁面並激活上一頁的按紐
    {
        if (AllPanel.Count > 0)
        {
            AllPanel[AllPanel.Count - 1].SetActive(false);
            AllPanel.RemoveAt(AllPanel.Count - 1);
        }
        if (AllCurrentButton.Count > 1)
        {
            AllCurrentButton.RemoveAt(AllCurrentButton.Count - 1);
            GetEventSystem.SetSelectedGameObject(AllCurrentButton[AllCurrentButton.Count - 1]);
        }
    }

    void ChangeWindowMode(InputAction.CallbackContext context)//? 切換全螢幕或視窗模式
    {
        if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
            AllEventSO.ChangeWindowMode(false);
        else
            AllEventSO.ChangeWindowMode(true);
    }
}
