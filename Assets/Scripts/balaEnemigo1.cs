using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemigo1 : MonoBehaviour
{
    public GameObject objectToFind;
    public float hit = 1;
public float speed = 3.0f; //variable velocidad bala
public Transform PuntoDisparo;
//la bala toca a otro enemigo
GameObject[] enemigo1;

//private List<GameObject> pool = new List<GameObject>();

void Start()
    {
       enemigo1 = GameObject.FindGameObjectsWithTag("enemigo1");
       //Invoke("Destruir_",2);
        //si la bala no colisiona, no importa, porque se destruye en dos segundos
    }
void Update(){ //solo necesitamos que se ejecute cuando se acciona
    transform.position += transform.right * Time.deltaTime * speed; //el objeto(bala) inicia hacia a la izquierda porque el enemigo aparece mirando hacia ahi

}
   private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<PlayerControler>();
        if (collision.gameObject.tag == "enemigo1") {
            Destroy(this.gameObject);

        }   
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
            private void OnCollisionExit2D (Collision2D collision) { 
        if (collision.gameObject.tag == "enemigo1") {
           transform.parent = null;

        }
    }
    /* public GameObject GetBala()
    {
        for(int i = 0; i< pool.Count; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(bullet) as GameObject;
        pool.Add(obj);
        return obj;
    } */
  // void Destruir_()
   // {
   //     Destroy(this.gameObject); //destruye el objeto de este script(la bala)
   // }

}

