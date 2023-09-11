using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    public GameObject frutaPrefab; // Referência para o objeto da fruta que você deseja spawnar
    public Transform personagem; // Referência para o objeto do personagem
    public Transform spawnPoint; // Referência para o ponto de spawn das frutas
    
    void Update()
    {
         
        if (Input.GetKeyDown(KeyCode.Space)) // Pode usar outra condição de sua escolha
     {
            SpawnFrutaNaFrenteDoPersonagem();
        }
    }
      void SpawnFrutaNaFrenteDoPersonagem()
    {
        // Defina a posição de spawn da fruta com base na posição do personagem
        Vector3 spawnPosition = personagem.position + spawnPoint.position;

        // Realize o spawn da fruta na posição calculada
        Instantiate(frutaPrefab, spawnPosition, Quaternion.identity);
    }
}
