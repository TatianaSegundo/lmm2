/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoPrueba1millon : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform Personaje;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Personaje.position) > stoppingDistance);
        {
            transform.position = Vector2.MoveTowards(transform.position, Personaje.position, speed * Time.deltaTime);
      
        } 
        else if(Vector2.Distance(transform.position, Personaje.position) < stoppingDistance && Vector2.Distance(transform.position, Personaje.position) < retreatDistance)
        {
            transform.position = this.transform.position;
        
        } 
        else if(Vector2.Distance(transform.position, Personaje.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Personaje.position, -speed * Time.deltaTime);
        }
    }
}
 */