using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Transform transform;
    [SerializeField] private float startSpeed = 4f;
    [SerializeField] private float speedIncreaseRate = 0.4f;
    private float currentSpeed;

    void Start()
    {
        transform = GetComponent<Transform>();
        currentSpeed = startSpeed;
    }

    void Update()
    {
        currentSpeed += speedIncreaseRate * Time.deltaTime;
        transform.position -= new Vector3(0, currentSpeed * Time.deltaTime, 0);
        Debug.Log("speed:" + currentSpeed);

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
