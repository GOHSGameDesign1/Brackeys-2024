using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GhostPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Go()
    {
        float time = 0;

        while(time < GameManager.Instance.cutsceneTime)
        {
            transform.position = Vector2.Lerp(new Vector2(0, -5), new Vector2(0, 10), time / GameManager.Instance.cutsceneTime);
            time += Time.deltaTime;
            yield return null;
        }
        VirtualCamera.Follow = GameObject.Find("Target").transform;
        GameManager.Instance.StartGame();
        Destroy(gameObject);
    }
}
