using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour
{
    public GameObject[] historia;
    int index;
    public string lvlName; 
    public GameObject card;
    void Start()
    {
        index=0;
    }
    void Update()
    {
       if(index>=14){
            index = 14;
            startGame();
    }
       if(index<0){
            index = 0;
       
       }
       if(index==0){

          historia[0].SetActive(true);
       }
    }
 public void Next()
{
    if (index < historia.Length - 1)
    {
        historia[index].SetActive(false);
        index += 1;
        historia[index].SetActive(true);
    }
    else
    {
        startGame();
    }
}

public void Previous()
{
    if (index > 0)
    {
        historia[index].SetActive(false);
        index -= 1;
        historia[index].SetActive(true);
    }
}


    public void startGame()
    {
        SceneManager.LoadScene("Fase 1");
        //card.SetActive(true);
    }




}
