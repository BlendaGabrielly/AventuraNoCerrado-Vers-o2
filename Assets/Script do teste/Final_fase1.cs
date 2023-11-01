using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_fase1 : MonoBehaviour
{    public GameObject Fim;
    private int contadorColisoes = 0;

    void Start()
    {
        // Código que é executado no início do jogo
    }

    void Update()
    {
        // Código que é executado a cada quadro (frame)
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            contadorColisoes+=1;
            Debug.Log("entou no collision");
            
            if(contadorColisoes > 1)
            {
                Debug.Log("entou no IF");
                Fim.SetActive(true);
            }
        }
    }
}
