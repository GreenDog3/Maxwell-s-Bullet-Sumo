using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMover : Mover
{
    public Rigidbody catRigidbody;

    private void Start()
    {
        catRigidbody = GetComponent<Rigidbody>();
    }
    public override void Move(float moveSpeed, float direction)
    {
        base.Move(moveSpeed, direction);
        Vector3 currentPosition = transform.position;
        catRigidbody.MovePosition(currentPosition + (transform.forward * direction * moveSpeed * Time.deltaTime));
    }

    public override void Rotate(float turnSpeed)
    {                                     
        catRigidbody.transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
