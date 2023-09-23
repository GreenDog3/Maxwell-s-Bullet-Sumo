using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAI : AIController
{
    public override void Start()
    {
        pawn = GetComponent<Pawn>();
        GameManager.instance.enemies.Add(this);
        GameManager.instance.enemy = pawn.gameObject;
        homeBase = GameManager.instance.centerPoint;

        //starts by idling
        ChangeAIState(AIState.Idle);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (pawn != null)
        {
            MakeDecisions();
            GameManager.instance.TryGameOver();
        }
        else
        {
            Destroy(this);
        }
    }

    public override void MakeDecisions() //Goes to the center while shooting. Once it reaches the center, shifts to taking aim at the player and shooting
    {
        switch (currentState)
        {
            case AIState.Idle:
                DoIdleState();
                if (GameManager.instance.player != null)
                {
                    target = GameManager.instance.player;
                }
                if (target != null)
                {
                    if (IsTimePassed(1))
                    {
                        ChangeAIState(AIState.Return);
                    }
                }
                else
                {
                    ChangeAIState(AIState.Idle);
                }
                break;
            case AIState.Attack:
                DoAttackState();
                ChangeAIState(AIState.Return);
                break;
            case AIState.Turn:
                DoTurnState();
                if (IsTimePassed(1))
                {
                    ChangeAIState(AIState.Attack);
                }
                break;
            case AIState.Return:
                DoReturnState();
                if (Vector3.Distance(pawn.transform.position, homeBase.position) <= 1)
                {
                    ChangeAIState(AIState.Turn);
                }
                else
                {
                    ChangeAIState(AIState.Attack);
                }
                break;
        }
    }
}
