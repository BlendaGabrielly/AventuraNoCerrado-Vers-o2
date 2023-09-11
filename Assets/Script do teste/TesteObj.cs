using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteObj : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab do objeto que será instanciado
    public Vector3 limiteMin; // Limite mínimo para a posição de spawn
    public Vector3 limiteMax; // Limite máximo para a posição de spawn
    public Transform frutaSpawnPoint; // Ponto onde as frutas aparecerão
    private SpriteRenderer sr; // Componente de renderização do objeto
    private CircleCollider2D circle; // Componente de colisão circular

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // Obtém o componente SpriteRenderer do objeto
        sr.enabled = true; // Garante que o SpriteRenderer está ativado
        circle = GetComponent<CircleCollider2D>(); // Obtém o componente CircleCollider2D do objeto
        Invoke("InstanciarObjeto", 4f); // Chama a função InstanciarObjeto após 1 segundo
    }

    private void Update()
    {
       
    }

    void InstanciarObjeto()
    {
        // Obtém a posição atual do personagem no eixo X
        float posicaoPersonagemX = frutaSpawnPoint.position.x;

        // Calcula uma nova posição de spawn aleatória dentro dos limites especificados
        Vector3 posicaoAleatoria = new Vector3(
            posicaoPersonagemX, // Usamos a posição atual do personagem no eixo X
            Random.Range(limiteMin.y, limiteMax.y),
            Random.Range(limiteMin.z, limiteMax.z));

        // Instancia um objeto a partir do prefab, na posição calculada e com rotação padrão (Quaternion.identity)
        Instantiate(objetoPrefab, posicaoAleatoria, Quaternion.identity);

        // Destroi o objeto instanciado após 30 segundos
        Destroy(objetoPrefab, 30f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // Quando o objeto colide com outro objeto que possui a tag "Player"
            sr.enabled = false; // Desativa o componente SpriteRenderer (torna o objeto invisível)
            circle.enabled = false; // Desativa o componente CircleCollider2D (desativa colisões)
            Destroy(gameObject, 0.30f); // Destroi o objeto atual após 0.25 segundos
        }
    }
}
