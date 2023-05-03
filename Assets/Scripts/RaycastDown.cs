using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDown : MonoBehaviour
{
    public LayerMask WalkableArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 10, WalkableArea.value))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down ) * info.distance, Color.red);
        }
    }


    
}
