using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class AiSensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 10;
    public float height = 10;
    public Color meshColor = Color.red;

    //how often the scan is performed
    public int scanFrequency = 5;
    public LayerMask layers;
    public LayerMask occlusionLayers;
    public List<GameObject> Objects = new List<GameObject>();
    public List<GameObject> AllHidingSpots = new List<GameObject>();
    Collider[] colliders = new Collider[50];
    Mesh mesh;
    int count;
    float scanInterval;
    float scanTimer;

    void Start()
    {
        scanInterval = 1.0f / scanFrequency;
    }

    void Update()
    {
        scanTimer -= Time.deltaTime;
        if(scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }

    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, layers, QueryTriggerInteraction.Collide);

        Objects.Clear();
        AllHidingSpots.Clear();
        for (int i = 0; i < count; ++i)
        {
            GameObject obj = colliders[i].gameObject;

            AllHidingSpots.Add(obj);

            if (IsInSight(obj))
            {
                Objects.Add(obj);
            }
        }
    }

    public bool IsInSight(GameObject obj)
    {
        // checks if the object is within the height bounds
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;
        if(direction.y < 0 || direction.y > height){
            return false;
        }

        // checks if the object is within the angle view bounds
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if(deltaAngle > angle){
            return false;
        }

        //checks if in line of of sight and not blocked
        origin.y += height / 2;
        dest.y = origin.y;
        if(Physics.Linecast(origin, dest, occlusionLayers)){
            return false;
        }

        // checks that object is not outside max view sight
        if (Vector3.Distance(transform.position, obj.transform.position) > distance)
        {
            return false;
        }

        return true;
    }

    private void OnValidate()
    {
        scanInterval = 1.0f / scanFrequency;
        mesh = CreateWedgeMesh();
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
        
        Gizmos.DrawWireSphere(transform.position, distance);
        for(int i=0; i < count; i++)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 1f);
        }

        
        foreach(var obj in Objects)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(obj.transform.position, 1f);
        }
    }

    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = new Vector3 (0,-1,0);
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;

        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;
        for(int i = 0; i < segments; i++)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance;

            topRight = bottomRight + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;

            //far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            //bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;
        }


        for(int i=0; i<numVertices; ++i)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
