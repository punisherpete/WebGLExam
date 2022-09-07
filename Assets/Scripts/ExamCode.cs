using Agava.YandexGames;
using UnityEngine;
using System;
using System.Diagnostics;
using TMPro;
using System.Collections;

using Debug = UnityEngine.Debug;

public class ExamCode : MonoBehaviour
{

#if YANDEX_GAMES

    [SerializeField] private TMP_Text _currentTimeText;

    private Stopwatch _timer = new Stopwatch();

    private IEnumerator Start()
    {
        _timer.Start();
        yield return YandexGamesSdk.Initialize(OnYandexSDKInitialize);
    }

    private void Update()
    {
        _currentTimeText.text = DateTime.Now.ToLocalTime().ToString();

        if(_timer.ElapsedMilliseconds >= 65000)
        {
            _timer.Reset();
            _timer.Start();
            ShowInterstentialAd();
        }
    }
    private void OnYandexSDKInitialize()
    {
        LoadLocalization();
    }

    private void LoadLocalization()
    {
        Debug.Log(YandexGamesSdk.Environment.i18n.lang);
    }

    public void ShowInterstentialAd()
    {
        InterstitialAd.Show();
    }

#endif
}
