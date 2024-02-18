using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject player;
    private bool triggered;

    private void Awake()
    {
        triggered = false;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        float Ydistance = Mathf.Abs(player.transform.position.y - transform.position.y);

        if(Ydistance < 2 && !triggered)
        {
            triggered = true;
            player.GetComponent<PlayerCollision>().EnterTheDoor();
        }
    }
}
