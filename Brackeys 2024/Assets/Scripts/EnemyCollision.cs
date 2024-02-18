using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public GameObject deathVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        // Instantiate objects here
        Instantiate(deathVFX, transform.position, Quaternion.identity);
    }
}
