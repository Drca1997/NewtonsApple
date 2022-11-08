using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private TextMeshProUGUI resultLabel;
    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    [SerializeField]
    private TextMeshProUGUI standardCurrentTryLabel;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip windClip;
    [SerializeField]
    private AudioClip fail;
    [SerializeField]
    private AudioClip win;
    [SerializeField]
    private GameObject gameEndPanel;

    private Spawner spawner;
    private DrawLine drawLineManager;
    private GameObject apple;
    private GameObject newton;

    private int standardModeCurrentTry;
    private int standardModeCurrentScore;
    public int STANDARD_MODE_NUM_TRIES = 10;
    private int survivorModeCurrentScore;

    public const float RESOLUTION = 0.1f;

    public int StandardModeCurrentTry { get => standardModeCurrentTry; set => standardModeCurrentTry = value; }
    public int SurvivorModeCurrentScore { get => survivorModeCurrentScore; set => survivorModeCurrentScore = value; }


    // Start is called before the first frame update
    void Awake()
    {
        GameAssets.Instance.MainCamera = mainCamera;
        GameAssets.Instance.ResultLabel = resultLabel;
        GameAssets.Instance.AudioSource = source;
        GameAssets.Instance.WindClip = windClip;
        GameAssets.Instance.Fail = fail;
        GameAssets.Instance.Win = win;
        
    }

    private void Start()
    {
        spawner = GetComponent<Spawner>();
        drawLineManager = GetComponent<DrawLine>();
        switch (GameAssets.Instance.Storage.gameModeToPlay)
        {
            case SO_PersistentStorage.GameMode.STANDARD:
                standardModeCurrentTry = 0;
                standardModeCurrentScore = 0;
                standardCurrentTryLabel.gameObject.SetActive(true);
                NewStandardTry();
                break;
            case SO_PersistentStorage.GameMode.SURVIVOR:

                break;
            default:
                Debug.LogError("Something went wrong loading game mode");
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NewStandardTry()
    {
        DestroyPreviousTryElems();
        source.Stop();
        standardModeCurrentTry++;
        standardCurrentTryLabel.SetText("Current Try: " + standardModeCurrentTry);
        if (standardModeCurrentTry > STANDARD_MODE_NUM_TRIES)
        {
            EndOfGame();
            return;
        }
        GameObject[] elems= spawner.SpawnElems();
        apple = elems[0];
        newton = elems[1];
        GameOver.OnWin += OnWin;
    }

    private void OnWin(object sender, EventArgs args)
    {
        if (GameAssets.Instance.Storage.gameModeToPlay == SO_PersistentStorage.GameMode.STANDARD)
        {
            standardModeCurrentScore++;
            scoreLabel.SetText("SCORE: " + standardModeCurrentScore);
        }
    }

    private void DestroyPreviousTryElems()
    {
        GameOver.OnWin -= OnWin;
        Destroy(apple);
        Destroy(newton);
        drawLineManager.DestroyLines();
    }

    private void EndOfGame()
    {
        gameEndPanel.SetActive(true);
        gameEndPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(standardModeCurrentScore.ToString());
        resultLabel.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(false);
        standardCurrentTryLabel.gameObject.SetActive(false);
    }
}
