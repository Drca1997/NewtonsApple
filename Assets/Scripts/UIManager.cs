using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Enums;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField]
    private TextMeshProUGUI resultLabel;
    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    [SerializeField]
    private TextMeshProUGUI standardCurrentTryLabel;
    [SerializeField]
    private TextMeshProUGUI finalScoreLabel;
    [SerializeField]
    private GameObject gameEndPanel;

    public static UIManager Instance { get => instance;}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameHandler.EndOfGame += OnEndOfGame;
        if (!Utils.IsSurvivorMode())
        {
            standardCurrentTryLabel.gameObject.SetActive(true);
        }
    }

    public void UpdateScore(int score)
    {
        scoreLabel.SetText("SCORE: " + score);
    }

    public void UpdateTries(int tries)
    {
        standardCurrentTryLabel.SetText("Current Try: " + tries + "/" + StandardMode.STANDARD_MODE_MAXIMUM_TRIES);
    }

    public void ShowResultLabel(ResultCode resultCode, Color32 color)
    {
        resultLabel.gameObject.SetActive(true);
        resultLabel.SetText(resultCode == ResultCode.VICTORY ? "VICTORY" : "DEFEAT");
        resultLabel.color = color;
    }
    public void HideResultLabel()
    {
        resultLabel.gameObject.SetActive(false);
    }
    private void OnEndOfGame(object sender, GameHandler.EndOfGameArgs args)
    {
        gameEndPanel.SetActive(true);
        finalScoreLabel.SetText(args.finalScore.ToString());
        scoreLabel.gameObject.SetActive(false);
        resultLabel.gameObject.SetActive(false);
        if (!Utils.IsSurvivorMode())
        {
            standardCurrentTryLabel.gameObject.SetActive(false);
        }
        GameHandler.EndOfGame -= OnEndOfGame;   
    }
}
