using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideMovement : MonoBehaviour
{
    //public Rigidbody rigidbody;
    Vector3 destiny;


    // Start is called before the first frame update
    void Start()
    {
        destiny = new Vector3(0,transform.position.y,0)-transform.position;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(destiny.normalized*25);
        
    }
}
