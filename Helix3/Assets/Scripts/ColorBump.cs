using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBump : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color color;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        transform.parent = null;

        transform.rotation = Quaternion.Euler(Vector3.zero);


        color = GameController.instance.colors[Random.Range(0, GameController.instance.colors.Length)];
        meshRenderer.material.color = color;
    }
    public Color GetColor()
    {
        return this.color;
    }
}
