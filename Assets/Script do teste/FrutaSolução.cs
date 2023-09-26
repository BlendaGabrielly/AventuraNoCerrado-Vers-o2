using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaSolução : MonoBehaviour
{
    private SpriteRenderer sr; // Componente de renderização do objeto
    private CircleCollider2D circle; // Componente de colisão circular
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // Obtém o componente SpriteRenderer do objeto
        sr.enabled = true; // Garante que o SpriteRenderer está ativado
        circle = GetComponent<CircleCollider2D>(); // Obtém o componente CircleCollider2D do objeto
        InvokeRepeating("Sprite", 5f, 5f); // Chama o método Sprite a cada 5 segundos
    }

    // Update is called once per frame
    void Update()
    {
       // Invoke("Sprite", 10f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Quando o objeto colide com outro objeto que possui a tag "Player"
            sr.enabled = false; // Desativa o componente SpriteRenderer (torna o objeto invisível)
            circle.enabled = false; // Desativa o componente CircleCollider2D (desativa colisões)
           // Destroy(gameObject, 0.30f); // Destroi o objeto atual após 0.25 segundos
        }
    }
    void Sprite(){
         sr.enabled = true; // Desativa o componente SpriteRenderer (torna o objeto invisível)
         circle.enabled = true;
    }
}
