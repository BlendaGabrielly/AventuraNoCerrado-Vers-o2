using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioTeste : MonoBehaviour
{
     public GameObject game;
    public GameObject game1;
    public GameObject game2;
    public GameObject game3;
    public GameObject game4; // cenário
     private bool isActivatingPlatforms = false;
    public List<GameObject> platforms = new List<GameObject>(); // Lista de prefabs de plataformas
    public List<Transform> currentPlat = new List<Transform>(); // Lista de instâncias de plataformas
    public int offset; // Deslocamento entre plataformas
    
    bool isScenarioActivated = false;
     public GameObject myplat; // <--- Adicione esta linha

    private Transform player; // Referência ao objeto do jogador
    private Transform currentPlatsPoint; // Ponto de referência da plataforma atual
    public int plataformaIndex; // Índice da plataforma atual
    // Start is called before the first frame update
    void Start()
    {
        // Verifica se o objeto do jogador está presente na cena
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
                // Chama o método ActivateScenario após 10 segundos
                //Invoke("ActivateScenario", 10f);
                InvokeRepeating("ActivateScenario", 10f, 10f);

             // Chama o método RecyclePlat a cada 5 segundos, começando depois de 15 segundos
             //InvokeRepeating("RecyclePlat", 15f, 5f);
        }
    }
     void ActivateScenario()
    {
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

        isScenarioActivated = true;
    }
     void ActivatePlatforms()
    {
        if (isActivatingPlatforms) return;

        StartCoroutine(ActivatePlatformsWithDelay());
    }
     IEnumerator ActivatePlatformsWithDelay()
    {
        isActivatingPlatforms = true;

        foreach (GameObject platformPrefab in platforms)
        {
            Transform p = Instantiate(platformPrefab, new Vector3(offset, 0, 0), transform.rotation).transform;
            currentPlat.Add(p);
            offset += 52;

            yield return new WaitForSeconds(1f); // Intervalo de 1 segundo entre as instâncias
        }

        isActivatingPlatforms = false;
    }
    void Update()
    {
        // Verifica se o cenário está ativado antes de atualizar
        if (!isScenarioActivated)
            return;


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


void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(offset, 0, 0);
        offset += 52;
    }
}


