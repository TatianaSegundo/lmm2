using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoEnemigo1 : MonoBehaviour
{
    //este script acciona la bala
    public balaEnemigo1 LaBala;
    public Transform PuntoDisparo;

    public float tiempoDisparoE;
    public float tiempoParaDisparar;
        GameObject[] balaEnemigo;
void Start(){
    balaEnemigo = GameObject.FindGameObjectsWithTag("balaEnemigo");
}

    // Update is called once per frame
    void Update()
    {
        tiempoDisparoE += Time.deltaTime;

        if (tiempoDisparoE >= tiempoParaDisparar)
    {
        /* GameObject obj = GetBala();
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation; */
        Instantiate(LaBala, PuntoDisparo.position, transform.rotation);
        tiempoDisparoE = 0;
        
        
    }
    }
}
