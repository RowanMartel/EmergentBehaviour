using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Sheep : MonoBehaviour
{
    Handler handler;
    Vector3 TargetPos;
    bool scared;
    float scareTimer;
    public float rotateMod;
    public Transform leftNode;
    public Transform rightNode;

    void Start()
    {
        leftNode = transform.GetChild(0);
        rightNode = transform.GetChild(1);
        handler = FindObjectOfType<Handler>();

        SetStartingPos();

        scared = false;
        scareTimer = 0;
    }

    void Update()
    {
        if (scared)
        {
            if (scareTimer >= handler.scareDuration)
            {
                scared = false;
                scareTimer = 0;
            }
            else scareTimer += Time.deltaTime;
        }

        AvoidObstacle();
        MoveSequence();
    }

    void MoveSequence()
    {
        // rotate towards target
        if (!scared)
        {
            GetTarget();
            Vector2 targetDirection = TargetPos - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotateMod));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, (handler.goatRotationSpeed + handler.avoidRotateSpeed) * Time.deltaTime);
        }

        // move forward
        float speedMod = 1;
        if (scared)
            speedMod = handler.scareSpeedModifier;

        transform.Translate(Vector2.right * handler.sheepSpeed * Time.deltaTime * speedMod);
    }

    void SetStartingPos()
    {
        float startX = Random.Range(-9, 9);
        float startY = Random.Range(-5, 5);
        transform.position = new Vector2(startX, startY);
    }

    void GetTarget() // get the position of the closest goat
    {
        Transform closestGoat = null;
        float minDistSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject goat in handler.GoatList)
        {
            // avoiding Vector3.Distance and doing the square math ourselves saves on performance as Vector3.Distance has a square root calculation
            Vector3 directionToTarget = goat.transform.position - currentPos;
            float distSqr = directionToTarget.sqrMagnitude;
            if (distSqr < minDistSqr)
            {
                closestGoat = goat.transform;
                minDistSqr = distSqr;
            }
        }
        TargetPos = closestGoat.position;
    }

    public void Scare(Vector2 wolfPos)
    {
        Vector2 targetDirection  = wolfPos - (Vector2)transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3 (0, 0, angle + 180);
        scared = true;
    }

    void AvoidObstacle()
    {
        RaycastHit2D closestObst = Physics2D.CircleCast(transform.position, 1, Vector2.right, 0.1f, 3);
        if (!closestObst) return;
        float rightDistance = Vector2.Distance(rightNode.position, closestObst.transform.position);
        float leftDistance = Vector2.Distance(leftNode.position, closestObst.transform.position);
        if (rightDistance < leftDistance) rotateMod = -handler.avoidRotateSpeed;
        else rotateMod = handler.avoidRotateSpeed;
    }
}