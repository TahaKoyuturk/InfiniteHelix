using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    public TMP_Text TapToStartText;
    private void Start()
    {
        TapToStartText = transform.GetComponent<TMP_Text>();
    }
    public void EnableText()
    {
        TapToStartText.gameObject.SetActive(true);
        TapToStartText.text = "Drag To Start";
    }
    public void DisableText()
    {
        TapToStartText.gameObject.SetActive(false);
    }
}
