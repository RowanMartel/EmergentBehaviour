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
        Vector2 nextGoatPos;
        if (numInList == handler.GoatList.Count - 1)
            nextGoatPos = handler.GoatList[0].transform.position;
        else
            nextGoatPos = handler.GoatList[numInList + 1].transform.position;

        float angle = Mathf.Atan2(nextGoatPos.y - transform.position.y, nextGoatPos.x - transform.position.x) * Mathf.Rad2Deg;
        float difference = Mathf.DeltaAngle(transform.rotation.z, angle);
        if (difference > 0) transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z + handler.goatRotationSpeed * Time.deltaTime);
        else transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z - handler.goatRotationSpeed * Time.deltaTime);

        // move forward
        transform.position += transform.right * Time.deltaTime * handler.goatSpeed;
    }
    
    void SetStartingPos()
    {
        float startX = Random.Range(-9, 9);
        float startY = Random.Range(-5, 5);
        transform.position = new Vector2(startX, startY);
    }
}