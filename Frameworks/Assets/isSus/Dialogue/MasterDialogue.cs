using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace isSus.Dialogue
{
    public class MasterDialogue : MonoBehaviour
    {
        #region Master Instance
        public static MasterDialogue instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
        #endregion



    }

    /// <summary>
    /// To keep track of actions made by player.
    /// </summary>
    public enum DialogueAbilities
    {
        Next,
        Bye,
        AccDec,
    }
}
