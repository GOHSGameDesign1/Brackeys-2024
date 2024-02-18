using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.Lose();
            Die();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hole")
        {
            transform.position = collision.transform.position;
            GameManager.Instance.Lose();
            StartCoroutine(Fall());
        }

        //if(collision.gameObject.tag == "Door")
        //{
        //    EnterTheDoor();
        //}
    }

    IEnumerator Fall()
    {
        float time = 0;

        while (time < 0.2f)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time / 0.2f);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);

    }

    public void EnterTheDoor()
    {
        transform.position = Vector2.zero;
        GameManager.Instance.Win();
        StartCoroutine(EnterDoor());
    }

    IEnumerator EnterDoor()
    {
        float time = 0;
        GetComponent<Collider2D>().enabled = false;

        while (time < 2f)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    
}
