using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    StartLevel sl;
    private TMP_Text level1Text;
    void Awake()
    {
        level1Text = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void Update()
    {
        if (Ball.GetZ() == 0)
        {
            level1Text.gameObject.SetActive(false);
        }
        else
        {
            level1Text.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Level") < 10)
        {
            level1Text.text = PlayerPrefs.GetInt("Level").ToString();

        }
        else
        {
            level1Text.text = PlayerPrefs.GetInt("Level").ToString();
        }

    }
}
