using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public static GameController insta;
    private bool isPaused = false;
    public AudioSource audioSource;
    private bool isCardActive = true;
    public GameObject caju;
    


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
         insta=this;
    }

    void Update()
    {
        
    }
   public void ShowGameOver(){
     gameOver.SetActive(true);
     Pause();
   }
    public void Restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     Debug.Log("Clicavel");
     Continuar();
     caju.SetActive(false);
     
  }

    void Pause(){
        isPaused = true;
        Time.timeScale = 0f;
         audioSource.Pause(); 
    }
       public void Continuar(){
        isPaused = false;
        Time.timeScale = 1f;
    }
}
