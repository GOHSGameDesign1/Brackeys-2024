using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float fallSpeed;
    public float waitTime;
    public float chargeSpeed;
    private Vector2 direction;
    private bool charged;

    private SpriteRenderer sprite;
    public List<Sprite> sprites;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        charged = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            direction = (Vector2)player.transform.position - rb.position;
        } else
        {
            direction = Vector2.zero;
        }
        Debug.Log(direction.magnitude);

        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }

        if (!charged)
        {
            rb.velocity = Vector2.down * fallSpeed;
        }

        if(direction.magnitude < 5 && !charged && player != null)
        {
            charged = true;
            StartCoroutine(ChargeWait());
            StartCoroutine(ChangeSprites());
            StartCoroutine(lightWarning());
        }
    }

    IEnumerator ChargeWait()
    {
        float time = 0;
        while (time < waitTime)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            sprite.transform.rotation = Quaternion.Slerp(sprite.transform.rotation, q, Time.deltaTime * 10);
            time += Time.deltaTime;
            yield return null;
        }
        Charge();
    }

    void Charge()
    {
        sprite.transform.GetChild(0).gameObject.SetActive(false);
        charged = true;
        Vector2 chargeDir = direction;
        rb.velocity = chargeDir.normalized * chargeSpeed;
    }

    IEnumerator ChangeSprites()
    {
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        while (true)
        {
            foreach (var image in sprites)
            {
                sprite.sprite = image;
                yield return wait;
            }
        }
    }

    IEnumerator lightWarning()
    {
        Transform warning = sprite.transform.GetChild(0);
        float time = 0;
        while (time < 0.5)
        {
            warning.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1, 0.2688679f, 0.2688679f, 0), new Color(1, 0.2688679f, 0.2688679f, 0.4f), time);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
