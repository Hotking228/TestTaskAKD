using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarryableObject : MonoBehaviour
{
    private bool isTargetSet = false;
    private Transform target;
    private float moveSpeed = 10f;
    public void SetMovePoint(Transform target, float moveSpeed)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;
        isTargetSet = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().isTrigger = true;
    }

    
    private void MoveToPoint(Vector3 point)
    {
        transform.position = Vector3.Lerp(transform.position, point, moveSpeed * Time.fixedDeltaTime);
    }



    private void FixedUpdate()
    {
        if (isTargetSet)
        {
            MoveToPoint(target.position);
        }
    }

    public void Throw()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().isTrigger = false;
        isTargetSet = false;
    }
}
