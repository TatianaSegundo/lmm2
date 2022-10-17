using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovPlataforma : MonoBehaviour
{
    public float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position,Vector2.down,distancia);
        rb.velocity = new Vector2(velocidad,rb.velocity.y);
        if(informacionSuelo == false)
        {
            //Girar
            Girar();
        }
    }

    private void Girar(){
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180, 0);
        velocidad *= -1; //para que se mueva en la direccion contraria
    }
    private void OnDrawGizmos(){
        //dibuja la linea para que veamos si esta en la posicion correcta
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }
}
