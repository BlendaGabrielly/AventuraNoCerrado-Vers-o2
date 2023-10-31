using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMov : MonoBehaviour
{
    private AudioSource sound;
    private Rigidbody2D corpoPers;
    private Animator anim;
    private SpriteRenderer spritRend;

    public GameObject projectilePrefab;
    public float shotForce = 1000.0f;

   // public Camera cam;
   public Camera cam;

    [SerializeField] private float movHorizontal;
    [SerializeField] private float velocidadeMov=8f;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float velobat=4f;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool segundoPulo, conta_pulo;
    [SerializeField] private int vidasAtual ;
    int quantidadeCajus = 0;

    private bool estaPulando;
    public Cenario cen;
    public float velocidadeNormal=8f;


    void Start()
    {
        corpoPers = GetComponent<Rigidbody2D>();
        Cenario cen = GetComponent<Cenario>();
        anim = GetComponent<Animator>();
        spritRend = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType(typeof(Camera))as Camera;
        sound = GetComponent<AudioSource>();

        vidasAtual = 3;

        velocidadeMov = 10;
        forcaPulo = 15;
    }
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        Movimento();
        Pulo();
        atirar();
    }
    private void Movimento(){
      corpoPers.velocity = new Vector3(movHorizontal * velocidadeMov, corpoPers.velocity.y);
        if (movHorizontal > 0 ){
            spritRend.flipX = false;
            anim.SetBool("Correndo", true);
        }
        else if(movHorizontal < 0 ){
            spritRend.flipX = true;
            anim.SetBool("Correndo", true);
        }
        else if (movHorizontal == 0)
        {
            anim.SetBool("Correndo", false);
        }
    }
    private void Pulo(){   

        if (Input.GetButtonDown("Jump")){

            if (!estaPulando) {
                corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
                estaPulando = true;
            }
            if (segundoPulo)
            {
                corpoPers.AddForce(new Vector2(0f, (forcaPulo/2)), ForceMode2D.Impulse);
                segundoPulo = false;
            }
        }
    }

    void bufferDePulo(){
        if (conta_pulo){
            corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
            conta_pulo = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            //Debug.Log("Bati no chão");
            estaPulando = false;
            bufferDePulo();

        }if (collision.gameObject.tag == "Enemy"){
            //Destroy(gameObject);
            GameController.insta.ShowGameOver();
            sound.Play();
            //Destroy(collision.gameObject);
        }
         if(collision.gameObject.tag== "Lago"){
         GameController.insta.ShowGameOver();
         sound.Play();
         //Destroy(gameObject);
        } 

    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            segundoPulo = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    { 
        if(collider.gameObject.tag=="Arbusto"){
              velocidadeMov =velobat;
              cam.ShakeIt();
              InvokeRepeating("retorno",0.2f,0.1f );
             //Enemy.tt.Onça_tronco();

           }      
    
        if(collider.gameObject.tag=="Caju"){
           quantidadeCajus = quantidadeCajus + 1;

            velocidadeMov += 6;
            InvokeRepeating("reverterRetorno", 0.5f, 0.1f);

            Enemy.tt.Onça_Caju();
            Debug.Log("pegou caju: " + quantidadeCajus);


            if (quantidadeCajus > 2 && velocidadeMov==8f)
            {
                Debug.Log("pegou caju, entrou no if");
                retorno();
                quantidadeCajus = 0;
            }
            
        }
        if(collider.gameObject.tag=="ultima"){
          cen.DelayedRecycle();
        }
    }

    void retorno()
{
    if (velocidadeMov < velocidadeNormal)
    {
        velocidadeMov += 2;
    }
    else
    {
        // Se a velocidade já atingiu a velocidade normal, paramos de invocar a função "retorno"
        velocidadeMov = velocidadeNormal;
        CancelInvoke("retorno");
    }
}
void reverterRetorno(){
    if (velocidadeMov > velocidadeNormal)
    {
        velocidadeMov -= 1;
    }
    else
    {
        velocidadeMov = velocidadeNormal; // Certifique-se de definir a velocidade para o valor normal
        CancelInvoke("reverterRetorno");
    }
}


    void atirar(){
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
}   
}


  



