using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private GameObject newtonPrefab;


    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject [] SpawnElems()
    {
        GameObject[] elems = new GameObject[2]; 
        Vector2 appleSpawnPos = GetRandomXSpawnPosition(Screen.height - 20);
        Vector2 newtonSpawnPos = GetRandomXSpawnPosition(Screen.height / 6);
        elems[0] = Instantiate(applePrefab, appleSpawnPos, Quaternion.identity, null);
        elems[1] = Instantiate(newtonPrefab, newtonSpawnPos, Quaternion.identity, null);
        return elems;
    }

    private Vector2 GetRandomXSpawnPosition(float y)
    {
        float screenX = Random.Range(90, Screen.width - 60);
        
        Vector2 pos = GameAssets.Instance.MainCamera.ScreenToWorldPoint(new Vector2(screenX, y));
        return new Vector2(pos.x, pos.y);
    }
}
