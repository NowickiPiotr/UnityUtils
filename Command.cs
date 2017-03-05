using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour {

    public GameObject obj;
    public virtual void Execute() { }
    public virtual void Reverse() { }

    public Vector3 previousPosition;
    public Vector3 endPosition;
}
