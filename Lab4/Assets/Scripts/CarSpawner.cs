using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    void Start()
    {
        StartCoroutine(SpawnCars());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Cars()
    {
        int rand = Random.Range(0, cars.Length);
        float randXPos = Random.Range(-3.6f, 3.6f);
        Instantiate(cars[rand], new Vector3(randXPos, transform.position.y, transform.position.z), Quaternion.identity);
    }

    IEnumerator SpawnCars()
    {
        while (true) 
        {
            yield return new WaitForSeconds(2);
            Cars();
        }       
    }
}
