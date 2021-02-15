using UnityEngine;
using BreadAndButter.Mobile; //Butter on Toast

public class MobileTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MobileInput.Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        //Test joystick
        transform.position += transform.forward * MobileInput.GetJoystickAxis(JoystickAxis.Vertical) * Time.deltaTime;
        transform.position += transform.right * MobileInput.GetJoystickAxis(JoystickAxis.Horizontal) * Time.deltaTime;
    }
}
