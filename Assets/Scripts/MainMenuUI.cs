using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Enums;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private SO_PersistentStorage storage;
    // Start is called before the first frame update
    void Start()
    {
        GameAssets.Instance.Storage = storage;
        GameAssets.Instance.Storage.gameModeToPlay = GameModeCode.NOT_DEFINED;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStandardMode()
    {
        GameAssets.Instance.Storage.gameModeToPlay = GameModeCode.STANDARD;
        LoadGameScene();
    }

    public void OnSurvivorMode()
    {
        GameAssets.Instance.Storage.gameModeToPlay = GameModeCode.SURVIVOR;
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        DontDestroyOnLoad(GameAssets.Instance);
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
