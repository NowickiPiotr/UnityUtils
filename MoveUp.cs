using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : Move
{

    public MoveUp(GameObject ob)
    {
        obj = ob;
    }
    
    public override void Execute()
    {
        base.Execute();
        endPosition= new Vector3(previousPosition.x, previousPosition.y, previousPosition.z + +System.Math.Sign(1) * GridSize);     
    }

}
