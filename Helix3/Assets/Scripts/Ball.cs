using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Ball ins;
    public GameOver gameover;
    public TapToStart TapToStartt;
    public bool perfectStar;
    private static float z;
    private static Color currentColor;
    private MeshRenderer meshRenderer;
    private static int score;
    private float height = 0.58f, speed = 7;
    private bool move, isRising, gameOver, displayed;
    private float lerpAmount;
    private AudioSource failSound, hitSound, levelComplete;
    void Awake()
    {
        if (ins != null)
        {
            ins = null;
        }
        failSound = GameObject.Find("FailSound").GetComponent<AudioSource>();
        hitSound = GameObject.Find("HitSound").GetComponent<AudioSource>();
        levelComplete = GameObject.Find("LCS").GetComponent<AudioSource>();
        TapToStartt.EnableText();
        meshRenderer = GameObject.FindGameObjectWithTag("Ball").GetComponent<MeshRenderer>();
    }
    void Start()
    {
        gameover.DisableText();
        move = false;
        SetColor(GameController.instance.hitColor);
        PlayerPrefs.SetInt("Score", 0);
    }
    void Update()
    {
        
        if (TouchButton.IsPressing() && !gameOver)
        {
            move = true;
            GetComponent<SphereCollider>().enabled = true;

        }
        if (move)
        {
            TapToStartt.DisableText();
            if (Time.deltaTime != 0)
            {
                Ball.z += speed * 0.028f + PlayerPrefs.GetInt("Level") / 800;
            }
        }
        transform.position = new Vector3(0, height, Ball.z);
        displayed = false;
        UpdateColor();
    }
    void UpdateColor()
    {
        meshRenderer.sharedMaterial.color = currentColor;
        if (isRising)
        {
            currentColor = Color.Lerp(meshRenderer.material.color, GameObject.FindGameObjectWithTag("ColorBump").GetComponent<ColorBump>().GetColor(), lerpAmount);
            lerpAmount += Time.deltaTime;
        }
        if (lerpAmount >= 1)
            isRising = false;
    }
    public static int GetScore()
    {
        return score;
    }
    public static void SetScore(int s)
    {
        score = s;
    }
    public static float GetZ()
    {
        return Ball.z;
    }
    public static Color SetColor(Color color)
    {
        return currentColor = color;
    }
    public static Color GetColor()
    {
        return currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hit")
        {
            if (perfectStar && !displayed)
            {
                displayed = true;
                GameObject pointDisplay = Instantiate(Resources.Load("PointDisplay"), transform.position, Quaternion.identity) as GameObject;
                pointDisplay.GetComponent<PointDisplay>().SetText("Point + 1 " );
                score += 1;
            }
            else if (!perfectStar && !displayed)
            {
                displayed = true;
                GameObject pointDisplay = Instantiate(Resources.Load("PointDisplay"), transform.position, Quaternion.identity) as GameObject;
                pointDisplay.GetComponent<PointDisplay>().SetText("+ 1" );
                score += 1;
            }
            hitSound.Play();
            Destroy(other.transform.parent.gameObject);
        }
        if (other.tag == "ColorBump")
        {
            lerpAmount = 0;
            isRising = true;
            speed += 1;
        }
        if (other.CompareTag("Fail"))
        {
            StartCoroutine(GameOver());
        }
        if (other.CompareTag("FinishLine"))
        {
            StartCoroutine(PlayNewLevel());
        }
        if (other.tag == "star")
        {
            perfectStar = true;
        }
    }

    IEnumerator PlayNewLevel()
    {
        speed += 0.5f;
        levelComplete.Play();

        Camera.main.GetComponent<CameraFollow>().enabled = false;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        yield return new WaitForSeconds(1.5f);
        Camera.main.GetComponent<CameraFollow>().Flash();
        TapToStartt.EnableText();
        move = false;
        Ball.z = 0;
        GameController.instance.GenerateLevel();
        Camera.main.GetComponent<CameraFollow>().enabled = true;
    }
    IEnumerator GameOver()
    {
        
        if(Score.instance!=null)
            Score.instance.setScore(0);
        score = 0;
        failSound.Play();
        gameOver = true;
        meshRenderer.enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        move = false;
        yield return new WaitForSeconds(1.5f);
        Camera.main.GetComponent<CameraFollow>().Flash();
        gameOver = false;
        z = 0;
        GameController.instance.GenerateLevel();
        meshRenderer.enabled = true;
    }
}