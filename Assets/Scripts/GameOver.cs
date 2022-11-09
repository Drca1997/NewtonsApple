using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using static Enums;

public class GameOver : MonoBehaviour
{
    private bool lost;
    private bool won;

    public static event EventHandler<OnTryEndArgs> OnTryEnd;

    public class OnTryEndArgs: EventArgs
    {
        public ResultCode resultCode;
    }

    // Start is called before the first frame update
    void Start()
    {
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
                AudioManager.Instance.Play("Victory");
                StartCoroutine(DelayEndOfGame(ResultCode.VICTORY, new Color32(38, 174, 219, 255)));

            }
        }
        else if (collision.collider.gameObject.CompareTag("Floor"))
        {
            if (!lost && !won)
            {
                AudioManager.Instance.Play("Defeat");
                lost = true;
                StartCoroutine(DelayEndOfGame(ResultCode.DEFEAT, new Color32(166, 35, 28, 255)));
            }
        }
    }

    private IEnumerator DelayEndOfGame(ResultCode resultCode, Color32 color)
    {
        UIManager.Instance.ShowResultLabel(resultCode, color);
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.HideResultLabel();
        OnTryEnd?.Invoke(this, new OnTryEndArgs { resultCode = resultCode });
        Destroy(this);
    }

}
