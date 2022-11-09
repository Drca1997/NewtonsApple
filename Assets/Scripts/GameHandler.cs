using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;
using static Enums;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    IGameMode gameMode;

    private Spawner spawner;
    private DrawLine drawLineManager;
    private GameObject apple;
    private GameObject newton;

  
    public const float RESOLUTION = 0.1f;

    private int score;
    private int tries;

    public int Tries { get => tries; }
    public int Score { get => score; }


    public static event EventHandler<EndOfGameArgs> EndOfGame;
    public class EndOfGameArgs: EventArgs
    {
        public int finalScore;
    }


    private void Start()
    {
        GameAssets.Instance.MainCamera = mainCamera;
        score = 0;
        tries = 0;
        spawner = GetComponent<Spawner>();
        drawLineManager = GetComponent<DrawLine>();
       
        switch (GameAssets.Instance.Storage.gameModeToPlay)
        {
            case GameModeCode.STANDARD:
                gameMode = new StandardMode(this);
                break;
            case GameModeCode.SURVIVOR:
                gameMode = new SurvivorMode(this);
                break;
            default:
                Debug.LogError("Something went wrong loading game mode");
                SceneManager.LoadScene("MainMenu");
                break;
        }
        NewTry();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void NewTry()
    {
        GameOver.OnTryEnd += OnTryEnd;
        tries++;
        UIManager.Instance.UpdateTries(tries);
        AudioManager.Instance.Source.Stop();
        GameObject[] elems = spawner.SpawnElems();
        apple = elems[0];
        newton = elems[1];
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnTryEnd(object sender, GameOver.OnTryEndArgs args)
    {
        GameOver.OnTryEnd -= OnTryEnd;
        if (args.resultCode == ResultCode.VICTORY)
        {
            score++;
            UIManager.Instance.UpdateScore(score);
        }
        if (!gameMode.OnTryEnd(args.resultCode))
        {
            EndOfGame?.Invoke(this, new EndOfGameArgs {finalScore = score });
            return;
        }
        DestroyPreviousTryElems();
        NewTry();
    }

    private void DestroyPreviousTryElems()
    {
        Destroy(apple);
        DestroyImmediate(newton);
        drawLineManager.DestroyLines();
    }

   
}
