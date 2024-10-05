using UnityEngine;
using UnityEngine.UI;
using TMPro;  // นำเข้า TextMeshPro

public class Character : MonoBehaviour
{
    public int level = 1;
    public Image characterImage;  // ใช้ Image Component แทน GameObject เพื่อแสดงผล Sprite
    public Sprite sprite1, sprite2, sprite3, sprite4;  // สร้าง Sprite สำหรับแต่ละเฟส
    public TextMeshProUGUI levelText;  // ใช้ TextMeshPro แทน Text ปกติ
    public Slider healthBar, hungerBar;

    public DialogManager dialogManager;  // อ้างอิงถึง DialogManager

    void Start()
    {
        UpdateCharacter();
        UpdateUI();  // อัปเดต UI ตอนเริ่มต้นเกม
    }

    void UpdateCharacter()
    {
        // เปลี่ยน Sprite ตามเลเวล
        if (level < 15)
        {
            characterImage.sprite = sprite1;  // ใช้ Sprite1 สำหรับเลเวล < 15
        }
        else if (level < 30)
        {
            characterImage.sprite = sprite2;  // ใช้ Sprite2 สำหรับเลเวล 15-29
        }
        else if (level < 45)
        {
            characterImage.sprite = sprite3;  // ใช้ Sprite3 สำหรับเลเวล 30-44
        }
        else
        {
            characterImage.sprite = sprite4;  // ใช้ Sprite4 สำหรับเลเวล >= 45
        }
    }

    public void GainLevel(int amount)
    {
        level += amount;  // เพิ่มเลเวลตามค่าที่กำหนด
        UpdateCharacter();  // อัปเดตตัวละครตามเลเวลใหม่
        UpdateUI();  // อัปเดต UI แสดงผลเลเวลและค่าต่าง ๆ
    }

    public void UpdateUI()
    {
        levelText.text = "Lv: " + level;  // อัปเดตข้อความของ TextMeshPro เพื่อแสดงเลเวลใหม่
        hungerBar.value = hungerBar.maxValue;  // ตั้งค่าให้เต็มหลอดความหิว
    }

    void OnMouseDown()
    {
        // เรียกใช้ DialogManager เพื่อแสดงข้อความเมื่อคลิกที่ตัวละคร
        dialogManager.ShowDialogForDuration("Hello! Let's talk.", 3f);
        GainLevel(1);  // เมื่อคลิกให้เพิ่มเลเวล 1
    }
}
