using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public float xMax;
    public float xMin;

    public List<SpawnObject> SpawnList;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var spawn in SpawnList)
        {
            StartCoroutine(Spawn(spawn.Object, spawn.spawnWaitTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(GameObject spawnObject, float waitTime)
    {
        WaitForSeconds spawnWait = new WaitForSeconds(waitTime);
        while (true) // TODO: Change this to when the game is running the level
        {
            yield return spawnWait;
            Instantiate(spawnObject, new Vector3(Random.Range(xMin, xMax), Random.Range(20, 30), 0), Quaternion.identity);
        }
    }
}
