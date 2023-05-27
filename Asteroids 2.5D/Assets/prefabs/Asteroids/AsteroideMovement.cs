using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideMovement : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 destiny;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        destiny = new Vector3(Random.Range(-10,10),transform.position.y,Random.Range(-10,10))-transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(destiny.normalized*Random.Range(200,300));
        cam = Camera.main;

        
    }

    private void FixedUpdate()
    {
        Vector3 distancia;
        distancia = transform.position-destiny;
        if(distancia.magnitude>17){
            Destroy(this.gameObject);
        }
        Debug.Log("distancia:  "+ distancia.magnitude);

    }


}
