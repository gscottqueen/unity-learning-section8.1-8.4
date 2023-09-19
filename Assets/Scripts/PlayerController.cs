using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
/*  Based on Sebastian Lague tutorial at https://www.youtube.com/watch?v=gHeQ8Hr92P4&t=7s */
  public float moveSpeed = 15;
  private Vector3 moveDir;

  void Update ()
  {
    moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
  }

  void FixedUpdate ()
  {
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
  }
}