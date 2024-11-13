using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float takeObjectDistance = 2f;
    [SerializeField] private Transform carryObjectpoint;
    [SerializeField] private float moveToPointSpeed;


    private bool isCarryObject = false;
    private CarryableObject carryableObject;
    private void Update()
    {
        if (!isCarryObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, takeObjectDistance))
                {
                    CarryableObject cObj = hit.collider.gameObject.GetComponent<CarryableObject>();
                    if (cObj != null)
                    {
                        cObj.SetMovePoint(carryObjectpoint, moveToPointSpeed);
                        isCarryObject = true;
                        carryableObject = cObj;
                    }
                }
            }
        }
        if (isCarryObject)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isCarryObject = false;
                carryableObject.Throw();
            }
        }
        
    }
}
