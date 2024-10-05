using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    public void OnPointerClicked(PointerEventData eventData)
    {
        FoodClicked();
    }

    public void FoodClicked()
    {
        Feeding feedingScript = FindObjectOfType<Feeding>();
        if (feedingScript != null)
        {
            feedingScript.IncreaseHunger();
        }
    }
    
}
