using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderP2 : MonoBehaviour
{
    private Image start;
    public Sprite newImage;
    private Image end;
    private Image fillArea;
    void Start()
    {
        start = transform.GetChild(2).GetComponent<Image>();
        end = transform.GetChild(3).GetComponent<Image>();
        fillArea = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        start.enabled = true;
        end.enabled = true;
        start.sprite = newImage;
        end.sprite = newImage;
    } 
    void Update()
    {
        fillArea.color = Ball.GetColor();
        start.color = Ball.GetColor();
         
        end.color = Ball.GetColor();
    }
}
