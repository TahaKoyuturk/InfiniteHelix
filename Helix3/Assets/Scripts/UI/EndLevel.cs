using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : MonoBehaviour
{

    private TMP_Text level2Text;
    void Awake()
    {
        level2Text = transform.GetChild(0).GetComponent<TMP_Text>();

    }
    void Update()
    {
        if (Ball.GetZ() == 0)
        {
            level2Text.gameObject.SetActive(false);
        }
        else
        {
            level2Text.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") < 10)
        {
            level2Text.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
        }
        else
        {
            level2Text.text = "End";
        }
    }
}
