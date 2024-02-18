using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    [SerializeField] float _endScale;
    [SerializeField] float _explodeTime;
    [SerializeField] float _implodeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PerformExplode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PerformExplode()
    {
        float time = 0;
        while (time < _explodeTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * _endScale, time / _explodeTime);
            time += Time.deltaTime;
            yield return null;
        }

        time = 0;

        while (time < _implodeTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.one * _endScale, Vector3.zero, time / _implodeTime);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

}
