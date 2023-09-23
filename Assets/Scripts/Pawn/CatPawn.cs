using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(CatShooter))]
[RequireComponent(typeof(CatMover))]
public class CatPawn : Pawn
{
    private const float forwardDirection = 1f;
    private const float backwardDirection = -1f;
    public float forwardSpeed = 5f;
    public float backwardSpeed = 3f;
    public float catRotationSpeed;
    public GameObject shellPrefab;
    private float secondsSinceLastShot = Mathf.Infinity;
    public float shotCooldownTime = 1f;
    public float fireForce = 1000;
    public float shellLifespan = 1.5f;
    // Start is called before the first frame update
    public override void Start()
    {
        mover = GetComponent<CatMover>();
        shooter = GetComponent<CatShooter>();
    }
    // Update is called once per frame
    public override void Update()
    {
        secondsSinceLastShot += Time.deltaTime;
    }

    public override void MoveForward()
    {
        mover.Move(forwardSpeed, forwardDirection);
    }

    public override void MoveBackward()
    {
        mover.Move(backwardSpeed, backwardDirection);
    }

    public override void Rotate(float direction)
    {
        mover.Rotate(catRotationSpeed * direction);
    }

    public override void Shoot()
    {
        if (secondsSinceLastShot > shotCooldownTime)
        {
            shooter.Shoot(shellPrefab, fireForce, shellLifespan);
            secondsSinceLastShot = 0;
        }

    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, catRotationSpeed * Time.deltaTime);
    }

    public override void RotateAway(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(-vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, catRotationSpeed * Time.deltaTime);
    }
}
