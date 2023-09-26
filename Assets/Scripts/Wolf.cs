using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wolf : MonoBehaviour
{
    Handler handler;

    void Start()
    {
        handler = FindObjectOfType<Handler>();
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetMouseButtonDown(0))
            Scare();
    }

    void Scare()
    {
        // return if UI was clicked
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, handler.wolfRadius);
        foreach (Collider2D collider in nearby)
        {
            if (collider.CompareTag("Sheep"))
                collider.GetComponent<Sheep>().Scare(transform.position);
        }
    }
}