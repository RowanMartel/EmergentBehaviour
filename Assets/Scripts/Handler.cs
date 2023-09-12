using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] GameObject sheepPrefab;
    [SerializeField] GameObject goatPrefab;

    public List<GameObject> GoatList;

    public int sheepAmount;
    public int goatAmount;

    public float sheepSpeed;
    public float goatSpeed;

    public float sheepRotationSpeed;
    public float goatRotationSpeed;

    void Start()
    {
        for (int i = 0; i < goatAmount; i++)
        {
            GoatList.Add(Instantiate<GameObject>(goatPrefab));
            GoatList[i].GetComponent<Goat>().numInList = i;
        }
    }
}