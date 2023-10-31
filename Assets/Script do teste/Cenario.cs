using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenario : MonoBehaviour
{
    // Referências para objetos do cenário
    public GameObject game;
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public GameObject game4; // cenário
    public List<GameObject> platforms = new List<GameObject>(); // Lista de prefabs de plataformas
    public List<Transform> currentPlat = new List<Transform>(); // Lista de instâncias de plataformas
    public int offset; // Deslocamento entre plataformas

    private Transform player; // Referência ao objeto do jogador
    private Transform currentPlatsPoint; // Ponto de referência da plataforma atual
    public int plataformaIndex; // Índice da plataforma atual

    void Start()
    {
         
        // Verifica se o objeto do jogador está presente na cena
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            // Instancia as plataformas e adiciona-as à lista, criando um deslocamento entre elas
            for (int i = 0; i < platforms.Count; i++)
            {
                Transform p = Instantiate(platforms[i], new Vector3(i * 52, 0, 0), transform.rotation).transform;
                currentPlat.Add(p);
                offset += 52;
            }

            // Desativa objetos do cenário (game, game1, game2) e define o ponto de referência da plataforma inicial
            game.SetActive(false);
            game1.SetActive(false);
            game2.SetActive(false);
            game3.SetActive(false);
            game4.SetActive(false);
            currentPlatsPoint = currentPlat[plataformaIndex].GetComponent<PointE>().point;
        }
    }

    public GameObject myplat; // Referência à plataforma do jogador

    void Update()
    {
        

        // Calcula a distância entre a posição do jogador e o ponto de referência da plataforma atual
        float distance = player.position.x - currentPlatsPoint.position.x;

        // Verifica se o jogador se moveu o suficiente para reciclar a plataforma atual
        if (distance >= 5)
        {
            // Recicla a plataforma atual, incrementa o índice e atualiza o ponto de referência da próxima plataforma
            Recycle(currentPlat[plataformaIndex].gameObject);
            plataformaIndex++;
            if (plataformaIndex > currentPlat.Count - 1)
            {
                plataformaIndex = 0;
            }

            currentPlatsPoint = currentPlat[plataformaIndex].GetComponent<PointE>().point;
        }
    }
    public void DelayedRecycle()
{
    Invoke("Recycle", 60f);
    Debug.Log("DelayedRecycle chamado");
}

//public void RecycleFirstPlatform()
//{
   // Recycle(currentPlat[0].gameObject);
//}


    // Reposiciona a plataforma passada como argumento e atualiza o deslocamento
    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(offset, 0, 0);
        offset += 52;
    }


}

