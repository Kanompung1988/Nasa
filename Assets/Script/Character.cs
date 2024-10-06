using UnityEngine;
using UnityEngine.UI;
using TMPro;  // นำเข้า TextMeshPro

public class Character : MonoBehaviour
{
    public int level = 1;
    public GameObject characterImage;  // อ้างอิงถึงตัวละครหลักที่มีลูกย่อย
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
        // ปิดลูกของ Character Image ทั้งหมดก่อน
        foreach (Transform child in characterImage.transform)
        {
            child.gameObject.SetActive(false);  // ปิดลูกย่อยทั้งหมดก่อน
        }

        // เปลี่ยน Sprite หรือ GameObject ตามเลเวล
        if (level < 15)
        {
            characterImage.transform.Find("1").gameObject.SetActive(true);  // เปิดใช้งานลูกที่ 1
        }
        else if (level < 30)
        {
            characterImage.transform.Find("2").gameObject.SetActive(true);  // เปิดใช้งานลูกที่ 2
        }
        else if (level < 45)
        {
            characterImage.transform.Find("3").gameObject.SetActive(true);  // เปิดใช้งานลูกที่ 3
        }
        else
        {
            characterImage.transform.Find("4").gameObject.SetActive(true);  // เปิดใช้งานลูกที่ 4
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
        // เรียกใช้ Dia   logManager เพื่อแสดงข้อความเมื่อคลิกที่ตัวละคร
        dialogManager.ShowDialogForDuration("Hello! Let's talk.", 3f);
        GainLevel(1);  // เมื่อคลิกให้เพิ่มเลเวล 1
    }
}