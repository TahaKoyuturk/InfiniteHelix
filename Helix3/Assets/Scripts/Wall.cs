using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private GameObject wallFragment;
    private GameObject perfectStar;
    private GameObject wall1, wall2;

    private float rotationZ;
    private float rotationZmax = 180;

    private bool smallWall;

    void Awake()
    {
        wallFragment = Resources.Load("WallF") as GameObject;
        perfectStar = Resources.Load("PerfectStar") as GameObject;
    }
    void Start()
    {
        SpawnWallFragments();
    }
    void SpawnWallFragments()
    {
        wall1 = new GameObject();
        wall2 = new GameObject();

        wall1.name = "Wall1";
        wall2.name = "Wall2";

        wall1.tag = "Wall1";
        wall2.tag = "Fail";


        wall1.transform.SetParent(transform);
        wall2.transform.SetParent(transform);

       
        wall2.AddComponent<BoxCollider>();
        wall2.GetComponent<BoxCollider>().size = new Vector3(0.98f, 2.05f, 0.58f);
        wall2.GetComponent<BoxCollider>().center = new Vector3(0.55f,0.005f,0.2f);

        if (Random.value <= 0.2 && PlayerPrefs.GetInt("Level") >= 3)
        {
            smallWall = true;
        }
        if (smallWall)
        {
            rotationZmax = 90;
        }
        else
        {
            rotationZmax = 180;
        }
        for (int i = 0; i < 100; ++i)
        {
            GameObject WallF = Instantiate(wallFragment, Vector3.zero, Quaternion.Euler(0, 0, rotationZ));
            rotationZ += 3.6f;

            if (rotationZ <= rotationZmax)
            {
                WallF.transform.SetParent(wall1.transform);
                WallF.gameObject.tag = "Hit";
            }
            else
            {
                WallF.transform.SetParent(wall2.transform);
            }
        }

        wall1.transform.localPosition = Vector3.zero;
        wall2.transform.localPosition = Vector3.zero;


        wall1.transform.localRotation = Quaternion.Euler(Vector3.zero);
        wall2.transform.localRotation = Quaternion.Euler(Vector3.zero);

        if (!smallWall){
            GameObject wallFragmentChild = wall1.transform.GetChild(25).gameObject;
            AddStar(wallFragmentChild);
        }
        else{
            GameObject wallFragmentChild = wall1.transform.GetChild(14).gameObject;
            AddStar(wallFragmentChild);
        } 
    }
    void AddStar(GameObject wallFragmentChild)
    {
        GameObject star = Instantiate(perfectStar, transform.position, Quaternion.identity);
        star.transform.SetParent(wallFragmentChild.transform);
        star.transform.localPosition = new Vector3(0.05f, 0.75f, -0.06f);
    }

}
