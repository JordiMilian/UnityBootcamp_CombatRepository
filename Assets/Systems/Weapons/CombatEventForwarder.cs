using UnityEngine;

public class CombatEventForwarder : MonoBehaviour
{
    WeaponManager weaponManager;
    private void Awake()
    {
        weaponManager = GetComponentInParent<WeaponManager>();
    }
    public void NotifyAttack(string attackString, float duration)
    {
        weaponManager.NotifyAttack(attackString, duration);
    }
}
