using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject2 : MonoBehaviour
{
    private float rotateSpeed = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
    }
}
