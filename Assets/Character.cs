using UnityEngine;
using UnityEngine.UI;
using TMPro;  // นำเข้า TextMeshPro

public class Character : MonoBehaviour
{
    public int level = 1;
    public Image characterImage;  // อ้างอิงถึงตัวละครที่จะแสดงใน UI
    public Sprite eggSprite, childSprite, teenSprite, adultSprite;  // Sprite แต่ละเฟส
    public TextMeshProUGUI levelText;  // ใช้ TextMeshPro แทน Text ปกติ
    public Slider healthBar, hungerBar;

    public DialogManager dialogManager;  // อ้างอิงถึง DialogManager

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
        levelText.text = "Level: " + level;  // แสดงระดับเลเวลด้วย TextMeshPro
        healthBar.value = healthBar.maxValue;  // ตั้งค่าให้เต็มหลอด
        hungerBar.value = hungerBar.maxValue;
    }

    void OnMouseDown()
    {
        // เรียกใช้ DialogManager เพื่อแสดงข้อความเมื่อคลิกที่ตัวละคร
        dialogManager.ShowDialogForDuration("Hello! Let's talk.", 3f);
    }
}
