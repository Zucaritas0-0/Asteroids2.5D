using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{
    public TMP_Text  textVAR;

    public Vector2 mousepost;

    private void Start()
    {
        textVAR = GetComponent<TMP_Text>();
    }

    public void LOADGame()
    {

        Debug.Log("clicking game time");
        SceneManager.LoadScene("GameScene");

    }

    public void LOADMenu()
    {

        Debug.Log("clicking menu time");
        SceneManager.LoadScene("StartScene");

    }
    public void LOADScore()
    {

        Debug.Log("clicking scores time");
        SceneManager.LoadScene("HigScoreScene");

    }
}
