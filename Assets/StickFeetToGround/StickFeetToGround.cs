using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFeetToGround : MonoBehaviour
{
    public LayerMask WalkableArea;
    public float footSpacing;
    public Transform skeletonMain;

    private Vector3 oldPosition, newPosition, currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        footSpacing = transform.localPosition.x;
        oldPosition = newPosition = currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //updating the position
        transform.position = currentPosition;

        //ray calculating Position of the foot
        Ray ray = new Ray(skeletonMain.position + (skeletonMain.right * footSpacing), Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 10, WalkableArea.value))
        {
            newPosition = info.point;
        }    
    }
}
