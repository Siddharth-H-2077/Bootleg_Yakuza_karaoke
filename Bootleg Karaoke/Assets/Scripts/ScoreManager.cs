using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerInstance = this;
        comboScore = 0; 
    }

    public static void Hit()
    {
        comboScore += 1;
        scoreManagerInstance.hitSFX.Play();
    }
    public static void Miss()
    {
        comboScore = 0;
        scoreManagerInstance.missSFX.Play();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = comboScore.ToString();        
    }
}
