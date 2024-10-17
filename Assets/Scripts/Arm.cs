using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ArmType
{
    Punch,
    Falcopulse,
    Flyshot,
    // Dog
    // Crocodile
    // Barracudazooka
}
public class Arm : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;

    [SerializeField]
    GameObject[] offensiveArmTypes;

    private ArmType equippedArm1;

    private void Start()
    {
        equippedArm1 = ArmType.Flyshot;
    }

    private void Shoot(ArmType armType)
    {
        Instantiate(offensiveArmTypes[0], bulletSpawnPoint.position, transform.rotation * offensiveArmTypes[0].transform.rotation);
    }

    private void OnFired1()
    {
        Shoot(equippedArm1);
    }

    private void OnEnable()
    {
        PlayerInput.fired1 += OnFired1;
    }

    private void OnDisable()
    {
        PlayerInput.fired1 -= OnFired1;
    }
}
