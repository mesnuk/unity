using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    [SerializeField] private Renderer meshRender;
    [SerializeField] private float startSpeed = 1.0f;
    [SerializeField] private float speedIncreaseRate = 10.0f;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = startSpeed;
    }

    void Update()
    {
        currentSpeed += speedIncreaseRate * Time.deltaTime;
        meshRender.material.mainTextureOffset += new Vector2(0, currentSpeed * Time.deltaTime);
    }

}
