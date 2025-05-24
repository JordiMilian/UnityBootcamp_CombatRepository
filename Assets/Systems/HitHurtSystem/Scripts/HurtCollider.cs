using System;
using UnityEngine;
using UnityEngine.Events;

public class HurtCollider : MonoBehaviour
{
    [SerializeField] public UnityEvent<IHitter, HurtCollider> onHitReceived;
    internal void NotifyHit(IHitter hitter)
    {
        onHitReceived?.Invoke(hitter, this);
    }
}
