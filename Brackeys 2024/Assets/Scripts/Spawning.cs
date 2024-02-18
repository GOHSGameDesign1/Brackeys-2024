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
            StartCoroutine(Spawn(spawn, spawn.spawnWaitTime));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn(SpawnObject spawnObject, float waitTime)
    {
        WaitForSeconds spawnWait = new WaitForSeconds(waitTime);
        while (true) // TODO: Change this to when the game is running the level
        {
            yield return spawnWait;
            if (spawnObject.isHorizontal)
            {
                Instantiate(spawnObject.Object, new Vector3(PosOrNeg() * 8, Random.Range(-5f, 5f), 0), Quaternion.identity);
            }
            else
            {
                Instantiate(spawnObject.Object, new Vector3(Random.Range(xMin, xMax), Random.Range(20, 30), 0), Quaternion.identity);
            }
        }
    }

    int PosOrNeg()
    {
        return Random.Range(0, 2) > 0 ? 1 : -1;
    }
}
