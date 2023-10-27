using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
       public Camera cam;
        private AudioSource sound;
        [SerializeField] private float velocidadeMov=8f;
        [SerializeField] private float velobat=2f;
    void Start()
    {
     cam = FindObjectOfType(typeof(Camera))as Camera;
     sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D collider)
    { 
         if(collider.gameObject.tag=="Player"){
              velocidadeMov =velobat;
              cam.ShakeIt();
              sound.Play();
              Invoke("retorno", 2f);
              
          }
    }
     void retorno(){
           velocidadeMov=8f;
        }     
}
