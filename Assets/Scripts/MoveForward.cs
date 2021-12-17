using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //Velocidad de la
    public float speed = 40f;

    //Limites de mapa para la Bala
    private float limX = 250f;
    private float yMax = 250f;
    private float yMin = -50f;
    private float limZ = 250f;

    // Update is called once per frame
    void Update()
    {
        //Movimiento de la bala
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Limites de la bala
        if (transform.position.x >= limX)
        {
            Destroy(gameObject);
        }
        if (transform.position.x <= -limX)
        {
            Destroy(gameObject);
        }
        if (transform.position.y >= yMax)
        {
            Destroy(gameObject);
        }
        if (transform.position.y <= yMin)
        {
            Destroy(gameObject);
        }
        if (transform.position.z >= limZ)
        {
            Destroy(gameObject);
        }
        if (transform.position.z <= -limZ)
        {
            Destroy(gameObject);
        }
    }
}
