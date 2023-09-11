using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawFrutas : MonoBehaviour
{
    public GameObject fruitPrefab; // Prefab da fruta
    public float spawnInterval = 5f; // Intervalo de tempo entre gerações de frutas (por exemplo, 5 segundos)
    public int maxFruits = 1; // Número máximo de frutas permitidas em cena ao mesmo tempo
    public Transform player; // Referência ao objeto do personagem

    private float timer = 6f;
    private int currentFruitCount = 0;

    private void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        if (currentFruitCount < maxFruits)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnFruit();
                timer = spawnInterval;
            }
        }
    }

    void SpawnFruit()
    {
        // Verifique a posição atual do jogador
        Vector3 playerPosition = player.position;
        // Calcule uma posição aleatória a uma distância de 5 unidades do jogador
        Vector3 spawnPosition = playerPosition + Random.onUnitSphere * 5f;
        spawnPosition.z = 0f; // Certifique-se de que a fruta está na mesma camada Z que o jogador

        // Crie a fruta na posição calculada
        Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);

        currentFruitCount++;
    }
}
