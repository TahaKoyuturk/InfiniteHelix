using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadRoad : MonoBehaviour
{
    public static LoadRoad instance;
    [SerializeField] Slider slider;
    private Image start;

    float maxDistance;
    private void Awake()
    {

        instance = this;
    }
    void Update()
    {

        if(maxDistance >= Ball.GetZ())
        {
            float distance =  ( Ball.GetZ()/ maxDistance);
            setProgress(distance);
        }
    }
    public void setFinishLine(int finishLine)
    {
        maxDistance = finishLine;
    }
    void setProgress(float p)
    {
        slider.value = p;
    }
}
