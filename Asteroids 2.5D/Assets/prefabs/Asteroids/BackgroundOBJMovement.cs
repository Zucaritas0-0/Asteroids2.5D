using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOBJMovement : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 destiny;
    private Camera cam;
    public float asterMinSPD;
    public float asterMaxSPD;
    public float MaxDPTHval;
    public float MinDPTHval;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();



        //    destiny = new Vector3(Random.Range(-80,80),transform.position.y,Random.Range(-80,80))-transform.position;
        destiny = new Vector3(Random.Range(-80, 80), Random.Range(MinDPTHval, MaxDPTHval), Random.Range(-80, 80)) ;


        rb.AddForce(destiny.normalized * Random.Range(asterMinSPD, asterMaxSPD));
        //Debug.Log(this.gameObject.name + destiny.normalized);
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
