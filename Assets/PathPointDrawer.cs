using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathPointDrawer : MonoBehaviour
{
    public GameObject pathPointPrefab;
    public List<Transform> pathPoints;
    public Transform pathPointsHolder;
    public PathCreator pathCreator;

    // Start is called before the first frame update
    void Start()
    {
        pathPoints = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            DrawPoint(transform.position);
        }
    }
    void DrawPoint(Vector3 position) {
        GameObject pathPoint = Instantiate(pathPointPrefab, position, Quaternion.identity, pathPointsHolder);
        pathPoints.Add(pathPoint.transform);

        // Create a new bezier path from the pathPoints.
        BezierPath bezierPath = new BezierPath (pathPoints, isClosed: false, PathSpace.xyz);
        pathCreator.bezierPath = bezierPath;

        // // Add a new pathPoints to the path end
        // pathCreator.bezierPath.AddSegmentToEnd(position);
    }
}
