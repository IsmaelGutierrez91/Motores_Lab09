using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform AngleRotations;
    public static event Action OnPlayerCollider;
    private void Awake()
    {
        AngleRotations = GetComponent<Transform>();
    }
    private void Update()
    {
        QuaternionRotation();
    }
    private void QuaternionRotation()
    {
        AngleRotations.rotation = new quaternion(AngleRotations.rotation.x, AngleRotations.rotation.y + 1, AngleRotations.rotation.z, AngleRotations.rotation.w);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnPlayerCollider?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
