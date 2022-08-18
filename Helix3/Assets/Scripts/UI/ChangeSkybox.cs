using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material[] skyMaterial;
    void Awake()
    {
        float randomNumber = Random.Range(0, 9);
        RenderSettings.skybox = skyMaterial[(int)randomNumber];
    }

  
    public void ChangeSkyboxMaterial()
    {
        float randomNumber = Random.Range(0, 9);
        RenderSettings.skybox = skyMaterial[(int)randomNumber];
    }
}
