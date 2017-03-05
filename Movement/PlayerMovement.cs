using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    private Command arrowRight;
    private Command arrowLeft;
    private Command arrowUp;
    private Command arrowDown;
    List<Command> commands = new List<Command>();

    private Move playerMovement;
    private Vector2 input;
    private bool isMoving = false;
    private float t;
    private float factor = 0.5f;
    private float startTime;
    private Vector3 endPosition;

    void Start()
    {
        arrowRight = new MoveRight(gameObject);
        arrowLeft  = new MoveLeft(gameObject);
        arrowUp = new MoveUp(gameObject);
        arrowDown = new MoveDown(gameObject);
        startTime = Time.time;
        playerMovement = new Move();
    }

   
    void Update()
    {
        isStartMoving();
    }

    public IEnumerator Mover(Transform transform)
    {
        isMoving = true;
        t = 0; 

        if (Input.GetKey(KeyCode.A))
        {
            arrowLeft.Execute();
            commands.Add(arrowLeft);
            endPosition = arrowLeft.endPosition;
        }


        if (Input.GetKey(KeyCode.D))
        {
            arrowRight.Execute();
            commands.Add(arrowRight);
            endPosition = arrowRight.endPosition;
              
          
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            arrowUp.Execute();
            commands.Add(arrowUp);
            endPosition = arrowUp.endPosition;
        }

        if (Input.GetKey(KeyCode.S))
        {
            arrowDown.Execute();
            commands.Add(arrowDown);
            endPosition = arrowDown.endPosition;
        }
        
        while (t < factor)
        {
            t += Time.deltaTime * (playerMovement.MoveSpeed / playerMovement.GridSize);
            transform.position = Vector3.Lerp(gameObject.transform.position, endPosition, t);
            yield return null;
        }
 
        isMoving = false;
        yield return 0;
    }

    IEnumerator RevertChanges()
    {
        if (commands.Count == 0) yield break;

        for (int i = commands.Count; i > 0; i--)
        {
            commands[i - 1].Reverse();
            yield return new WaitForEndOfFrame();
        }
        commands.Clear();
    }

    private void isStartMoving()
    {
        if (isMoving != true)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }
            if (input != Vector2.zero)
            {
                StartCoroutine(Mover(transform));
            }
        }
    }
}
