using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2Controll : MonoBehaviour
{
  
    void FixedUpdate()
    {
       if (transform.position.y > .5 || transform.position.y<-.5)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.magnitude>50)
        {
            transform.position = new Vector3(transform.position.x*-1,0,transform.position.z*-1);
        }

    }


    private void OnCollisionEnter(Collision collide)
    {
       // Debug.Log("collided with"+collide.collider.transform.tag);
        if (collide.GetContact(0).otherCollider.tag =="PlayProyect") { Destroy(this.gameObject); /*and increase score*/}
       // if (collide.GetContact(0).otherCollider.tag == collide.GetContact(0).thisCollider.tag) { Destroy(this.gameObject); /*and spawn mini asteroidsS*/}
    }
}
