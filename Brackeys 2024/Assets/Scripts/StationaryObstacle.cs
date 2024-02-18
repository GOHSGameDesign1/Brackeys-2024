using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryObstacle : MonoBehaviour
{
    private Rigidbody2D rb;

    public float fallSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * fallSpeed;

        if (rb.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
