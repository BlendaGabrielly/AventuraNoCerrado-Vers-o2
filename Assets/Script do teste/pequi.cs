using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pequi : MonoBehaviour
{
   ///List<GameObject> pequis = new List<GameObject>();
  // private SpriteRenderer spritRend;
   // public float shotForce = 1000.0f;
  // public GameObject projectilePrefab;

    private SpriteRenderer sr; // Componente de renderização do objeto
    private CircleCollider2D circle; // Componente de colisão circular
    // Start is called before the first frame update
   public GameObject collected;

    public int Score;
    
    private AudioSource sound;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // Obtém o componente SpriteRenderer do objeto
        sr.enabled = true; // Garante que o SpriteRenderer está ativado
        sound = GetComponent<AudioSource>();
        circle = GetComponent<CircleCollider2D>(); // Obtém o componente CircleCollider2D do objeto
       // spritRend = GetComponent<SpriteRenderer>();
        InvokeRepeating("Sprite", 5f, 5f); // Chama o método Sprite a cada 5 segundos
    }

    // Update is called once per frame
    void Update()
    {
       // atirar(); // Adicionando a chamada da função atirar() no Update
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
           
           // Controller.insta.TotalScore += Score;
            //Controller.insta.UpdateScoreText();
            //pequis.Add(gameObject);
            sound.Play();
        }
    }
    /* void atirar(){
        if (Input.GetKeyDown(KeyCode.T)){
          Shoot();
      }
    }
   void Shoot()
{
    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

    Vector2 direction = spritRend.flipX ? Vector2.left : Vector2.right; // Verifica se o jogador está virado para a esquerda ou direita
    rb.AddForce(direction * shotForce);
}*/

    void Sprite()
    {
         sr.enabled = true;
         circle.enabled = true;
    }
}
