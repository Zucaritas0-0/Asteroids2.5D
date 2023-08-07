using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotation : MonoBehaviour
{
    private float rx;
    private float ry;
    private float rz;
    // Start is called before the first frame update
    void Start()
    {
       rx = Random.Range(0.1f, 0.8f);
       ry = Random.Range(0.1f, 0.8f);
       rz = Random.Range(0.1f, 0.8f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, rx);
        transform.Rotate(Vector3.forward, ry);
        transform.Rotate(Vector3.left, rz);
    }
}
