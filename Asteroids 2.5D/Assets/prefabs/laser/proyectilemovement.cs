using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilemovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public GameObject ownerP;

    int sampleFreq = 44000;
    float frequency = 350;
    public AudioSource beepplayer;
    private AudioClip ac;
    public Vector3 direction;

    void Start()
    {
       transform.Rotate(ownerP.transform.rotation.eulerAngles*-1);
        direction = ownerP.GetComponent<PYRControll>().direction;
        rb = GetComponent<Rigidbody>();
      
        beepplayer = GetComponent<AudioSource>();



        float[] samples = new float[400000];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(Mathf.PI * 2 * i * frequency / sampleFreq);
        }

        ac = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);

        ac.SetData(samples, 0);

        ac.LoadAudioData();

        beepplayer.clip = ac;

        beepplayer.Play();

        rb.AddForce(Quaternion.Euler( transform.rotation.x, transform.rotation.y, transform.rotation.z) *Vector3.forward* 1000 );
     
  




    }

}
