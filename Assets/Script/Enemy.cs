using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float Speed;
 private Transform Target;

    private BoxCollider2D Onca, madeiraCollider;
    public static Enemy tt;
  
 
    void Start()
    {
      tt=this;
      

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position=Vector3.MoveTowards(transform.position,Target.position,Speed*Time.deltaTime);
    }
     void OnCollisionEnter2D(Collision2D collision){


       /* if (collision.gameObject.tag == "Player") {
            GameController.insta.ShowGameOver();
           // Destroy(gameObject);
            Destroy(collision.gameObject);
        }*/
     }
     public void Onça_Caju(){
      Speed+=5f;
       Invoke("RestaurarSpeed", 0.4f);
     }
    public void tronco(){
      Speed+=15f;

      Invoke("Retarda", 2f);
      Invoke("RestaurarSpeed", 7f);

    }
   private void RestaurarSpeed(){
    Speed = 4f;
}
  private void Retarda(){
    Speed -= 2f;
}
  
     
}


