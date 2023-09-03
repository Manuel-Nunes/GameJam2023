using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    private bool isAccessCardPickedUp = false;
    private bool isOxygenMaskPickedUp = false;
    // Start is called before the first frame update
    public Text hint;
    void Update()
    {

        isAccessCardPickedUp = GameObject.FindGameObjectWithTag(" Storage Place Access Card") != null;
        isOxygenMaskPickedUp =  GameObject.FindGameObjectWithTag(" Storage Place Oxygen Mask") != null;

    }

    // Update is called once per frame
    public void HintClick()
    {   
        // hint.SetActive(true);
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
