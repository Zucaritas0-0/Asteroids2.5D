using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class textmanager : MonoBehaviour
{
    public TMP_Text textVAR;
    public TMP_Text textVAR2;
    public TMP_Text textVAR3;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == ("GameOverScene"))
        {

            textVAR.SetText("score : " + EventManager.Masterfile.Finalscore.ToString());
            textVAR2.SetText("time  : " + EventManager.Masterfile.Finaltime.ToString() + " 's");
        }
        if (SceneManager.GetActiveScene().name == ("HigScoreScene"))
        {
            textVAR3.SetText("user  : " + EventManager.Masterfile.getbestname(0));
            textVAR.SetText("score : " + EventManager.Masterfile.getbestscore(0).ToString());
            textVAR2.SetText("time  : " + EventManager.Masterfile.getbesttime(0).ToString() + " 's");
        }
    }
    private void FixedUpdate()
    {

        if (SceneManager.GetActiveScene().name == ("GameScene")) {

            textVAR.SetText("score : " + EventManager.Masterfile.Finalscore.ToString());
        }
       
    


    }
}
