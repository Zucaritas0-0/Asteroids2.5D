using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaControll : MonoBehaviour
{
    public ParticleSystem Starsystem;
    public float starpeed;

    void Start()
    {
        Starsystem = GetComponent<ParticleSystem>();
        starpeed =  Starsystem.main.startSpeed.constantMin;
        starpeed = 100;


    }

   
}
