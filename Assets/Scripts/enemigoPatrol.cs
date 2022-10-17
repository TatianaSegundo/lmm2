using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [Header("Enemigo")]
    [SerializeField] private Transform enemy;
    [Header("Parametros movimiento")]
    [SerializeField] private float velocidad;
    private bool movingLeft;
    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void MoveInDirection (int _direction)
    {
       //Hace la direccion del enemigo
       enemy.localScale = new Vector3( Mathf.Abs (initScale.x) * _direction, initScale.y, initScale.z);
       //Lo mueve en esa direccion
       enemy.position = new Vector3 (enemy.position.x + Time.deltaTime * _direction * velocidad, enemy.position.y, enemy.position.z);
gameObject.GetComponent <Animator>().SetBool("enemyWalk", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
              MoveInDirection(-1);
            }
            else
            {
                //Change direction
                DirectionChange();
            }
            }
          
        else
        {
            if(enemy.position.x >= rightEdge.position.x)
            {
                 MoveInDirection(1);
            } 
            else
            {
                //Change direction
                DirectionChange();
            }
            
        }
       
    }
    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }
}
