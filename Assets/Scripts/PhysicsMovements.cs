using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PhysicsMovements : MonoBehaviour
{
    [Header("Player 1")]
    public TMP_InputField speedP1;
    public TMP_InputField timeP1;
    public TMP_InputField accelerationP1;
    public TMP_Text xP1;
    public Transform player1;
    private Vector2 originalPositionP1;
    private Vector2 targetPositionP1;

    [Header("Player 2")]
    public TMP_InputField speedP2;
    public TMP_InputField timeP2;
    public TMP_InputField accelerationP2;
    public TMP_Text xP2;
    public Transform player2;
    private Vector2 originalPositionP2;
    private Vector2 targetPositionP2;

    public float moveSpeed = 0.5f;

    private bool isMoving = false; 
    private bool isResetting = false; 

    void Start()
    {
        originalPositionP1 = player1.position;
        originalPositionP2 = player2.position;
        targetPositionP1 = originalPositionP1;
        targetPositionP2 = originalPositionP2;
    }
    void Update()
    {
        if (isMoving && !isResetting)
        {
            player1.position = Vector2.Lerp(player1.position, targetPositionP1, Time.deltaTime * moveSpeed);
            player2.position = Vector2.Lerp(player2.position, targetPositionP2, Time.deltaTime * moveSpeed);

            if (Vector3.Distance(player1.position, targetPositionP1) < 0.01f && Vector3.Distance(player2.position, targetPositionP2) < 0.01f)
            {
                player1.position = originalPositionP1;
                player2.position = originalPositionP2;
                CalcularPosiciones();
                targetPositionP1 = originalPositionP1 + new Vector2(float.Parse(xP1.text), 0);
                targetPositionP2 = originalPositionP2 + new Vector2(float.Parse(xP2.text), 0);
            }
        }
    }
    public void StartMovement()
    {
        CalcularPosiciones();
        isMoving = true; 
    }
    private void CalcularPosiciones()
    {
        float v0_1 = float.Parse(speedP1.text);
        float t_1 = float.Parse(timeP1.text);
        float a_1 = float.Parse(accelerationP1.text);
        float x_1 = (v0_1 * t_1) + (0.5f * a_1 * Mathf.Pow(t_1, 2));
        xP1.text = x_1.ToString("F2");
        targetPositionP1 = originalPositionP1 + new Vector2(x_1, 0);

        float v0_2 = float.Parse(speedP2.text);
        float t_2 = float.Parse(timeP2.text);
        float a_2 = float.Parse(accelerationP2.text);
        float x_2 = (v0_2 * t_2) + (0.5f * a_2 * Mathf.Pow(t_2, 2));
        xP2.text = x_2.ToString("F2");
        targetPositionP2 = originalPositionP2 + new Vector2(x_2, 0);
    }
    public void Resetear()
    {
        isResetting = true;

        player1.position = originalPositionP1;
        player2.position = originalPositionP2;

        speedP1.text = "";
        timeP1.text = "";
        accelerationP1.text = "";
        xP1.text = "";

        speedP2.text = "";
        timeP2.text = "";
        accelerationP2.text = "";
        xP2.text = "";

        Invoke("ClearResettingState", 0.1f);
    }
    private void ClearResettingState()
    {
        isResetting = false;
        isMoving = false; 
    }
}