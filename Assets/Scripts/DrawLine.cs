using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;
    private GameObject currentLine;
    private List<GameObject> lines; 

    

    public const float RESOLUTION = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
    }

    private void Start()
    {
        lines = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = GameAssets.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, mousePos, Quaternion.identity, null);
            lines.Add(currentLine);
            GameAssets.Instance.AudioSource.PlayOneShot(GameAssets.Instance.WindClip, 0.5f);
        }

        else if (Input.GetMouseButton(0))
        {
            //add point to current line
            currentLine.GetComponent<Line>().SetPosition(mousePos);

        }
    }

    public void DestroyLines()
    {
        for (int i = lines.Count - 1; i >= 0; i--)
        {
            Destroy(lines[i]);
        }
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
