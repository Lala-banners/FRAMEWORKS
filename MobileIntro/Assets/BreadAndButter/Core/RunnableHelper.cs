using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class that is going to make runnables easier
namespace BreadAndButter
{
    public class RunnableHelper
    {
        /// <summary>
        /// Attempts to retreive the runnable behaviour from the passed game object or its children.
        /// </summary>
        /// <param name="_runnable">The reference to runnable wukk be set to.</param>
        /// <param name="_from">The gameObject we are attempting to get a runnable from.</param>
        /// <returns></returns>
        public static bool Validate<T>(ref T _runnable, GameObject _from) where T : IRunnable
        {
            //If the passed runnable is already set, return true
            if (_runnable != null)
            {
                return true;   
            }

            //If the passed runnable isn't set, attempt to get it from the gameObject
            if (_runnable == null)
            {
                _runnable = _from.GetComponent<T>();

                //We successfully retreived the component, so return true
                if (_runnable != null)
                {
                    return true;
                }
            }

            //If this is not the case, attempt to get it from the gameObject children
            if (_runnable == null)
            {
                _runnable = _from.GetComponentInChildren<T>();

                //We successfully retreived the component, so return true
                if (_runnable != null)
                {
                    return true;
                }
            }
        }
    }
}
