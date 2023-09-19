using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
  public Transform target;
  public float distance = 0.0f;
  public float height = 0.0f;
  public float damping = 0.0f;
  public bool smoothRotation = false;
  public bool followBehind = false;
  public float rotationDamping = 0.0f;

  void Update()
  {
    Vector3 wantedPosition;
    if (followBehind)
      wantedPosition = target.TransformPoint(0, height, -distance);
    else
      wantedPosition = target.TransformPoint(0, height, distance);

    transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

    if (smoothRotation)
    {
      Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
      transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
    }
    else transform.LookAt(target, target.up);
  }
}
