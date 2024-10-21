using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPersecución : MonoBehaviour
{
    [Header("Persecución")]
    public Transform objetivo;  
    public float speed;
    public float aceleration;
    public float stop = 0.1f;
    private float currentSpeed;
    void Start()
    {       
        currentSpeed = speed;
    }
    void Update()
    {
        if (objetivo == null)
        {
            return;
        }
        float distancia = Vector2.Distance(transform.position, objetivo.position);
        if (distancia > stop)
        {
            currentSpeed += aceleration * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, currentSpeed * Time.deltaTime);
        }
        else
        {
            currentSpeed = speed;
        }
        Debug.Log("Distancia al objetivo: " + distancia);
        Debug.Log("Velocidad actual: " + currentSpeed);  
    }
}