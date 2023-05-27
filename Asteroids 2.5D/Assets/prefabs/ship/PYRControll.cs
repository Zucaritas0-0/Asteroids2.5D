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
    private Vector3 direction;


    public Vector3 worldPosition;

    public Plane plane = new Plane(Vector3.up, 10);

   public  float distance;

    public bool inspace;

    public Vector3 distCM;

    int sampleFreq = 44000;
    float frequency = 440;



    void Start()
    {
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
                //TmMos1 = Time.time;

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

               // Debug.Log("ray cast " + ray);

                if (plane.Raycast(ray, out distance))
                {
                    worldPosition = ray.GetPoint(distance);
                }

                degrees = Mathf.Atan2(cam.transform.position.z-worldPosition.z, cam.transform.position.x- worldPosition.x) * Mathf.Rad2Deg;
               
                direction = new Vector3(transform.position.x - cockpit.transform.position.x,0,
                                            transform.position.z - cockpit.transform.position.z).normalized * -1;

                if (degrees <= 135 && degrees >= 45)
                {

                    shoot();
                   Debug.Log("sooot!!");

                }
                if (degrees <= 180 && degrees > 135 || (degrees >= -180 && degrees < -135) )
                {

                    transform.Rotate(Vector3.up,+rotatonSPD);

                   // transform.eulerAngles += Vector3.up * rotatonSPD;
                 //   Debug.Log("spinnighright!");

                }
                if (degrees > -45 && degrees < 45)
                {

                    transform.Rotate(Vector3.up, -rotatonSPD);

                  //  transform.eulerAngles -= Vector3.up * rotatonSPD;
                //    Debug.Log("spinnigleft!");

                }
                if (degrees >= -135 && degrees <= -45)
                {

                    //   Debug.Log("going to :" + direction);
                    accel+=100f;
                   // Debug.Log("accel " + accel);
                    if (accel >= maxmoveSDP)
                    {
                        
                        accel = maxmoveSDP;
                      //  Debug.Log("accel " + accel);
                    }
                    rigbody.AddForce( direction* accel* 10 ) ;
                    //Debug.Log("accel " + direction * accel*10 );
                    //  rigbody.AddForce(transform.position - cockpit.position * moveSDP/2);
                    //  Debug.Log("accelerating!! " + ( cockpit.position- transform.position  * moveSDP));

                }
           //*    accel -= 30f;
            //    if (accel <= 0)
              //  {
                   // Debug.Log("accel 0");
                 //   accel = 0;
               // }
              //  rigbody.AddForce(direction * -accel * 30 );

                
                //  Debug.Log("grados : "+degrees);




            }


            /*

             si dedo esta a la izquierda de la pantalla, nave gira izquierda
            si dedo an el fondo, disparar
            si dedo a la derecha, girar erecha,
            si dedo arriba, acelerar



             */


            //Debug.Log(ray);
            //Debug.Log(worldPosition);

            //Debug.Log("x "+Input.mousePosition.x);
            //Debug.Log("y "+Input.mousePosition.y);
            // Debug.Log("z "+Input.mousePosition.z);

        }
    }

    private void shoot() {

        float[] samples = new float[44000];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(Mathf.PI * 2 * i * frequency / sampleFreq);
        }
        AudioClip ac = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);

        ac.SetData(samples, 0);

        //  ac.

        ac.LoadAudioData();
       


    }

    private void OnBecameInvisible()
    {
        rigbody.AddForce(direction *  3500);

    }


}
