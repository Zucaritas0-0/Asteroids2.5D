using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PYRControll : MonoBehaviour
{
    public int HP;

    public float rotatonSPD;
    public float maxmoveSDP;

    public float accel;

    public Rigidbody rigbody;
    public Transform cockpit;

    public float TmMos1, TmMos2=0;

    public Vector3 mousepost;
    private Camera cam;
    public float degrees;
    public Vector3 direction;
    public float cooldown;
    private bool activemovement;


    public Vector3 worldPosition;

    private bool ControllerOption = true;

    public Plane plane = new Plane(Vector3.up, 10);

    public float distance;

    public bool inspace;

    public Vector3 distCM;
    public AudioClip [] shipnoisses = new AudioClip[0];
    public GameObject engine;


    //int sampleFreq = 44000;
    // float frequency = 350;
    public AudioSource beepplayer;
    public AudioSource enginenoise;
   
    // private AudioClip ac;


    public GameObject instantiation;
    private float timeini;



    void Start()

    {
        timeini = Time.time;
        beepplayer = GetComponent<AudioSource>();
        enginenoise =  engine.GetComponent<AudioSource>() ;

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


            direction = new Vector3(transform.position.x - cockpit.transform.position.x, 0,
             transform.position.z - cockpit.transform.position.z).normalized * -1;

            if (ControllerOption==false) {




                if (Input.GetKey(KeyCode.Mouse0))
                {


                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    if (plane.Raycast(ray, out distance))
                    {
                        worldPosition = ray.GetPoint(distance);
                    }

                    degrees = Mathf.Atan2(cam.transform.position.z - worldPosition.z, cam.transform.position.x - worldPosition.x) * Mathf.Rad2Deg;

 


                    if (degrees <= 135 && degrees >= 45)
                    {



                        if (Time.time >= TmMos1 + cooldown)
                        {
                            shoot();

                        }


                    }
                    if (degrees <= 180 && degrees > 135 || (degrees >= -180 && degrees < -135))
                    {

                        transform.Rotate(Vector3.up, +rotatonSPD);

                    }
                    if (degrees > -45 && degrees < 45)
                    {

                        transform.Rotate(Vector3.up, -rotatonSPD);

                    }
                    if (degrees >= -135 && degrees <= -45)
                    {



                        accel += 600f;
                        rigbody.AddForce(direction * 5);

                        if (accel >= maxmoveSDP)
                        {

                            accel = maxmoveSDP;

                        }

                        if (activemovement == false)
                        {
                            activemovement = true;
                            enginenoise.loop = true;
                            enginenoise.Play();

                        }



                        rigbody.AddForce(direction * accel * 10);


                    }


                    // enginenoise.Stop();
                    //enginenoise.loop = false;




                }



            } else {


          

                    if (Input.GetKey(KeyCode.Space))
                    {



                        if (Time.time >= TmMos1 + cooldown)
                        {
                            shoot();

                        }


                    }
                    if (Input.GetKey(KeyCode.D))
                    {

                        transform.Rotate(Vector3.up, +rotatonSPD);

                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        transform.Rotate(Vector3.up, -rotatonSPD);

                    }
                    if (Input.GetKey(KeyCode.W))
                    {



                        accel += 600f;
                        rigbody.AddForce(direction * 5);

                        if (accel >= maxmoveSDP)
                        {

                            accel = maxmoveSDP;

                        }

                        if (activemovement == false)
                        {
                            activemovement = true;
                            enginenoise.loop = true;
                            enginenoise.Play();

                        }



                        rigbody.AddForce(direction * accel * 10);


                    }


                    // enginenoise.Stop();
                    //enginenoise.loop = false;




                




            }

            
            Playbzz();




        }
    }

    private void  Playbzz() {

      //  Debug.Log("speed" + rigbody.velocity.magnitude);

        if (rigbody.velocity.magnitude<1)
        {
            activemovement = false;
            enginenoise.loop = false;
            
      


        }
       
       

    }

    private void shoot() {

        if (TmMos1 + cooldown < Time.time)
        {

            // Debug.Log("ship direction " + direction);
            beepplayer.clip = shipnoisses[0];
            beepplayer.Play();

            Instantiate(instantiation, cockpit.transform.position, transform.rotation);
            
            //poner timer de vida a la bala
            TmMos1 = Time.time;
        }

  

    }

    private void OnBecameInvisible()
    {
        rigbody.AddForce(direction *  3500);

    }
    private void OnCollisionEnter(Collision collide)
    {
        if (collide.GetContact(0).otherCollider.tag != "PlayProyect")
        {
            HP -= collide.GetContact(0).otherCollider.GetComponent<AsteroidTOPControll>().DMG;
            if (HP <= 0)
                
            {
             

                EventManager.Masterfile.Finaltime = Time.time - timeini;
                EventManager.Masterfile.newhigscore();
                if (EventManager.Masterfile.yayhigscore) {
                    SceneManager.LoadScene("HigScoreScene"); } 
                else { SceneManager.LoadScene("GameOverScene");}
                
            }
        }
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
