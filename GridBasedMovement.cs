using System.Collections;
using UnityEngine;

public class GridBasedMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0.0f;

        originPos = transform.position;
        targetPos = originPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
