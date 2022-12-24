using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugUltil
{
    public class DebugUltil : MonoBehaviour
    {
        /// <summary>
        /// Checks if componenets attached to game object are null
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public static bool CheckComponents(GameObject gameObject)
        {
            Component[] components = gameObject.GetComponents<Component>();
            foreach (Component component in components)
            {
                if (component == null)
                {
                    Debug.LogWarning($"Missing Component {component} on {gameObject.name}");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if specific components gameObject called upon are null
        /// </summary>
        /// <param name="object"></param>
        public static bool CheckComponents(GameObject gameObject, object[] objects) 
        {
            Component[] components = gameObject.GetComponents<Component>();
            foreach (Component component in components)
            {
                if (component == null)
                {
                    Debug.LogWarning($"Missing Component: {component} on {gameObject.name}");
                    return false;
                }
            }
            return true;
        }

        

    }
}