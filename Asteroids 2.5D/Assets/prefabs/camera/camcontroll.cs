using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontroll : MonoBehaviour
{

    public GameObject player;
    public float softness;
    public float crange;
    private float distoplyr;
    private float ofset;
    private float degreex, degreey;
    public float cameraspeed;
    private float disy, disx;
    private Vector3 playerdist;


    private Rigidbody cam;

    void Start()
    {
        cam = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        playerdist =new Vector3 ( player.transform.position.x - this.transform.position.x,0f, player.transform.position.z - this.transform.position.z);

        ofset = player.GetComponent<PYRControll>().accel/2 ;

        if (playerdist.magnitude > crange)
        {


            transform.position = new Vector3(player.transform.position.x - (playerdist.x * Time.deltaTime * ofset * softness),40
                                           , player.transform.position.z - (playerdist.z * Time.deltaTime * ofset * softness)
                                               );

        }
    }
}
