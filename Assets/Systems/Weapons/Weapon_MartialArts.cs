using System;
using UnityEngine;
using DG.Tweening;

public class Weapon_MartialArts : MonoBehaviour
{
    [SerializeField] Collider leftPunchCollider;
    [SerializeField] Collider rightPunchCollider;
    [SerializeField] Collider leftKickCollider;
    [SerializeField] Collider rightKickCollider;

    private void Awake()
    {

        leftPunchCollider.gameObject.SetActive(false);
        rightPunchCollider.gameObject.SetActive(false);
        leftKickCollider.gameObject.SetActive(false);
        rightKickCollider.gameObject.SetActive(false);
    }
    public void NotifyAttack(string attackString, float duration)
    {
        switch(attackString)
        {
            case "LeftPunch":
                PerformAttack(leftPunchCollider, duration);
                break;
            case "RightPunch":
                PerformAttack(rightPunchCollider, duration);
                break;

        }
    }

    private void PerformAttack(Collider collider, float duration)
    {
        collider.enabled = true;
        DOVirtual.DelayedCall
            (duration, () => collider.enabled = false, false);
    }
}
