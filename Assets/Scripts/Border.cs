using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Border : MonoBehaviour
{
    enum TPType
    {
        leftToRight,
        rightToLeft,
        topToBottom,
        bottomToTop
    }
    [SerializeField] TPType teleportType;

    [SerializeField] Transform parallelBorder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mover"))
        {
            if (teleportType == TPType.leftToRight)
                collision.transform.position = new Vector2 (parallelBorder.position.x - 0.5f, collision.transform.position.y);
            else if (teleportType == TPType.rightToLeft)
                collision.transform.position = new Vector2(parallelBorder.position.x + 0.5f, collision.transform.position.y);
            else if (teleportType == TPType.bottomToTop)
                collision.transform.position = new Vector2(collision.transform.position.x, parallelBorder.position.y - 0.5f);
            else if (teleportType == TPType.topToBottom)
                collision.transform.position = new Vector2 (collision.transform.position.x, parallelBorder.position.y + 0.5f);
        }
    }
}