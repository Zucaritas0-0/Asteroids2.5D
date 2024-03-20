using UnityEngine.Events;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{


    #region signgleton
    public static EventManager Masterfile;

    public float Finaltime;
    public int Finalscore;
   
    //public string FinalName;

    private static float[] Besttimes = new float[5];
    private static int[] Bestscore = new int[5];
    public bool yayhigscore=false;

 
    //   private string[] Bestnames = new string[5];




    private void Awake()
        {
    
        if (Masterfile == null) { Masterfile = this;

            //Debug.Log("runin for the first time");

          //  int i = 0;
           // for (i = 0; i < Bestscore.Length; i++)
           // { Bestscore[i] = 0; Besttimes[i] = 0;  }



        }
        else if (Masterfile != null) { Destroy(this); }
        }


    public void newhigscore()
    {
        int i = 0, c = 0; ;

        for (i=0;i<Bestscore.Length ;i++) {

           

            if (Finalscore > Bestscore[i]) {

                for (c = Bestscore.Length-1; c > i; c--)
                {
                    Bestscore[c] = Bestscore[c-1];
                    Besttimes[c] = Besttimes[c-1];

                }
                Bestscore[i] = Finalscore;
                Besttimes[i] = Finaltime;
                yayhigscore = true;
             
            
                i = 10000;
             }
        }
       // Bestnames[c] = FinalName;


        

    }

 //   public string getbestname(int pos){ return (Bestnames[pos]); }
    public int getbestscore(int pos) { return (Bestscore[pos]); }
    public float getbesttime(int pos) { return (Besttimes[pos]); }
    #endregion

}
