using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
    private TMP_Text textMesh;

    void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {
        this.textMesh.text = text;
        textMesh.color = Color.white;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Ball.GetZ());
        Destroy(gameObject, 1.2f);
    }
}
