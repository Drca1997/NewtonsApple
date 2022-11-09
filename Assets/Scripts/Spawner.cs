using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private GameObject newtonPrefab;
    [SerializeField]
    private GameObject wallPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 leftWallPos = GameAssets.Instance.MainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
        Vector2 rightWallPos = GameAssets.Instance.MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        Instantiate(wallPrefab, leftWallPos, Quaternion.Euler(0, 0, 90), null);
        Instantiate(wallPrefab, rightWallPos, Quaternion.Euler(0, 0, 90), null);

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

    public Vector2 GetRandomXSpawnPosition(float y)
    {
        float screenX = Random.Range(90, Screen.width - 60);
        
        Vector2 pos = GameAssets.Instance.MainCamera.ScreenToWorldPoint(new Vector2(screenX, y));
        return new Vector2(pos.x, pos.y);
    }
}
