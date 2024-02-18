using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public float xMax;
    public float xMin;

    public GameObject Door;

    public List<SpawnObject> SpawnList;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.doorNumber < 5)
        {
            for (int i = 0; i < GameManager.Instance.doorNumber; i++)
            {
                StartCoroutine(Spawn(SpawnList[i], SpawnList[i].spawnWaitTime));
            }
        }
        else
        {
            foreach (var spawn in SpawnList)
            {
                StartCoroutine(Spawn(spawn, spawn.spawnWaitTime));
            }
        }

        StartCoroutine(SpawnDoor());
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameOver)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Spawn(SpawnObject spawnObject, float waitTime)
    {
        WaitForSeconds spawnWait = new WaitForSeconds(waitTime);
        while (true) // TODO: Change this to when the game is running the level
        {
            yield return spawnWait;
            if (spawnObject.isHorizontal)
            {
                Instantiate(spawnObject.Object, new Vector3(PosOrNeg() * 8, Random.Range(5f, 15f), 0), Quaternion.identity);
            }
            else
            {
                Instantiate(spawnObject.Object, new Vector3(Random.Range(xMin, xMax), Random.Range(20, 30), 0), Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnDoor()
    {
        yield return new WaitForSeconds(GameManager.Instance.doorAppearTime);
        Instantiate(Door, new Vector3(0, 20, 0), Quaternion.identity);
        StopAllCoroutines();
    }

    int PosOrNeg()
    {
        return Random.Range(0, 2) > 0 ? 1 : -1;
    }
}
