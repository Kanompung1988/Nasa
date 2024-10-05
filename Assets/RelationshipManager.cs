using UnityEngine;
using UnityEngine.UI;
using TMPro;  // นำเข้า TextMeshPro

public class RelationshipBarManager : MonoBehaviour
{
    public Slider relationshipBar;  // อ้างอิงถึง Slider ที่เป็นหลอดค่าความสัมพันธ์
    public TextMeshProUGUI relationshipText;  // อ้างอิงถึง TextMeshPro สำหรับแสดงค่าความสัมพันธ์
    public float maxRelationship = 100f;  // ค่าความสัมพันธ์สูงสุด
    public float currentRelationship;  // ค่าความสัมพันธ์ปัจจุบัน

    void Start()
    {
        currentRelationship = 0f;  // เริ่มต้นค่าความสัมพันธ์ที่ 0
        relationshipBar.maxValue = maxRelationship;  // ตั้งค่าหลอดความสัมพันธ์ให้มีค่าเต็มเท่ากับ maxRelationship
        relationshipBar.value = currentRelationship;  // ตั้งค่าให้เริ่มต้นหลอดที่ 0
        UpdateRelationshipBar();  // เรียกใช้เพื่ออัปเดตค่าหลอดและข้อความเริ่มต้น
    }

    // ฟังก์ชันสำหรับเพิ่มค่าความสัมพันธ์
    public void IncreaseRelationship(float amount)
    {
        currentRelationship += amount;  // เพิ่มค่าความสัมพันธ์ตามค่าที่ส่งเข้ามา
        if (currentRelationship > maxRelationship)
        {
            currentRelationship = maxRelationship;  // ป้องกันไม่ให้เกินค่าความสัมพันธ์สูงสุด
        }
        UpdateRelationshipBar();  // อัปเดตค่าหลอดความสัมพันธ์ใน UI
    }

    // ฟังก์ชันอัปเดตค่าหลอดความสัมพันธ์ใน UI และอัปเดตข้อความ
    void UpdateRelationshipBar()
    {
        relationshipBar.value = currentRelationship;  // ตั้งค่าให้หลอดความสัมพันธ์แสดงค่าปัจจุบัน
        relationshipText.text = "Relationship: " + currentRelationship + "/" + maxRelationship;  // อัปเดตข้อความด้วย TextMeshPro
    }
}
