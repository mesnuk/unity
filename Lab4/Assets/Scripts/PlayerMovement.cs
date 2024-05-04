using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform transform;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        transform = GetComponent<Transform>();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        Movement();
        Clamp();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void Clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -3.6f, 3.6f);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cars")
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
}
