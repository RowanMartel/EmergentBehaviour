using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : MonoBehaviour
{
    public int numInList;
    Handler handler;

    void Start()
    {
        handler = FindObjectOfType<Handler>();

        SetStartingPos();
    }

    void Update()
    {
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
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, handler.goatRotationSpeed * Time.deltaTime);

        // move forward
        transform.Translate(Vector2.right * handler.goatSpeed * Time.deltaTime);
    }
    
    void SetStartingPos()
    {
        float startX = Random.Range(-9, 9);
        float startY = Random.Range(-5, 5);
        transform.position = new Vector2(startX, startY);
    }
}