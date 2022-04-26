using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Renderer : MonoBehaviour
{
    private List<Transform> points = new List<Transform>();

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private int den;           // density - how much nodes will be between the start and end points
    [SerializeField] private float freq;        // frequency - time between moves
    [SerializeField] private float osc;         // oscillation - how much a node moves up and down
    [SerializeField] private GameObject _point;
    [SerializeField] private lr_LineController line;

    private float lerpValue = 0;
    private float dist;

    private void Start()
    {
        CreateLine();
        line.SetUpLine(points);
    }

    private void FixedUpdate()
    {
        StartCoroutine(MovingNodes(freq));
    }

    void CreateLine()
    {
        points.Add(startPoint);

        dist = 1 / (float)den;
        for(int i = 0; i <= den - 2; i++) 
        {
            lerpValue += dist;
            Vector3 instPos = Vector3.Lerp(startPoint.position, endPoint.position, lerpValue);
            GameObject pointGO = Instantiate(_point, instPos, transform.rotation, this.gameObject.transform);
            points.Add(pointGO.transform);
        }

        points.Add(endPoint);
    }

    IEnumerator MovingNodes(float freq)
    {
        yield return new WaitForSeconds(freq);
        float original_y = transform.position.y;
        int iteration = 0;
        foreach (Transform node in points)
        {
            iteration++;
            if (1 < iteration && iteration < points.Count)
            {
                node.position = new Vector3(node.position.x,
                Mathf.Lerp(node.position.y, original_y + Random.Range(-osc, osc), freq),
                node.position.z);
            }
            
        }
        //transform.position = new Vector3(transform.position.x, original_y, transform.position.z);
    }
}
