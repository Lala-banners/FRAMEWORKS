using UnityEngine;

using NullReferenceException = System.NullReferenceException; //Same for null reference exceptions - gives feedback to users and us about specific errors that occur for specific reasons
using InvalidOperationException = System.InvalidOperationException; //If there is one component of UnityEngine that we want to access

namespace BreadAndButter.Mobile //Make namespace - tip for specificity, do namespace.module name
{
    public class MobileInput : MonoBehaviour
    {
        /// <summary>
        /// Creating a Framework. 
        /// 1. Namespace
        /// 2. Make singleton (static instance that can be directly referenced without getting the object)
        /// 3. Make lamda/global variable (=>)
        /// 4. Make function to initialise system
        /// 5. Reference using namespace in all relevant scripts including modules
        /// </summary>

        //Has mobile input system been initialised? Detecting if instance is not null
        public static bool Initialised => instance != null;

        //Singleton reference instance
        private static MobileInput instance = null;

        /// <summary>
        /// If system isn't already set up, this will instantiate mobile input prefab and assign the static reference.
        /// </summary>
        public static void Initialise()
        {
            //If the mobile input is already initialised, throw an Exception to tell the user they dun goofed.
            if(Initialised)
            {
                throw new InvalidOperationException("Mobile Input already initialised!");
            }

            //Load the Mobile Input Prefab and instantiate it, setting the instance
            MobileInput prefabInstance = Resources.Load<MobileInput>("Mobile Input Prefab");
            instance = Instantiate(prefabInstance);

            //Changed the instaniated object name and mark it to not be destroyed (Remove clone appearing in heirarchy for clarity)
            instance.gameObject.name = "Mobile Input";
            DontDestroyOnLoad(instance.gameObject);
        }
    }
}