using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilemovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    //public GameObject ownerP;

    //int sampleFreq = 44000;
    //float frequency = 250;
    //public AudioSource beepplayer;
    //private AudioClip ac;
    public Vector3 direction;
    public float proyectilespeed;
    public int DMG; 
    void Start()
    {
      // transform.Rotate(ownerP.transform.rotation.eulerAngles*-1);
      
        direction = GameObject.FindGameObjectWithTag ("Player").GetComponent<PYRControll>().direction ;
        
        rb = GetComponent<Rigidbody>();
      
      //  beepplayer = GetComponent<AudioSource>();



      //  float[] samples = new float[400000];
      //  for (int i = 0; i < samples.Length; i++)
      //  {
      //      samples[i] = Mathf.Sin(Mathf.PI * 2 * i * frequency / sampleFreq);
      //  }

        //ac = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);

      //  ac.SetData(samples, 0);

     //  ac.LoadAudioData();

      //  beepplayer.clip = ac;

       // beepplayer.Play();

        rb.AddForce( direction * proyectilespeed);
        //  Debug.Log("bullet direction" + direction);

        Destroy(this.gameObject, 3);



    }


    private void OnCollisionEnter(Collision collide)
    {
       // Destroy(this.gameObject);
        // Debug.Log("collided with"+collide.collider.transform.tag);
          if (collide.GetContact(0).otherCollider.tag != "Player") { Destroy(this.gameObject); /*and increase score*/}
        // if (collide.GetContact(0).otherCollider.tag == collide.GetContact(0).thisCollider.tag) { Destroy(this.gameObject); /*and spawn mini asteroidsS*/}
    }




}
