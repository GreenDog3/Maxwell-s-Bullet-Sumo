using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static AIController;
using static UnityEngine.GraphicsBuffer;

public class EasyAI : AIController
{
    public override void Start()
    {
        pawn = GetComponent<Pawn>();
        GameManager.instance.enemies.Add(this);
        GameManager.instance.enemy = pawn.gameObject;

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

    public override void MakeDecisions() //Idles, chases the player, shoots, repeat
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
                    ChangeAIState(AIState.Chase);
                    }
                }
                else
                {
                    ChangeAIState(AIState.Idle);
                }
                
                break;
            case AIState.Attack:
                DoAttackState();
                ChangeAIState(AIState.Idle);
                break;
            case AIState.Turn:
                DoTurnState();
                if (IsTimePassed(1))
                {
                    ChangeAIState(AIState.Attack);
                }
                break;
            case AIState.Chase:
                DoChaseState();
                if (IsTimePassed(1))
                {
                    ChangeAIState(AIState.Attack);
                }
                break;
        }
    }
}
