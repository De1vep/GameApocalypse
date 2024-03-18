using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeScriptableObject", menuName = "ScriptableObject/Upgrade")]
public class UpgradeScriptableObject : ScriptableObject
{
	[SerializeField] public int Level;
	[SerializeField] public float Multiplier;   
	[SerializeField] public string Name;   
}
