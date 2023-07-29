using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour{

    public GameObject objeto;
    public float respawnTime = 200.0f;
    public float spawnrange;
    public float minYvar;
    public float maxYvar;


    // Use this for initialization
    private Camera cam;
    public Plane plane = new Plane(Vector3.up, 10);
   // public Transform obj;
    public float distance;
    public Vector3[] corners = new Vector3[4];


    void Start()
    {
        cam = Camera.main;

        Ray corn1 = cam.ScreenPointToRay(new Vector3(0, 0, 0));
        Ray corn2 = cam.ScreenPointToRay(new Vector3(Screen.width, 0, 0));
        Ray corn4 = cam.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
        Ray corn3 = cam.ScreenPointToRay(new Vector3(0, Screen.height, 0));

        if ( plane.Raycast(corn1, out distance))
        {
            corners[0] = new Vector3(corn1.GetPoint(distance).x, corn1.GetPoint(distance).y, corn1.GetPoint(distance).z) ;
        }
        if (plane.Raycast(corn1, out distance))
        {
            corners[1] = new Vector3(corn2.GetPoint(distance).x, corn2.GetPoint(distance).y, corn2.GetPoint(distance).z);
        }
        if (plane.Raycast(corn1, out distance))
        {
            corners[2] = new Vector3(corn3.GetPoint(distance).x, corn3.GetPoint(distance).y, corn3.GetPoint(distance).z);
        }
        if (plane.Raycast(corn1, out distance))
        {
            corners[3] = new Vector3(corn4.GetPoint(distance).x, corn4.GetPoint(distance).y, corn4.GetPoint(distance).z);
        }
        
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        GameObject a = Instantiate(objeto) as GameObject;
        //a.transform.position = new Vector3(Random.Range (-screenBounds.x , screenBounds.x), -18, Random.Range(-screenBounds.y, screenBounds.y));//

        //a.transform.position = new Vector3(Random.Range (corners[0].x, corners[0].x + 10), Random.Range (-18, -23) ,Random.Range (corners[0].z, corners[0].z + 10));//
        a.transform.position = Quaternion.Euler(0, Random.Range(0, 360), 0)* new Vector3(corners[3].z + spawnrange, Random.Range(minYvar,maxYvar), corners[3].z + spawnrange);

            }
    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
    
}
