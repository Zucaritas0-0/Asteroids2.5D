using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTOPControll : MonoBehaviour
{

    public int HP;
    public GameObject instantiation ;

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
        if (collide.GetContact(0).otherCollider.tag =="PlayProyect") {

            HP -= collide.GetContact(0).otherCollider.GetComponent<proyectilemovement>().DMG;
           
            if (HP <= 0) {

                /*and increase score*/
                if(transform.tag != "AsteroidC") {
                    for (int i = 0; i <= Random.Range(0, 3); i++)
                    {
                        Instantiate(instantiation, transform.position, transform.rotation);
                    }
                }
                
                Destroy(this.gameObject);
            }

        }
       // if (collide.GetContact(0).otherCollider.tag == collide.GetContact(0).thisCollider.tag) { Destroy(this.gameObject); /*and spawn mini asteroidsS*/}
    }
}
