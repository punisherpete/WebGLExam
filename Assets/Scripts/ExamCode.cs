using System.Threading;
using Agava.YandexGames;
using UnityEngine;
using System;
using System.Diagnostics;
using TMPro;
using System.Collections;

using Debug = UnityEngine.Debug;

public class ExamCode : MonoBehaviour
{

#if VK_GAMES

    [SerializeField] private TMP_Text _currentTimeText;

    private Stopwatch _timer = new Stopwatch();

    private void Start()
    {
        LoadLocalization();

        Thread.Sleep(60000);

        _timer.Start();
    }

    private void LoadLocalization()
    {
        Debug.Log(YandexGamesSdk.Environment.i18n.lang);
    }

    private void Update()
    {
        _currentTimeText.text = DateTime.Now.ToLocalTime().ToString();

        if(_timer.ElapsedMilliseconds >= 65000)
        {
            _timer.Reset();
            ShowInterstentialAd();
        }
    }

    public void ShowInterstentialAd()
    {
        InterstitialAd.Show();
    }

#endif
}
