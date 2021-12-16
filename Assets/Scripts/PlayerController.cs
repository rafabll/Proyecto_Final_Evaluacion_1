using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 50f;
    private float horizontalInput;
    private float verticalInput;
    private float limX = 200f;
    private float yMax = 200f;
    private float yMin = 0f;
    private float limZ = 200f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate( Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

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
    }
}
