using UnityEngine;
using TMPro;  // นำเข้า TextMeshPro

public class LevelManager : MonoBehaviour
{
    public int clickCounter = 0;  // ตัวนับการกด
    public int clicksPerLevel = 4;  // จำนวนการกดที่ต้องใช้เพื่อเพิ่มเลเวล
    public TextMeshProUGUI levelText;  // ใช้ TextMeshPro สำหรับแสดงเลเวล

    public Character character;  // อ้างอิงถึงสคริปต์ Character

    void Start()
    {
        UpdateLevelText();  // อัปเดตข้อความแสดงเลเวลในตอนเริ่มต้น
    }

    // ฟังก์ชันนี้จะถูกเรียกเมื่อคลิกที่ปุ่มหรือวัตถุเพื่อเพิ่มจำนวนการกด
    public void IncreaseClick()
    {
        clickCounter++;  // เพิ่มตัวนับการกด 1
        if (clickCounter >= clicksPerLevel)  // ถ้ากดครบ 4 ครั้ง
        {
            character.GainLevel(1);  // เรียกใช้ฟังก์ชันเพิ่มเลเวลจากสคริปต์ Character
            clickCounter = 0;  // รีเซ็ตตัวนับการกด
            UpdateLevelText();  // อัปเดต UI แสดงผลเลเวลใหม่
        }
    }

    // ฟังก์ชันนี้ใช้เพื่ออัปเดตข้อความแสดงเลเวลใน UI
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + character.level;  // อัปเดตข้อความใน TextMeshPro ตามเลเวลของตัวละคร
        }
    }
}
