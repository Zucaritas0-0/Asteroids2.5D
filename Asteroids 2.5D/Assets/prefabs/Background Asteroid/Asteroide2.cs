using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide2 : MonoBehaviour{

[SerializeField] public float rotationOffset;
Transform myT;
Vector3 randomRotation;

void Awake()
{
    myT = transform;
}

void Start()

{
   // randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
    randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
   // randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
}

void FixedUpdate()
{
    myT.Rotate(randomRotation*Time.deltaTime);

}

}
