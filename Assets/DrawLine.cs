using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private GameObject linePrefab;
    [SerializeField]
    private TextMeshProUGUI label;
    private GameObject currentLine;
    [SerializeField]
    private AudioSource wind;
    [SerializeField]
    private AudioClip windClip;
    [SerializeField]
    private AudioClip fail;
    [SerializeField]
    private AudioClip win;

    public const float RESOLUTION = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        GameAssets.Instance.MainCamera = mainCamera;
        GameAssets.Instance.Label = label;
        GameAssets.Instance.Fail = fail;
        GameAssets.Instance.Win = win;
        GameAssets.Instance.AudioSource = wind;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity, null);
            wind.PlayOneShot(windClip, 0.5f);
        }

        else if (Input.GetMouseButton(0))
        {
            //add point to current line
            currentLine.GetComponent<Line>().SetPosition(mousePos);

        }
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
