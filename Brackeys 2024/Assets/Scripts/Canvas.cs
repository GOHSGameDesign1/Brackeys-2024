using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro.text = "Door: " + GameManager.Instance.doorNumber;
    }
    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }
}
