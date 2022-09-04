using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UITapToStart : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject _root = null;
    [SerializeField] private UIHandler _uiHandler;

    public event Action Tapped;
    public UnityEvent ActivateAfterTap;

    public void Show()
    {
        _root.SetActive(true);
    }
    
    public void Hide()
    {
        _root.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ActivateAfterTap?.Invoke();
        Tapped?.Invoke();
        Hide();
        _uiHandler.StartTimer();
    }
}