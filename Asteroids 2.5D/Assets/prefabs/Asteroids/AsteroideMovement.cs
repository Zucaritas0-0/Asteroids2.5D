using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideMovement : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 destiny;
    //private Camera cam;
    public float asterMinSPD;
    public float asterMaxSPD;


    // Start is called before the first frame update
    void Start()
    {
        destiny = new Vector3(Random.Range(-80,80),transform.position.y,Random.Range(-80,80))-transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(destiny.normalized*Random.Range(asterMinSPD,asterMaxSPD));
        cam = Camera.main;

    }

    private void FixedUpdate()
    {
        Vector3 distancia;
        distancia = transform.position;
        if(distancia.magnitude>45){
            Destroy(this.gameObject);
        }
        //Debug.Log("distancia:  "+ distancia.magnitude);

    }


}
