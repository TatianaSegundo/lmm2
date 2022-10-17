using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovimientoEnemigo2 : MonoBehaviour
{

    public AIPath aiPath;

    void Update()
    {
        //Flip según la velocidad
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
           transform.localScale = new Vector3 (1f, 1f,1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
             transform.localScale = new Vector3 (-1f, 1f,1f);
        }
    }
/*     private Animator anim;

    private void Awake()
    {
      anim = GetComponent<Animator>();
    }
    if()
    {
        set.SetTrigger("enemigo2_caminando");
    } */
}
