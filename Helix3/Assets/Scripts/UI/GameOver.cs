using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMP_Text gameOverText;

    public void EnableText()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
    }
    public void DisableText()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
