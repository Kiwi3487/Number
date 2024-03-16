using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Float SO")]
//Scriptable object that can be used to store and change value
public class FloatSO : ScriptableObject //create value that can be changed
{
    public float value;
}