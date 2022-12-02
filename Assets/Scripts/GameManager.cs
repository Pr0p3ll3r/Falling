using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnStartGame;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private GameObject startPanel;
    private float timer = 0;
    private bool playing = false;
    private float bestTime = 0;

    private void OnDisable()
    {
        OnStartGame = null;
    }

    private void OnEnable()
    {
        Obstacle.OnGameOver += Gameover;
    }

    private void Start()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        startPanel.SetActive(true);
        bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        bestTimeText.text = TimeSpan.FromSeconds(bestTime).ToString(@"hh\:mm\:ss\.fff");
    }

    private void Update()
    {
        if (playing)
        {
            timer += Time.deltaTime;
            timerText.text = TimeSpan.FromSeconds(timer).ToString(@"hh\:mm\:ss");
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        timer = 0;
        playing = true;
        OnStartGame?.Invoke();
    }

    private void Gameover()
    {
        playing = false;
        if(timer > bestTime)
        {
            PlayerPrefs.SetFloat("BestTime", timer);
            bestTime = timer;
            bestTimeText.text = TimeSpan.FromSeconds(bestTime).ToString(@"hh\:mm\:ss\.fff");
        }
        timer = 0;
        startPanel.SetActive(true);
    }
}
