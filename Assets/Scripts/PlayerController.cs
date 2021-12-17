using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Posicion inicial
    private Vector3 InitialPos = new Vector3(0, 100, 0);

    //Velocidad
    private float speed = 20f;
    
    //Controladores y limites
    private float turnSpeed = 50f;
    private float horizontalInput;
    private float verticalInput;
    private float limX = 200f;
    private float yMax = 200f;
    private float yMin = 0f;
    private float limZ = 200f;

    //Prefab Bala
    public GameObject BalaPrefab;

    //Audios
    public AudioClip disparoClip;
    private AudioSource cameraAudioSource;
    private AudioSource playerAudioSource;

    //Fin del juego
    public bool gameOver = false;

    //Puntuacion
    public int score;
    private int gameWining = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = InitialPos;
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //CONTROLES
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate( Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //LIMITES
        if (transform.position.x >= limX)
        {
            transform.position = new Vector3(limX, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -limX)
        {
            transform.position = new Vector3(-limX, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
        if (transform.position.y <= yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        if (transform.position.z >= limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, limZ);
        }
        if (transform.position.z <= -limZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limZ);
        }

        //DISPARO
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Instantiate(BalaPrefab, transform.position, BalaPrefab.transform.rotation = transform.rotation);
            playerAudioSource.PlayOneShot(disparoClip, 1);
           
        }

        //Ganar el Juego
        if(score >= gameWining)
        {
            gameOver = true;
        }
    }

    //Colisiones
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (!gameOver)
        {
            //Colision con caja
            if (otherCollider.gameObject.CompareTag("Caja"))
            {
                Debug.Log($"GAME OVER, score:{score}");
                Destroy(otherCollider.gameObject); 
                playerAudioSource.PlayOneShot(disparoClip, 1);
                Destroy(gameObject);
                gameOver = true;
               
            }
            //Colision con moneda
            else if (otherCollider.gameObject.CompareTag("Moneda"))
            {
                Destroy(otherCollider.gameObject);
                score = score + 1;
            }
        }
    }
}
