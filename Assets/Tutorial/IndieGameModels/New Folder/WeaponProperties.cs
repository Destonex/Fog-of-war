using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/properties")]
public class WeaponProperties : ScriptableObject {
    public Vector3 rHandPos;
    public Vector3 rHandRot;

    public GameObject WeaponPrefab;
}