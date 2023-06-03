using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionControll : MonoBehaviour

    
{
    private Camera cam;
    public Plane plane = new Plane(Vector3.up, 10);
    public Transform obj;
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (obj.transform.position.x < corners[0].x+.6f ||   obj.transform.position.x > corners[3].x-.6f )
        {
            obj.transform.position = new Vector3(obj.transform.position.x * -1, transform.position.y, obj.transform.position.z );
        }
        if ( obj.transform.position.z < corners[0].z ||  obj.transform.position.z > corners[3].z)
        {
            obj.transform.position = new Vector3(obj.transform.position.x , transform.position.y, obj.transform.position.z * -1);
        }




    }
}
