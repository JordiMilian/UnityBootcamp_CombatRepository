using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Weapon_MartialArts martialArts;
    public void NotifyAttack(string attackString,float duration)
    {
        martialArts.NotifyAttack(attackString, duration);
    }
}
