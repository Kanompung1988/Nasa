using UnityEngine;
using UnityEngine.UI;
using TMPro;  // นำเข้า TextMeshPro

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject[] _charactorImage;
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
            _charactorImage[0].SetActive(true);
        }
        else if (level < 30)
        {
            _charactorImage[1].SetActive(true);
        }
        else if (level < 45)
        {
            _charactorImage[2].SetActive(true);
        }
        else
        {
            _charactorImage[3].SetActive(true);
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
        string[] textArray = { "Hi Let's Talk!", "How are you my Hero", "Please play with me", "Feed me please ;3" };
        int randomTextIndex = Random.Range(0, textArray.Length);
        string randomText = textArray[randomTextIndex];
        dialogManager.ShowDialogForDuration(randomText, 3f);
        GainLevel(1);  // เมื่อคลิกให้เพิ่มเลเวล 1
    }
}