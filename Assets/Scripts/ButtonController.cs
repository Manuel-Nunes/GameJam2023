using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private bool isOxygenMaskPickedUp = false;
    // Start is called before the first frame update
    public Text hint ;

    // Update is called once per frame
    public void HintClick()
    {  
        Debug.Log(GameObject.FindGameObjectWithTag("Access Card"));
        if (GameObject.FindGameObjectWithTag("Access Card") == null){
            isAccessCardPickedUp = true;
        }
        else {
            isAccessCardPickedUp = false;
        }

        if (GameObject.FindGameObjectWithTag("Oxygen Mask") == null){
             isOxygenMaskPickedUp = true;
        }
        else {
            isOxygenMaskPickedUp = false;
        }
     
        Debug.Log(isAccessCardPickedUp);
        Debug.Log(isOxygenMaskPickedUp);

        hint.enabled = true;
        if (!isAccessCardPickedUp && !isOxygenMaskPickedUp){
            hint.text = "someone lost their access card in the canteen";

        }
        else if (isAccessCardPickedUp && !isOxygenMaskPickedUp){
            hint.text = "seems like this card can access the power room";

        }
        else if (!isOxygenMaskPickedUp){
            hint.text = "we might run out of O2 soon....";

        }
        else if (isOxygenMaskPickedUp){
            hint.text = "phew~! I can now get to the cockpit";
        }
        else {
            hint.text = "is everyone in the canteen?";
        }
        // hint.SetActive(false);
    }
}
