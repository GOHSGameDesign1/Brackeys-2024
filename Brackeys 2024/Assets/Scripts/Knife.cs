using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 leftOrRight;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        leftOrRight = transform.position.x > 0 ? Vector2.left : Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isScrolling)
        {
            Destroy(gameObject);
        }

        rb.velocity = leftOrRight * speed;

        rb.rotation += 360 * Time.deltaTime;

        if(Mathf.Abs(rb.position.x) >= 10)
        {
            Destroy(gameObject);
        }
    }
}
