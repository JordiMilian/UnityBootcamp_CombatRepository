using System;
using UnityEngine;

public class HitHurtTest_DestroyObject : MonoBehaviour
{
    HurtCollider hurtCollider;
    private void Awake()
    {
        hurtCollider = GetComponent<HurtCollider>();
    }
    private void OnEnable()
    {
        hurtCollider.onHitReceived.AddListener(OnHitReceived);
    }
    private void OnHitReceived(HitCollider hit, HurtCollider hurt)
    {
       Destroy(gameObject);
    }
    private void OnDisable()
    {
        hurtCollider.onHitReceived.RemoveListener(OnHitReceived);
    }
}
