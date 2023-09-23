using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallcheck : MonoBehaviour
{
    public Pawn pawn;
    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBreakingContainment() == true)
        {
            Destroy(pawn.gameObject);
        }
    }

    public bool IsBreakingContainment()
    {
        if (pawn.transform.position.y <= -10) //if pawn falls out of bounds, return true
        {
            return true;
        }
        return false;
    }
}
