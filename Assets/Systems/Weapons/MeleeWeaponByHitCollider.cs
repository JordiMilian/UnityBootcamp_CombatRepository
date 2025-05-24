using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeleeWeaponByHitCollider : MonoBehaviour
{
    Dictionary<string, HitCollider> hitCollidersList = new();
    private void Awake()
    {
        foreach(HitCollider hit in GetComponentsInChildren<HitCollider>())
        {
            hitCollidersList.Add(hit.name, hit);
            hit.gameObject.SetActive(false);
        }
    }
    public void NotifyAttack(MeleeAttackInfo attackInfo) //Called from Weapon Manager
    {
        PerformAttack(hitCollidersList[attackInfo.colliderName], attackInfo.duration);
    }

    private void PerformAttack(HitCollider collider, float duration)
    {
        collider.gameObject.SetActive(true);
        DOVirtual.DelayedCall
            (duration, () => collider.gameObject.SetActive(false));
    }
}
