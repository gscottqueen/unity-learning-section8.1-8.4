using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    // initalize array for storing receiver objects
    private GameObject[] rayTargets;
    // initalize variable for storing material color
    private Color32 initalColor;

    void Start()
    {
        // collect all our receiver objects
        if (rayTargets == null)
            rayTargets = GameObject.FindGameObjectsWithTag("RayTarget");

        // get our inital color
        initalColor = rayTargets[0].gameObject.GetComponent<MeshRenderer>().material.color;

    }
    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        // hit variable to store our results
        RaycastHit hit;

        // a ray that goes from screen coordinates forward into our world
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Conduct our Raycast
        if (Physics.Raycast(ray, out hit))
        {
            // on hover change color of reciever
            hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
        }
        else
        {
            foreach (GameObject rayTarget in rayTargets)
            {
               // set color to initial color
               rayTarget.GetComponent<MeshRenderer>().material.SetColor("_Color", initalColor);
            }
        }
    }


}
