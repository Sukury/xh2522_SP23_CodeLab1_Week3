using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.WSA;
using Application = UnityEngine.Application;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public int currentLevel = 0;
    public int targetScore = 3;
    public TextMeshPro TextMeshPro;
    private int highScore = 0;
    
    private const string Directory_Data = "/Data/";
    private const string File_High_Score = "highScore.txt";
    private string Path_High_Score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            if (score>HighScore)
            {
                HighScore = score;
            }
        }
        
    }

    
    public int HighScore
    {
        get
        {
            return highScore;
            
        }
        set
        {
            highScore = value;
            File.WriteAllText(Path_High_Score,""+highScore);
            Directory.CreateDirectory(Application.dataPath + Directory_Data);
        }
    }


    private void Awake()
    {
        if (Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //Debug.Log(Application.dataPath+Directory_Data);
    }

    // Start is called before the first frame update
    void Start()
    {
        Path_High_Score = Application.dataPath + Directory_Data + File_High_Score;
        highScore=Int32.Parse(File.ReadAllText(Path_High_Score));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            File.Delete(Path_High_Score);
            if (File.Exists(Path_High_Score))
            {
                HighScore=Int32.Parse(File.ReadAllText(Path_High_Score));
            }
        }
        
        TextMeshPro.text=
            "LEVEL:" + (currentLevel + 1) + "\n" +
            "SCORE:" + score + "\n" +
            "HIGH SCORE:" + HighScore;
        
        if (score==targetScore)
        {
            currentLevel++;
            targetScore = targetScore * 3;
            SceneManager.LoadScene(currentLevel);
        }
    }
}
