using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreadAndButter
{
    public abstract class RunnableBehaviour : MonoBehaviour, IRunnable
    {
        public bool Enabled { get; set; }

        public void Run(params object[] _params)
        {
            
        }

        public void Setup(params object[] _params)
        {
            
        }

        protected abstract void OnSetup(params object[] _params);
        protected abstract void OnRun(params object[] _params);

    }
}
