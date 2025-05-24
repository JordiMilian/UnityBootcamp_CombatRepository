using UnityEngine;

public class CombatEventForwarder : MonoBehaviour
{
    WeaponManager weaponManager;
    private void Awake()
    {
        weaponManager = GetComponentInParent<WeaponManager>();
    }
    public void NotifyAttack(Object attackInfo)
    {
        if(attackInfo is not MeleeAttackInfo) { throw new System.Exception("Missing Melee attack info"); }
        weaponManager.NotifyAttack(attackInfo as MeleeAttackInfo);
    }
}
