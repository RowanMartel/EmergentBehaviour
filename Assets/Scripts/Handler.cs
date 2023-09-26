using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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

    public float avoidRotateSpeed;

    [SerializeField] TMP_InputField TMPSheepSpeed;
    [SerializeField] TMP_InputField TMPGoatSpeed;
    [SerializeField] TMP_InputField TMPSheepRotationSpeed;
    [SerializeField] TMP_InputField TMPGoatRotationSpeed;
    [SerializeField] TMP_InputField TMPScareDuration;
    [SerializeField] TMP_InputField TMPScareSpeedModifier;
    [SerializeField] TMP_InputField TMPWolfRadius;
    [SerializeField] TMP_InputField TMPAvoidRotateSpeed;

    [SerializeField] GameObject propertiesPanel;
    [SerializeField] GameObject expandButton;
    [SerializeField] GameObject collapseButton;

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

        SetInputValues();
    }

    public void ToggleProperties(bool toggle)
    {
        propertiesPanel.SetActive(toggle);
        collapseButton.SetActive(toggle);
        expandButton.SetActive(!toggle);
    }

    // setter methods
    public void SetSheepSpeed()
    {
        sheepSpeed = (float)Convert.ToDouble(TMPSheepSpeed.text);
    }
    public void SetGoatSpeed()
    {
        goatSpeed = (float)Convert.ToDouble(TMPGoatSpeed.text);
    }
    public void SetSheepRotationSpeed()
    {
        sheepRotationSpeed = (float)Convert.ToDouble(TMPSheepRotationSpeed.text);
    }
    public void SetGoatRotationSpeed()
    {
        goatRotationSpeed = (float)Convert.ToDouble(TMPGoatRotationSpeed.text);
    }
    public void SetScareDuration()
    {
        scareDuration = (float)Convert.ToDouble(TMPScareDuration.text);
    }
    public void SetScareSpeedModifier()
    {
        scareSpeedModifier = (float)Convert.ToDouble(TMPScareSpeedModifier.text);
    }
    public void SetWolfRadius()
    {
        wolfRadius = (float)Convert.ToDouble(TMPWolfRadius.text);
    }
    public void SetAvoidRotateSpeed()
    {
        avoidRotateSpeed = (float)Convert.ToDouble(TMPAvoidRotateSpeed.text);
    }

    public void SetInputValues()
    {
        TMPSheepSpeed.text = sheepSpeed.ToString();
        TMPGoatSpeed.text = goatSpeed.ToString();
        TMPSheepRotationSpeed.text = sheepRotationSpeed.ToString();
        TMPGoatRotationSpeed.text = goatRotationSpeed.ToString();
        TMPScareDuration.text = scareDuration.ToString();
        TMPScareSpeedModifier.text = scareSpeedModifier.ToString();
        TMPWolfRadius.text = wolfRadius.ToString();
        TMPAvoidRotateSpeed.text = avoidRotateSpeed.ToString();
    }

    // presets

    public void PresetReset()
    {
        sheepSpeed = 1;
        TMPSheepSpeed.text = "1";
        goatSpeed = 5;
        TMPGoatSpeed.text = "5";
        sheepRotationSpeed = 1;
        TMPSheepRotationSpeed.text= "1";
        goatRotationSpeed = 3;
        TMPGoatRotationSpeed.text = "3";
        scareDuration = 1;
        TMPScareDuration.text = "1";
        scareSpeedModifier = 5;
        TMPScareSpeedModifier.text = "5";
        wolfRadius = 2;
        TMPWolfRadius.text = "2";
        avoidRotateSpeed = 3;
        TMPAvoidRotateSpeed.text = "3";
    }
    public void PresetMolecules()
    {
        sheepSpeed = 5;
        TMPSheepSpeed.text = "5";
        goatSpeed = 0;
        TMPGoatSpeed.text = "0";
        sheepRotationSpeed = 0;
        TMPSheepRotationSpeed.text = "0";
        scareSpeedModifier = 2;
        TMPScareSpeedModifier.text = "2";
        avoidRotateSpeed = 50;
        TMPAvoidRotateSpeed.text = "50";
    }
    public void PresetMagnet()
    {
        scareDuration = 2;
        TMPScareDuration.text = "2";
        scareSpeedModifier = -2;
        TMPScareSpeedModifier.text = "-2";
        wolfRadius = 4;
        TMPWolfRadius.text = "4";
    }
    public void PresetOrbit()
    {
        sheepSpeed = 20;
        TMPSheepSpeed.text = "20";
        goatSpeed = 1;
        TMPGoatSpeed.text = "1";
        sheepRotationSpeed = 50;
        TMPSheepRotationSpeed.text = "50";
        goatRotationSpeed = 3;
        TMPGoatRotationSpeed.text = "3";
        avoidRotateSpeed = 1;
        TMPAvoidRotateSpeed.text = "1";
    }
}