using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    private Text timeHolder;
    private float levelStartTime;
    private float levelCurrentTime;
    void Start()
    {
        levelStartTime = Time.time;
        timeHolder = GetComponent<Text>();
    }


    void Update()
    {
        levelCurrentTime = Time.time - levelStartTime;
        timeHolder.text = Mathf.Round(levelCurrentTime).ToString();
    }
}
