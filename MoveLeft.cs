using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Move {

    public MoveLeft(GameObject ob)
    {
        obj = ob;
    }

    public override void Execute()
    {
        base.Execute();
        endPosition = new Vector3(previousPosition.x + System.Math.Sign(-1) * GridSize, previousPosition.y, previousPosition.z);

    }
}
