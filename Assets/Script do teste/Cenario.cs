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
        Initialize(); // Quando o jogo começa, executa a função Initialize.
    }

    void Initialize()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            for (int i = 0; i < platforms.Count; i++)
            {
                Transform p = Instantiate(platforms[i], new Vector3(i * 52, 0, 0), transform.rotation).transform;
                currentPlat.Add(p);
                offset += 52;
            }

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
        if (player != null && currentPlatsPoint != null)
        {
            float distance = player.position.x - currentPlatsPoint.position.x;

            if (distance >= 5)
            {
                if (!currentPlat[plataformaIndex].GetComponent<PointE>().passedByPlayer)
                {
                    currentPlat[plataformaIndex].GetComponent<PointE>().passedByPlayer = true;
                    StartCoroutine(DelayRecycle(currentPlat[plataformaIndex].gameObject));
                }

                plataformaIndex++;
                if (plataformaIndex > currentPlat.Count - 1)
                {
                    plataformaIndex = 0;
                }

                currentPlatsPoint = currentPlat[plataformaIndex].GetComponent<PointE>().point;
            }
        }
    }

    IEnumerator DelayRecycle(GameObject platform)
    {
        yield return new WaitForSeconds(3f); // Espera por 3 segundos
        Recycle(platform);
        platform.GetComponent<PointE>().passedByPlayer = false; // Reseta o marcador após reciclar a plataforma
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector3(offset, 0, 0);
        offset += 52;
    }
}
