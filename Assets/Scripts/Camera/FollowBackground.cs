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
        void LateUpdate()
        {
            if(cameraFollow.IsAtSideBound(target))
            {
                FollowVertical(target);
            } else if(cameraFollow.IsAtLowerBound(target)){
                FollowHorizontal(target);
            } 
            else {
                FollowTargetCentered(target);
            }
        }

        void FollowTargetCentered(GameObject targetToFollow)
        {
            // backgroundObj.transform.position = targetToFollow.transform.position + offset;
            backgroundObj.transform.position = Vector3.Lerp(backgroundObj.transform.position, targetToFollow.transform.position + offset, 1f);

        }

        private void FollowHorizontal(GameObject targetToFollow){
            Vector3 targetPos = targetToFollow.transform.position;
            Vector3 updatedPos = targetPos + offset;
            Vector3 newPos = new Vector3(updatedPos.x, transform.position.y, updatedPos.z);
            backgroundObj.transform.position = Vector3.Lerp(backgroundObj.transform.position, newPos, 1f);
            
            // backgroundObj.transform.position = new Vector3(updatedPos.x, transform.position.y, updatedPos.z);
        }
        private void FollowVertical(GameObject targetToFollow){
            Vector3 targetPos = targetToFollow.transform.position;
            Vector3 updatedPos = targetPos + offset;
            Vector3 newPos = new Vector3(transform.position.x, updatedPos.y, updatedPos.z);
            backgroundObj.transform.position = Vector3.Lerp(backgroundObj.transform.position, newPos, 1f);

            // backgroundObj.transform.position = new Vector3(transform.position.x, updatedPos.y, updatedPos.z);
        }
    }
}