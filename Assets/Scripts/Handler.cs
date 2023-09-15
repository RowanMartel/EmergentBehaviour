using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] GameObject sheepPrefab;
    [SerializeField] GameObject goatPrefab;

    Wolf wolf;

    public List<GameObject> GoatList;
    public List<GameObject> SheepList;

    public int sheepAmount;
    public int goatAmount;

    public float sheepSpeed;
    public float goatSpeed;

    public float sheepRotationSpeed;
    public float goatRotationSpeed;

    public float scareDuration;
    public float scareSpeedModifier;

    public float wolfRadius;


    void Start()
    {
        wolf = FindObjectOfType<Wolf>();

        // generate goats
        for (int i = 0; i < goatAmount; i++)
        {
            GoatList.Add(Instantiate<GameObject>(goatPrefab));
            GoatList[i].GetComponent<Goat>().numInList = i;
        }
        // generate sheep
        for (int i = 0; i < sheepAmount; i++)
        {
            SheepList.Add(Instantiate<GameObject>(sheepPrefab));
        }
    }
}