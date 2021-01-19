using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.3f;



    public bool playerInArea;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "player")
        {
            playerInArea = false;
            StopDialog();
        }
    }

    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    }

    private void Dialog()
    {
        print(data.dialogA);
    }

    private IEnumerator Dialog()
    {
        dialog.SetActive(true);
        textContent.text = "";

        textName.text = name;

        for (int i = 0; i < data.dialogA.Length; i++)
        {
            textContent.text = data.dialogA[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
