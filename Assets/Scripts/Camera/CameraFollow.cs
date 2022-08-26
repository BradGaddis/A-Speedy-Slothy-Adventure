using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFollower
{ 
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        GameObject target;
        [SerializeField]
        Vector3 offset;
        public float lowerBound, leftBound, rightBound;
        float aspectRatio, cameraHalfHeigth, cameraWidth;
        
        private void Start() {
            
        }


        // Update is called once per frame
        void Update()
        {
            GameObject ground = GameObject.Find("Ground");
            lowerBound = ground.GetComponent<CompositeCollider2D>().bounds.min.y;
            leftBound = ground.GetComponent<CompositeCollider2D>().bounds.min.x;
            rightBound = ground.GetComponent<CompositeCollider2D>().bounds.max.x;

            
            aspectRatio = Camera.main.aspect;
            cameraHalfHeigth = Camera.main.orthographicSize;
            cameraWidth = aspectRatio * cameraHalfHeigth * 2;

            // if(!IsAtLowerBound(target) && !IsAtSideBound(target))
            // {
            //     FollowTargetCentered(target);
            //     Debug.Log(!IsAtSideBound(target));
            // }
            if(IsAtSideBound(target))
            {
                FollowVertical(target);
            } else if(IsAtLowerBound(target)){
                FollowHorizontal(target);
            } 
            else {
                FollowTargetCentered(target);
            }
        }

        private void FollowHorizontal(GameObject targetToFollow){
            Vector3 targetPos = targetToFollow.transform.position;
            Vector3 updatedPos = targetPos + offset;
            transform.position = new Vector3(updatedPos.x, Camera.main.transform.position.y, updatedPos.z);
        }
        private void FollowVertical(GameObject targetToFollow){
            Vector3 targetPos = targetToFollow.transform.position;
            Vector3 updatedPos = targetPos + offset;
            transform.position = new Vector3(Camera.main.transform.position.x, updatedPos.y, updatedPos.z);
        }

        private void FollowTargetCentered(GameObject targetToFollow)
        {
            Vector3 targetPos = targetToFollow.transform.position;
            Vector3 updatedPos = targetPos + offset;
            transform.position = updatedPos;
        }

        public bool IsAtLowerBound(GameObject followTarget){
            if (followTarget.transform.position.y - cameraHalfHeigth <= lowerBound) {
                return true;
            } 
            return false;
        }

        public bool IsAtSideBound(GameObject followTarget) {
            float testLeft = followTarget.transform.position.x - cameraWidth / 2;
            float testRight = followTarget.transform.position.x + cameraWidth / 2;

            if (testLeft <= leftBound )
            {
                return true;
            } else if ( testRight >= rightBound) {
                return true;
            }
            return false;
        }
    }
}