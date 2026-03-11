using UnityEngine;

public class FingerPlane : MonoBehaviour
{
    public GameObject IndexTipSphere;
    public GameObject IndexKnuckleSphere;

    private GameObject planeObject;
    private Mesh planeMesh;

    void Start()
    {
        // Create a new GameObject to hold the plane
        planeObject = new GameObject("Plane");

        // Add MeshFilter and MeshRenderer to the newly created planeObject
        planeObject.AddComponent<MeshFilter>();
        planeObject.AddComponent<MeshRenderer>();

        // Get the MeshFilter component 
        planeMesh = planeObject.GetComponent<MeshFilter>().mesh;

        // Get a reference to the default material
        Material defaultMaterial = new Material(Shader.Find("Unlit/Color"));

        // Assign the default material to the MeshRenderer
        planeObject.GetComponent<MeshRenderer>().material = defaultMaterial;

        // Set initial plane vertices
        UpdatePlane();
    }

    void Update()
    {
        // Update plane vertices based on game object positions
        UpdatePlane();

        // Anchor the plane to the knuckle
        planeObject.transform.position = IndexKnuckleSphere.transform.position;
        planeObject.transform.rotation = IndexKnuckleSphere.transform.rotation;
    }

    void UpdatePlane()
    {
        // Get positions of game objects
        Vector3 position1 = IndexTipSphere.transform.position;
        Vector3 position2 = IndexKnuckleSphere.transform.position;

        // Calculate plane vertices
        Vector3[] vertices = new Vector3[4]
        {
            position1,
            position2,
            position1 + Vector3.Cross(position2 - position1, Vector3.up).normalized,
            position2 + Vector3.Cross(position2 - position1, Vector3.up).normalized
        };

        // Calculate plane triangles
        int[] triangles = new int[6] { 0, 1, 2, 1, 3, 2 };

        // Assign vertices and triangles to the mesh
        planeMesh.vertices = vertices;
        planeMesh.triangles = triangles;
        planeMesh.RecalculateNormals();
    }
}