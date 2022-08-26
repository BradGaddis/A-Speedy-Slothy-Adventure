using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFollower
{ 
    public class FollowBackground : MonoBehaviour
    {
        [SerializeField] GameObject backgroundObj;
        [SerializeField] GameObject target;
        [SerializeField] Vector3 offset;
        CameraFollow cameraFollow;
        
        // Start is called before the first frame update
        void Start()
        {
            cameraFollow = GetComponent<CameraFollow>();
            if(backgroundObj == null)
            {
                backgroundObj = GameObject.FindGameObjectWithTag("Background");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if(!cameraFollow.IsAtSideBound(target))
                FollowTargetCentered(target);
        }

        void FollowTargetCentered(GameObject targetToFollow)
        {
            backgroundObj.transform.position = targetToFollow.transform.position + offset;
        }

    }
}