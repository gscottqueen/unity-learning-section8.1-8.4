using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    // object we are placing on the surface
    public Transform objectToPlace;

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {

        // hit variable to store results in
        RaycastHit hit;

        // ray from camera to world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            objectToPlace.position = hit.point;
            // rotate object to be rightside up
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }

    }

}
