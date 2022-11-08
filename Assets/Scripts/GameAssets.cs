using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets instance;
    public static GameAssets Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }
            return instance;
        }
    }

    public Camera MainCamera { get => mainCamera; set => mainCamera = value; }

    private Camera mainCamera;

    public TextMeshProUGUI ResultLabel;

    public AudioSource AudioSource;
    public AudioClip WindClip;
    public AudioClip Fail;
    public AudioClip Win;

    public SO_PersistentStorage Storage;

}
