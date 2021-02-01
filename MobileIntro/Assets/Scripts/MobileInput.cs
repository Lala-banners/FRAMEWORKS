using UnityEngine;

public class MobileInput : MonoBehaviour
{
    //This script will handle swiping/flicking

    #region Properties 
    /// <summary>
    /// The direction that the flick last occured, positive infinity means no flick occured
    /// </summary>
    public static Vector2 Flick { get; private set; }
    /// <summary>
    /// How hard and far the player flicked, positive infinity means no flick
    /// </summary>
    public static float FlickPower { get; private set; } = float.PositiveInfinity;
    #endregion

    #region Variables
    //How long the swipe has been running for
    private float swipeTime = 0;

    //The origin point for the occuring swipe
    private Vector2 swipeOrigin = Vector2.positiveInfinity;

    //The initialising finger index
    private int initialFingerIndex = -1;
    #endregion

    // Update is called once per frame
    void Update()
    {
        //Check if there is any touches
        if (Input.touchCount > 0)
        {
            // Loop through all swipes
            foreach (Touch touch in Input.touches)
            {
                //Is this the first touch in the swipe and the first frame there was a touch?
                if(touch.phase == TouchPhase.Began && swipeOrigin.Equals(Vector2.positiveInfinity))
                {
                    swipeOrigin = touch.position;
                    initialFingerIndex = touch.fingerId; 
                }
                //Is this a completed flick?
                else if (touch.phase == TouchPhase.Ended && touch.fingerId == initialFingerIndex && swipeTime < 1) 
                {
                    CalculateFlick(touch.position);
                }
            }

            //Increment the time this swipe has been running
            swipeTime += Time.deltaTime;
        }
        //There isn't so reset swipe data
        else
        {
            ResetSwipe();
        }
    }

    /// <summary>
    /// Calculates the flick based on the origin and the final touch position.
    /// </summary>
    /// <param name="_endTouchPos">The position the touch was when it was ended.</param>
    private void CalculateFlick(Vector2 _endTouchPos)
    {
        //Calculate the flick power
        Vector2 heading = swipeOrigin - _endTouchPos;
        FlickPower = heading.magnitude;
        Flick = heading.normalized;

        //Reset Swipe Origin
        swipeOrigin = Vector2.positiveInfinity;
    }

    /// <summary>
    /// Sets the swipe data back to positive infinity.
    /// </summary>
    private void ResetSwipe()
    {
        Flick = Vector2.positiveInfinity;
        FlickPower = float.PositiveInfinity;
        swipeOrigin = Vector2.positiveInfinity;
        swipeTime = 0;
        initialFingerIndex = -1;
    }
}
