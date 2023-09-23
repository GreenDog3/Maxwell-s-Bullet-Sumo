using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState { Idle, Chase, Attack, Turn, Return };
    public AIState currentState = AIState.Chase;
    private float lastStateChangeTime = 0f;
    public GameObject target = null;
    public Transform homeBase;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }
    public void DoTurnState()
    {
        if (target != null)
        {
            pawn.RotateTowards(target.transform.position);
        }

    }
    public void DoAttackState()
    {
        pawn.Shoot();
    }

    public void DoReturnState()
    {
        Vector3 tempTargetLocation = homeBase.position;
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y, tempTargetLocation.z);
        pawn.RotateTowards(tempTargetLocation);
        pawn.MoveForward();
    }

    public void DoChaseState()
    {
        if (target != null)
        {
            //turn to target
            pawn.RotateTowards(target.transform.position);
            //charge forward
            pawn.MoveForward();

        }

    }

    public void DoIdleState()
    {
        //i'm too good at this state irl lol
    }
    public void ChangeAIState(AIState newState)
    {
        lastStateChangeTime = Time.time;
        currentState = newState;
    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - lastStateChangeTime >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    public void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this);
    }



}
