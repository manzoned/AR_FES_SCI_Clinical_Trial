using UnityEngine;

public class IntersectingPlane : MonoBehaviour
{
    public Transform IndexKnuckleSphere;
    public Transform IndexMiddleSphere;
    public Transform IndexTipSphere;

    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        if (meshFilter != null)
        {
            meshFilter.mesh = mesh;
        }
        else
        {
            Debug.LogError("MeshFilter is not assigned!");
        }

        UpdatePlane();
    }

    void Update()
    {
        UpdatePlane();
    }

    void UpdatePlane()
    {
        // Calculate plane normal
        Vector3 normal = Vector3.Cross(IndexMiddleSphere.position - IndexKnuckleSphere.position, IndexTipSphere.position - IndexKnuckleSphere.position);
        normal.Normalize();

        // Calculate two perpendicular vectors in the plane
        Vector3 up = Vector3.up;
        if (Mathf.Abs(Vector3.Dot(normal, up)) > 0.9f) // If normal is nearly parallel to up
        {
            up = Vector3.forward;
        }
        Vector3 right = Vector3.Cross(normal, up).normalized;
        Vector3 forward = Vector3.Cross(normal, right);

        // Define vertices for a simple quad
        Vector3[] vertices = new Vector3[4];
        vertices[0] = -right - forward;
        vertices[1] = right - forward;
        vertices[2] = right + forward;
        vertices[3] = -right + forward;

        // Define triangles for the quad
        int[] triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Calculate and assign normals to the mesh
        Vector3[] normals = new Vector3[4];
        for (int i = 0; i < 4; i++)
        {
            normals[i] = normal;
        }
        mesh.normals = normals;

        // Recalculate bounds for proper rendering
        mesh.RecalculateBounds();
    }
}