using UnityEngine;

public abstract class BarrelBase : MonoBehaviour
{
    public virtual void Shoot() { }
    public virtual void StartContinuoisShooting() { }
    public virtual void StopContinuoisShooting() { }
}
