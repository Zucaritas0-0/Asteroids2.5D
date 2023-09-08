using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{

    public void LOADGame()
    {

       // Debug.Log("clicking game time");
        SceneManager.LoadScene("GameScene");

    }

    public void LOADMenu()
    {

       // Debug.Log("clicking menu time");
        SceneManager.LoadScene("StartScene");

    }
    public void LOADScore()
    {

        //Debug.Log("clicking scores time");
        SceneManager.LoadScene("HigScoreScene");

    }
}
