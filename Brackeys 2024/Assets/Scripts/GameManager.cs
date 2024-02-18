using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isScrolling;
    public float doorAppearTime;
    public float cutsceneTime;
    public bool gameOver;
    public int doorNumber;
    private GameObject gameOverPanel;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
        gameOverPanel = Resources
    .FindObjectsOfTypeAll<GameObject>()
    .FirstOrDefault(g => g.CompareTag("Panel"));
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
        doorNumber++;
        Debug.Log("WIN");
        RestartGame();
    }

    public void Lose()
    {
        gameOver = true;
        ChangeScrolling(false);
        Debug.Log("LOSE");
        doorNumber = 1;
        Invoke("enablePanel", 1);
    }

    void enablePanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
