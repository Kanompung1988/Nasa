using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Feeding : MonoBehaviour
{
    public Button startFeeding;
    public Button stopFeeding;
    public GameObject foodSprite; 
    public Canvas canvas; 
    public Slider healthBar, hungerBar;

    private void Start()
    {
        // add listener to buttons
        startFeeding.onClick.AddListener(StartFeeding);  
        stopFeeding.onClick.AddListener(StopFeeding);
    }

    private void StopFeeding()
    {
        // switch to idle scene

    }

    public void IncreaseHunger()
    {
        // incraese hunger bar by value (can be customize later)
        hungerBar.value += 10;
    }

    private void StartFeeding()
    {
        // switch to feeding scene

        //spawn food at random position
        GameObject food = Instantiate(foodSprite, GetRandomPosition(), Quaternion.identity, canvas.transform);
    }

    private Vector2 GetRandomPosition()
    {
        // get ramdom position from in the canvas as (x,y) vector
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        float xPos = Random.Range(0, canvasRect.rect.width);
        float yPos = Random.Range(0, canvasRect.rect.height);
        return new Vector2(xPos, yPos);
    }
}
