using UnityEngine;

public class BarrelByRaycast : BarrelBase, IHitter
{
    [SerializeField] float range = 30;
    [SerializeField] LayerMask layerMask = Physics.DefaultRaycastLayers;
    [Header("Shot trail")]
    [SerializeField] GameObject shotTrailPrefab;

    [Header("Debug")]
    [SerializeField] bool debugShot;
    private void OnValidate()
    {
        if (debugShot)
        {
            debugShot = false;
            Shoot();
        }
    }
    private void Reset()
    {
        layerMask = 1 << LayerMask.NameToLayer("IgnoreRaycast");
    }
    public override void Shoot()
    {
        base.Shoot();


        Vector3 endPos = transform.position + transform.forward * range;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range,layerMask))
        {
            hit.collider.GetComponent<HurtCollider>()?.NotifyHit(this);
            endPos = hit.point;

        }
        GameObject newTrail = Instantiate(shotTrailPrefab);
        newTrail.GetComponent<ShotTrail>().Init(transform.position, hit.point);

    }
}
