using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject powerPrefab;


    void Start()
    {
        InvokeRepeating("CreatePowerUps", 15.0f, 15.0f) ;
    }

    // Update is called once per frame
    void CreatePowerUps()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-3.5f, 2), 0);
        Instantiate(powerPrefab, spawnPosition, Quaternion.identity);
    }
}
