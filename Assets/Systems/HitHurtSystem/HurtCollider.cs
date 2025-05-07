using System;
using UnityEngine;
using UnityEngine.Events;

public class HurtCollider : MonoBehaviour
{
    [SerializeField] public UnityEvent<HitCollider, HurtCollider> onHitReceived;
    internal void NotifyHit(HitCollider hitCollider)
    {
        onHitReceived?.Invoke(hitCollider, this);
    }
}
