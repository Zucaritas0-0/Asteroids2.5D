using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PYRControll : MonoBehaviour
{

    public float rotatonSPD;
    public float maxmoveSDP;

    public float accel;

    public Rigidbody rigbody;
    public Transform cockpit;

    public float TmMos1, TmMos2;

    public Vector3 mousepost;
    private Camera cam;
    public float degrees;
    public Vector3 direction;
    public float cooldown;


    public Vector3 worldPosition;

    public Plane plane = new Plane(Vector3.up, 10);

   public  float distance;

    public bool inspace;

    public Vector3 distCM;



    //int sampleFreq = 44000;
   // float frequency = 350;
    public AudioSource beepplayer ;
   // private AudioClip ac;


    public GameObject instantiation;



    void Start()

    {
        beepplayer = GetComponent<AudioSource>();
        cam = Camera.main;
        rigbody = GetComponent<Rigidbody>();




    }


    void FixedUpdate()
    {

        // control de la nave en planeta

        if (inspace == false)
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.Log("draw ray "+ray);

                if (plane.Raycast(ray, out distance))
                {
                    worldPosition = ray.GetPoint(distance);
                }

                transform.position = worldPosition;

            }

        }
        else
        {



            if (Input.GetKey(KeyCode.Mouse0))
            {
               

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (plane.Raycast(ray, out distance))
                {
                    worldPosition = ray.GetPoint(distance);
                }

                degrees = Mathf.Atan2(cam.transform.position.z-worldPosition.z, cam.transform.position.x- worldPosition.x) * Mathf.Rad2Deg;
               
                direction = new Vector3(transform.position.x - cockpit.transform.position.x,0,
                                            transform.position.z - cockpit.transform.position.z).normalized * -1;

       
                if (degrees <= 135 && degrees >= 45)
                {



                    if (Time.time >= TmMos1 + cooldown) { shoot(); }
                    

                }
                if (degrees <= 180 && degrees > 135 || (degrees >= -180 && degrees < -135) )
                {

                    transform.Rotate(Vector3.up,+rotatonSPD);

                }
                if (degrees > -45 && degrees < 45)
                {

                    transform.Rotate(Vector3.up, -rotatonSPD);

                }
                if (degrees >= -135 && degrees <= -45)
                {

                    accel+=600f;
                    rigbody.AddForce(direction * 5);

                    if (accel >= maxmoveSDP)
                    {
                        
                        accel = maxmoveSDP;
                    }
                    rigbody.AddForce( direction* accel* 10 ) ;


                }
    



            }





        }
    }

    private void shoot() {

        if(TmMos1 + cooldown < Time.time )
        {
            Debug.Log("ship direction " + direction);

            Instantiate(instantiation, cockpit.transform.position, transform.rotation);
            TmMos1 = Time.time;
        }

  

    }

    private void OnBecameInvisible()
    {
        rigbody.AddForce(direction *  3500);

    }

    /*** usar esto para reproducir sonidos en espacios diferentes
     * 
          float[] samples = new float[400000];
           for (int i = 0; i < samples.Length; i++)
           {
               samples[i] = Mathf.Sin(Mathf.PI * 2 * i * frequency / sampleFreq);
           }
           ac = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);

           ac.SetData(samples, 0);

           ac.LoadAudioData();




           beepplayer.clip = ac;

           //  Debug.Log("ac"+ac);

           beepplayer.Play();
     
     
     
     */
}
