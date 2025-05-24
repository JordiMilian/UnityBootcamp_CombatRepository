
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BoxingCube : MonoBehaviour
{
    [SerializeField] HurtCollider hurtCollider;
    [SerializeField] float distanceToMovePerHit;

    /*
    private void OnEnable()
    {
        hurtCollider.onHitReceived.AddListener(OnHurt);
    }
    private void OnDisable()
    {
        hurtCollider.onHitReceived.RemoveListener(OnHurt);
    }
    void OnHurt(IHitter hit, HurtCollider hurt)
    {
        Debug.Log("Cube got hit");
        Vector3 directionFromAttack = (hurt.transform.position - hit.transform.position);
        Vector3 planeDirection = (Vector3.ProjectOnPlane(directionFromAttack, Vector3.up)).normalized;
        transform.position += distanceToMovePerHit * planeDirection;
    }
    */
}
