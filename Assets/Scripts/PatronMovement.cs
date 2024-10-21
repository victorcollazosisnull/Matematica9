using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PatronMovement : MonoBehaviour
{
    [Header("Movimiento Enemigo")]
    public Vector2 puntoA;
    public Vector2 puntoB;
    public float speed; 
    private Vector2 destino;
    private bool movePoint = true;
    private float distancia;
    private float tiempo;
    private float velocidad;
    void Start()
    {
        if (puntoA == null || puntoB == null)
        {
            return;
        }
        destino = puntoB; 
        CalculosMRU();
    }
    void Update()
    {
        Patrullaje();
    }
    void Patrullaje()
    {
        transform.position = Vector2.MoveTowards(transform.position, destino, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, destino) < 0.1f)
        {
            MostrarInfo();
            if (movePoint)
            {
                destino = puntoA;
            }
            else
            {
                destino = puntoB;
            }
            movePoint = !movePoint;
            CalculosMRU();
        }
    }
    void CalculosMRU()
    {
        distancia = Vector2.Distance(transform.position, destino);

        tiempo = distancia / speed;

        velocidad = speed;
    }
    void MostrarInfo()
    {
        if (movePoint)
        {
            Debug.Log("Distancia desde punto A a B: " + distancia);
            Debug.Log("Tiempo de punto A a B: " + tiempo + " segundos");
            Debug.Log("Velocidad de punto A a B: " + velocidad);
        }
        else
        {
            Debug.Log("Distancia desde punto B a A: " + distancia);
            Debug.Log("Tiempo de punto B a A: " + tiempo + " segundos");
            Debug.Log("Velocidad de punto B a A: " + velocidad);
        }
    }
}
