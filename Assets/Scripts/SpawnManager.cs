using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Tiempo de Spawneo
    private float startDelay = 1.0f;
    private float repeatRate = 5.0f;

    //Posicion de Spawneo
    public Vector3 spawnPos;
    public float randomX;
    public float randomY;
    public float randomZ;

    //Limites de Spawn
    private float limX = 200f;
    private float yMax = 200f;
    private float yMin = 0f;
    private float limZ = 200f;

    //Nombramos el script Player Controller
    private PlayerController PlayerControllerScript;

    //Nombramos el Obstaculo
    public GameObject ObstaclePrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        //Bucle de Spawn
        InvokeRepeating("SpawnPrefab", startDelay, repeatRate);
        //conectamos con el player controller
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnPrefab()
    {
        //Aleatoriedad del Spawn
        randomX = Random.Range(-limX, limX);
        randomY = Random.Range(yMin, yMax);
        randomZ = Random.Range(-limZ, limZ);

        //Posicion de Spawn
        spawnPos = new Vector3(randomX, randomY, randomZ);

        //Spawn
        if (!PlayerControllerScript.gameOver)
        {
            Instantiate(ObstaclePrefab, spawnPos, ObstaclePrefab.transform.rotation);
           
        }
    }
}
