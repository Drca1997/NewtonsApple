using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   private TextMeshProUGUI label;

    private bool lost;
    private bool won;
    // Start is called before the first frame update
    void Start()
    {
        label = GameAssets.Instance.Label;
        lost = false;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLIDING");
        if (collision.gameObject.CompareTag("Newton"))
        {

            Debug.Log("BONK!");
            if (!won && !lost)
            {
                won = true;
                GameAssets.Instance.AudioSource.PlayOneShot(GameAssets.Instance.Win, 0.7f);
                StartCoroutine(DelayEndOfGame("VICTORY", new Color32(38, 174, 219, 255)));

            }
        }
        else if (collision.collider.gameObject.CompareTag("Floor"))
        {
            if (!lost && !won)
            {
                GameAssets.Instance.AudioSource.PlayOneShot(GameAssets.Instance.Fail, 0.5f);
                lost = true;
                StartCoroutine(DelayEndOfGame("DEFEAT", new Color32(166, 35, 28, 255)));
            }
        }
    }

    private IEnumerator DelayEndOfGame(string result, Color32 color)
    {
        label.gameObject.SetActive(true);
        label.text = result;
        label.color = color;
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainMenu");
    }

}
