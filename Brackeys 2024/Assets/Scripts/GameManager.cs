using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isScrolling;
    public float doorAppearTime;
    public float cutsceneTime;
    public bool gameOver;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isScrolling = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScrolling(bool change)
    {
        isScrolling = change;
    }

    public void StartGame()
    {
        ChangeScrolling(true);

    }

    public void Win()
    {
        ChangeScrolling(false);
        Debug.Log("WIN");
    }

    public void Lose()
    {
        gameOver = true;
        ChangeScrolling(false);
        Debug.Log("LOSE");
    }
}
