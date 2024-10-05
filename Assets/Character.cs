using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int level = 1;
    public Image characterImage;  // อ้างอิงถึงตัวละครที่จะแสดงใน UI
    public Sprite eggSprite, childSprite, teenSprite, adultSprite;  // Sprite แต่ละเฟส
    public Text levelText;
    public Slider healthBar, hungerBar;
    public GameObject dialogBox;  // Dialog box ที่จะใช้เมื่อคลิกตัวละคร
    public Text dialogText;

    void Start()
    {
        UpdateCharacter();
        UpdateUI();
    }

    void UpdateCharacter()
    {
        // เปลี่ยนเฟสตามเลเวล
        if (level < 15)
        {
            characterImage.sprite = eggSprite;
        }
        else if (level < 30)
        {
            characterImage.sprite = childSprite;
        }
        else if (level < 45)
        {
            characterImage.sprite = teenSprite;
        }
        else
        {
            characterImage.sprite = adultSprite;
        }
    }

    public void GainLevel(int amount)
    {
        level += amount;
        UpdateCharacter();
        UpdateUI();
    }

    void UpdateUI()
    {
        levelText.text = "Level: " + level;
        healthBar.value = healthBar.maxValue;  // ตั้งค่าให้เต็มหลอด (คุณสามารถเปลี่ยนให้มีการลดลงตามเกมเพลย์)
        hungerBar.value = hungerBar.maxValue;
    }

    void OnMouseDown()
    {
        ShowDialog("Hello! Let's talk.");
    }

    void ShowDialog(string message)
    {
        dialogBox.SetActive(true);
        dialogText.text = message;

        // ซ่อน Dialog หลังจากเวลาผ่านไป
        Invoke("HideDialog", 3f);
    }

    void HideDialog()
    {
        dialogBox.SetActive(false);
    }
}
