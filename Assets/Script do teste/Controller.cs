using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Controller : MonoBehaviour
{
    public int TotalScore;
    public Text score;
    public static Controller insta;
    void Start()
    {
       insta=this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void UpdateScoreText(){

        score.text = TotalScore.ToString();
    }
}
