using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackInfo", menuName = "Scriptable Objects/MeleeAttackInfo")]
public class MeleeAttackInfo : ScriptableObject
{
    public string colliderName;
    public float duration = 0.25f;
}
