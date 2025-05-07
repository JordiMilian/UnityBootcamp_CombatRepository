using UnityEngine;

public class HitCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        CheckCollider(collision.collider);
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckCollider(other);
    }

    private void CheckCollider(Collider other)
    {
        if (other.TryGetComponent(out HurtCollider hurtCollider))
        {
            hurtCollider.NotifyHit(this);
        }
    }
}
