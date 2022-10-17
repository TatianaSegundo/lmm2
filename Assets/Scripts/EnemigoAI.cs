using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemigoAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
     int currentWaypoint = 0;
     bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    public float PuntosVidaE;  //Conteo de vida
    public float VidaMaximaE = 4;  //Vida maxima
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        seeker.StartPath(rb.position, target.position, OnPathComplete);
        InvokeRepeating("UpdatePath",0f,.5f);

                PuntosVidaE = VidaMaximaE;
    }
void UpdatePath()
{
    if (seeker.IsDone())
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
}

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0; //reiniciar el progreso del path
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else{
        reachedEndOfPath = false;
    }

    Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position). normalized;
    Vector2 force = direction * speed * Time.deltaTime;
    
    rb.AddForce(force);

    float distance = Vector2.Distance (rb.position, path.vectorPath[currentWaypoint]);

    if(distance < nextWaypointDistance)
    {
        currentWaypoint++;
    }
}
#region 
    public void TakeHit(float golpe)
    {
        PuntosVidaE -= golpe;
        if(PuntosVidaE <= 0 )
        {
            Destroy(gameObject);
        }
    }
#endregion
}
