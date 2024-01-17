using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
   private bool isPaused = false;

    // Método para pausar y reanudar el juego
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Reanuda el juego
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f; // Pausa el juego
            isPaused = true;
        }
    }
}
