using UnityEngine;
using TMPro;  // นำเข้า TextMeshPro

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;  // Dialog box ที่จะใช้แสดงข้อความ
    public TextMeshProUGUI dialogText;  // ใช้ TextMeshPro แทน Text ปกติ

    // ฟังก์ชันนี้ใช้เพื่อแสดงข้อความใน Dialog Box
    public void ShowDialog(string message)
    {
        dialogBox.SetActive(true);  // เปิด Dialog Box
        dialogText.text = message;  // แสดงข้อความใน Dialog ด้วย TextMeshPro
    }

    // ฟังก์ชันนี้ใช้เพื่อซ่อน Dialog Box
    public void HideDialog()
    {
        dialogBox.SetActive(false);  // ปิด Dialog Box
    }

    // ฟังก์ชันแสดง Dialog และซ่อนหลังจากเวลาผ่านไป
    public void ShowDialogForDuration(string message, float duration)
    {
        ShowDialog(message);  // แสดงข้อความ
        Invoke("HideDialog", duration);  // ซ่อน Dialog หลังจากเวลาที่กำหนด
    }

    // ฟังก์ชันที่ใช้เมื่อคลิก
    void OnMouseDown()
    {
        // เมื่อคลิกให้แสดง Dialog Box พร้อมข้อความเป็นเวลา 5 วินาที
        ShowDialogForDuration("Hello! Let's talk.", 5f);
    }
}
