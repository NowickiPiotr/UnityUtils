using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command {

    public float MoveSpeed = 3f;
    public float GridSize = 2f;


    public override void Execute()
    {
        previousPosition = obj.transform.position;
    }

    public override void Reverse()
    {
        obj.transform.position = previousPosition;
    }
}
