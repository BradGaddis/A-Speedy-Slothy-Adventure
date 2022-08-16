using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        FollowTargetCentered(target);
    }

    private void FollowTargetCentered(GameObject targetToFollow)
    {
        Vector3 targetPos = targetToFollow.transform.position;
        Vector3 updatedPos = targetPos + offset;
        transform.position = updatedPos;
    }
}
