using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    Vector3 offset;
    float lowerBound;


    // Update is called once per frame
    void Update()
    {
        if(!IsAtLowerBound(target))
        {
            FollowTargetCentered(target);
        }
        GameObject ground = GameObject.Find("Ground");
        lowerBound = ground.GetComponent<CompositeCollider2D>().bounds.min.y;
    }

    private void FollowTargetCentered(GameObject targetToFollow)
    {
        Vector3 targetPos = targetToFollow.transform.position;
        Vector3 updatedPos = targetPos + offset;
        transform.position = updatedPos;
    }

    bool IsAtLowerBound(GameObject target){
        if (target.transform.position.y + Camera.main.orthographicSize <= lowerBound) {
            return true;
        } 
        return false;
    }
}
