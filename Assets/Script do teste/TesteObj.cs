using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteObj : MonoBehaviour
{
    public GameObject objetoPrefab;
    public Vector3 limiteMin;
    public Vector3 limiteMax;
    public Transform frutaSpawnPoint; // Ponto onde as frutas aparecerão
    private SpriteRenderer sr;
    private CircleCollider2D circle;
  

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        circle = GetComponent<CircleCollider2D>();
        Invoke("InstanciarObjeto", 1f);
      
    }
     private void Update()
    {
    }

   void InstanciarObjeto()
{
    // Calcula a nova posição de spawn aleatória com base no frutaSpawnPoint como mínimo
    Vector3 posicaoAleatoria = new Vector3(
        Random.Range(frutaSpawnPoint.position.x, limiteMax.x),
        Random.Range(limiteMin.y, limiteMax.y),
        Random.Range(limiteMin.z, limiteMax.z));
    Instantiate(objetoPrefab, posicaoAleatoria, Quaternion.identity);
    Destroy(objetoPrefab, 30f);
}


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //if(collider.gameObject<2)
            sr.enabled = false;
            circle.enabled = false;
            Destroy(gameObject, 0.25f);
            
        }
    }
}