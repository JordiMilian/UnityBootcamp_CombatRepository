using UnityEngine;

public class ShotTrail : MonoBehaviour
{
    [SerializeField] float lifeTime = 0.25f;
    [SerializeField] int segments = 10;
    LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    public void Init(Vector3 startPos, Vector3 endPos)
    {
        Vector3[] positions = new Vector3[segments +1];
        lineRenderer.positionCount = segments +1;
        for (int i = 0; i < positions.Length; i++)
        {
           
        }


        lineRenderer.SetPositions(positions);

        Destroy(gameObject, lifeTime);
    }
}
