using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    //Movimiento
    public Transform player_pos;
    public float velocidad;
    public float distancia_frenado;
    public float distancia_regreso;
    
    //Vida enemigo
    public float PuntosVidaE;  //Conteo de vida
    public float VidaMaximaE = 4;  //Vida maxima
 //Salto
/*     public float velSaltar = 3;
    Rigidbody2D rb2D; */
/*     //Salto

    float dirX;
    [SerializeField]
    float moveSpeed =3.0f;
    Rigidbody2D rb;
    bool facingRight = false;
    Vector3 localScale;
/*  */
 //private float tiempo;  
   /*  //Disparo
    public Transform punto_instancia;
    public GameObject bala;
   private float tiempo;  //tiempo transcurrido desde el ultimo disparo*/
    /*
   public float walkSpeed;
   [HideInInspector]
   public bool mustPatrol;
   public Rigidbody2D rb;
    */
    // Start is called before the first frame update
    void Start()
    {
        player_pos = GameObject.Find("Personaje").transform; //accede a la posicion de Mako
    //  mustPatrol = true;
        //this.transform.localScale = new Vector2(-3,3);
         this.transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0); //QUITAR CUANDO SE ARREGLE EL SPRITE
        PuntosVidaE = VidaMaximaE;
/*         //////Salto
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1.0f; */
    }

    // Update is called once per frame
    void Update()
    {
        if (player_pos == null) { // cuando muere el personaje que deja de ejecutarse el codigo de seguimiento
         return;
        }
/*         //////SALTO
        if(transform.position.x < -9f)
        {
            dirX = 1.0f;

        }
        else if (transform.position.x > 9f)
        {
            dirX = -1f;
        }
         /* */
      //COMPORTAMIENTO ENEMIGO - MOVIMIENTO
        //Para separar funcionalidades, a medida que el codigo se hace muy extenso usa region
#region
        if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado)
        {
        transform.position = Vector2.MoveTowards(transform.position, player_pos.position, velocidad*Time.deltaTime);// que traslade su posicion hacia Mako
        gameObject.GetComponent <Animator>().SetBool("enemy2Walk", true);
        
         }
         if(Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
        transform.position = Vector2.MoveTowards(transform.position, player_pos.position, -velocidad*Time.deltaTime);// que traslade su posicion hacia atras cuando Mako este muy cerca --- al restarle a velocidad, va hacia atras
        gameObject.GetComponent <Animator>().SetBool("enemy2Walk", true);
        

         } 
         if(Vector2.Distance(transform.position, player_pos.position)>distancia_frenado && Vector2.Distance(transform.position, player_pos.position)<distancia_regreso)
        {
        transform.position = transform.position;// que se quede quieto entre la distancia de seguir a Mako y la de regreso cuando Mako esta muy cerca
       //
         }
#endregion
        //COMPORTAMIENTO ENEMIGO - MIRAR A MAKO
#region 
       //Flip
       if(player_pos.position.x>this.transform.position.x)
       {
gameObject.GetComponent <Animator>().SetBool("enemy2Walk", true);
            this.transform.eulerAngles = new Vector3 (0, 0, 0);

    } else {
 
            this.transform.eulerAngles = new Vector3 (0, 180, 0);
    }
          // this.transform.localScale = new Vector2(3,3); //cuando el enemigo esta hacia la derecha
          // this.transform.localScale = new Vector2(-3,3); //cuando esta hacia la izq 

#endregion

         //COMPORTAMIENTO ENEMIGO - DISPARAR A MAKO
/* 
        tiempo += Time.deltaTime;
        if(tiempo >= 2)
        {
            rb2D.velocity = new Vector2 (rb2D.velocity.x, velSaltar);
           /* Instantiate(bala, punto_instancia.position, transform.rotation); //bala, posicion, rotacion
            tiempo = 0; 
            } //el tiempo se setea nuevamente en cero */
         
 
/*       if(mustPatrol)
      {
        Patrol();
      }
      */
     }
/*     ///Codigo salto
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        if(dirX > 0)
        {
            facingRight =true;
        }else if (dirX <0)
        {
            facingRight = false;
        }
        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
         {
            localScale.x *= -1;
            transform.localScale = localScale;
         }
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        switch (col.tag){
            case "BigStump":
            rb.AddForce (Vector2.up * 600f);
            break;

            case "SmallStump":
            rb.AddForce (Vector2.up * 450f);
            break;
        }
    } */

         //VIDA ENEMIGO
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
/*
    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
*/
}