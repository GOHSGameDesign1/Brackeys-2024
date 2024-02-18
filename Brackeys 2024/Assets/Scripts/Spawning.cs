using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject ChargeEnemy;

    public float xMax;
    public float xMin;
    public float waitTime;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        WaitForSeconds spawnWait = new WaitForSeconds(waitTime);
        while (true) // TODO: Change this to when the game is running the level
        {
            yield return spawnWait;
            Instantiate(ChargeEnemy, new Vector3(Random.Range(xMin, xMax), Random.Range(20, 30), 0), Quaternion.identity);
        }
    }
}
