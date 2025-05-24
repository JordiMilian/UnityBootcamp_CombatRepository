using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] MeleeWeaponByHitCollider martialArts;
    public void NotifyAttack(MeleeAttackInfo attackInfo)
    {
        martialArts.NotifyAttack(attackInfo);
    }
}
