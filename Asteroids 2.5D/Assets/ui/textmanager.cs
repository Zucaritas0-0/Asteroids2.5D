using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class textmanager : MonoBehaviour
{
    public TMP_Text textVAR ;
    public TMP_Text textVAR2;
    public TMP_Text textVAR3;
    public TMP_Text textVAR4;
    public TMP_Text textVAR5;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == ("GameOverScene"))
        {

            textVAR.SetText("score : " + EventManager.Masterfile.Finalscore.ToString());
            textVAR2.SetText("time  : " + EventManager.Masterfile.Finaltime.ToString() + " 's");
        }
        if (SceneManager.GetActiveScene().name == ("HigScoreScene"))
        {
           // textVAR3.SetText("user  : " + EventManager.Masterfile.getbestname(0));
            textVAR.SetText ("1.- " + EventManager.Masterfile.getbestscore(0).ToString() + "  " + EventManager.Masterfile.getbesttime(0).ToString() + "'s");
            textVAR2.SetText("2.- " + EventManager.Masterfile.getbestscore(1).ToString() + "  " + EventManager.Masterfile.getbesttime(1).ToString() + "'s");
            textVAR3.SetText("3.- " + EventManager.Masterfile.getbestscore(2).ToString() + "  " + EventManager.Masterfile.getbesttime(2).ToString() + "'s");
            textVAR4.SetText("4.- " + EventManager.Masterfile.getbestscore(3).ToString() + "  " + EventManager.Masterfile.getbesttime(3).ToString() + "'s");
            textVAR5.SetText("5.- " + EventManager.Masterfile.getbestscore(4).ToString() + "  " + EventManager.Masterfile.getbesttime(4).ToString() + "'s");

        }
    }
    private void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == ("GameScene")) {

            textVAR.SetText("score : " + EventManager.Masterfile.Finalscore.ToString());
        }
       
    


    }
}
