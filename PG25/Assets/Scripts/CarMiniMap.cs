using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMiniMap : MonoBehaviour
{
    public Transform car;

    void LateUpdate()
    {
        Vector3 newPosition = car.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(79.65f, car.eulerAngles.y, -5.4f);
    }


}
