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
      Speed+=8f;
       Invoke("RestaurarSpeed", 1f);
     }
    public void tronco(){
      Speed+=12;

      Invoke("Retarda", 4f);
      Invoke("RestaurarSpeed", 5f);

    }
   private void RestaurarSpeed(){
    Speed = 4f;
}
  private void Retarda(){
    Speed -= 2f;
}
  
     
}


