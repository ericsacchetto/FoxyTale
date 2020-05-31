using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeBlack;
    private bool shouldFadeTransparent;

    public GameObject levelInfoPanel;
    public Text levelName;

    public Text gemsFound;
    public Text gemsTarget;
    public Text bestTime;
    public Text timeTarget;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeTransparent();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeBlack = false;
            }
        }

        if (shouldFadeTransparent)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeTransparent = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeBlack = true;
        shouldFadeTransparent = false;
    }

    public void FadeTransparent()
    {
        shouldFadeBlack = false;
        shouldFadeTransparent = true;
    }

    public void ShowInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;

        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTarget.text = "OFF: " + levelInfo.totalGems;
        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";
        
        if(levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ----";
        } else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F0") + "s";
        }


        levelInfoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }
}
