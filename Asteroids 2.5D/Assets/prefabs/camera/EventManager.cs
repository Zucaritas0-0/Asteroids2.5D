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
    public string FinalName;

    private float[] Besttimes = new float[5] ;
        private int[] Bestscore = new int[5];
        private string[] Bestnames = new string[5];




    private void Awake()
        {
        
        if (Masterfile == null) { Masterfile = this; } else if (Masterfile != null) { Destroy(this); }
        }


    public void newhigscore()
    {
        int i=0, c = 0; 

        for (i=0;i<=Bestscore.Length ;i++) {
            if (Finalscore > Bestscore[i]|| Finaltime > Besttimes[i]) { c = i;i = 8; SceneManager.LoadScene("HigScoreScene"); }
        }
        Bestnames[c] = FinalName;
        Bestscore[c] = Finalscore;
        Besttimes[c] = Finaltime;

        Debug.Log("higscored pos "+c);

    }

    public string getbestname(int pos){ return (Bestnames[pos]); }
    public float getbestscore(int pos) { return (Bestscore[pos]); }
    public int getbesttime(int pos) { return (Bestscore[pos]); }

    #endregion

}
