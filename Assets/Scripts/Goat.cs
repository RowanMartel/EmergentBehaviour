using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    public int numInList;
    Handler handler;
    public float rotateMod;
    public Transform leftNode;
    public Transform rightNode;

    void Start()
    {
        leftNode = transform.GetChild(0);
        rightNode = transform.GetChild(1);
        handler = FindObjectOfType<Handler>();

        SetStartingPos();
    }

    void Update()
    {
        AvoidObstacle();
        MoveSequence();
    }

    void MoveSequence()
    {
        // rotate towards next goat
        Transform nextGoatTransform;
        if (numInList == handler.GoatList.Count - 1)
            nextGoatTransform = handler.GoatList[0].transform;
        else
            nextGoatTransform = handler.GoatList[numInList + 1].transform;

        Vector2 targetDirection = nextGoatTransform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, (handler.goatRotationSpeed + handler.avoidRotateSpeed) * Time.deltaTime);

        // move forward
        transform.Translate(Vector2.right * handler.goatSpeed * Time.deltaTime);
    }
    
    void SetStartingPos()
    {
        float startX = Random.Range(-9, 9);
        float startY = Random.Range(-5, 5);
        transform.position = new Vector2(startX, startY);
    }

    void AvoidObstacle()
    {
        rotateMod = 0;
        RaycastHit2D closestObst = Physics2D.CircleCast(transform.position, 1, Vector2.right, 0.1f, 3);
        if (!closestObst) return;
        float rightDistance = Vector2.Distance(rightNode.position, closestObst.transform.position);
        float leftDistance = Vector2.Distance(leftNode.position, closestObst.transform.position);
        if (rightDistance < leftDistance) rotateMod = -handler.avoidRotateSpeed;
        else rotateMod = handler.avoidRotateSpeed;
    }
}