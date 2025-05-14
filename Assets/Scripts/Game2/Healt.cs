using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] int lifeRecover;
    public static event Action<int> OnPlayerCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerCollider?.Invoke(lifeRecover);
            Destroy(this.gameObject);
        }
    }
}
