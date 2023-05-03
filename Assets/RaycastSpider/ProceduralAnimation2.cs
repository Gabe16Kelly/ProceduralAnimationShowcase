using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation2 : MonoBehaviour
{
    [Header("Skeleton Information")]
    public LayerMask walkableArea;
    public Transform raycastNextStep;
    public ProceduralAnimation2 oppositeFoot;
    public Transform skeletonMain;
    [Header("Movement Attributes")]
    public float speed = 10f;
    public float distanceForStep = 1f;
    public float heightOfStep;
    public float footSpacing;

    private Vector3 newPosition, currentPosition, oldPosition;
    private float lerp;

    // Start is called before the first frame update
    void Start()
    {
        footSpacing = transform.localPosition.x;
        oldPosition = transform.position;
        newPosition = transform.position;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //updating the position and normal
        transform.position = currentPosition;

        //ray calculating Position of the foot
        Ray ray = new Ray(skeletonMain.position + (skeletonMain.right * footSpacing), Vector3.down);
        RaycastHit info;

        //ray calculating the next step of the foot
        Ray nextRay = new Ray(raycastNextStep.position, Vector3.down);
        RaycastHit nextStepInfo;
        Physics.Raycast(nextRay, out nextStepInfo, 10, walkableArea.value);

        // calucualating the distance between the 2 rays to see if the foot needs to take a step
        if (Physics.Raycast(ray, out info, 10, walkableArea.value))
        {
            if((Vector3.Distance(newPosition, nextStepInfo.point) > distanceForStep) && lerp >= 1 && !oppositeFoot.stepBeingTaken()){

                newPosition = nextStepInfo.point;
                Debug.Log("Move Foot");
                lerp = 0;

            } 
        }
        if(lerp < 1)
        {
            Vector3 footPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
            footPosition.y += Mathf.Sin(lerp * Mathf.PI) * heightOfStep;

            currentPosition = footPosition;
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldPosition = newPosition;
        }             
    }

    public bool stepBeingTaken()
    {
        return lerp < 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(newPosition, 0.5f);
    }


}
