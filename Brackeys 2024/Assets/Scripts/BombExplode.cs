using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public float range;
    public AnimationClip fuseClip;
    private Vector2 direction;
    private GameObject player;
    private Animator animator;
    private void Awake()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            return;
        }

        direction = player.transform.position - transform.position;

        if(direction.magnitude <= range)
        {
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        animator.Play(fuseClip.name);
        yield return new WaitForSeconds(fuseClip.length);
        Destroy(gameObject);
    }


}
