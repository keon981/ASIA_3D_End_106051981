using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npc : MonoBehaviour
{
    [Header("NPC 資料")]
    public npcData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;


    public bool playerInArea;

    public enum npcState
    {
        FirstDialog,Missioning,Finish
    }

    public npcState state = npcState.FirstDialog;

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



    private IEnumerator Dialog()
    {
        dialog.SetActive(true);
        textContent.text = "";

        textName.text = name;

        string dialogString = data.dialogB;

        switch (state)
        {
            case npcState.FirstDialog:
                dialogString = data.dialogA;
                break;
            case npcState.Missioning:
                dialogString = data.dialogB;
                break;
            case npcState.Finish:
                dialogString = data.dialogC;
                break;
            default:
                break;
        }

        for (int i = 0; i < data.dialogA.Length; i++)
        {
            //print(data.dialogA[i]);
            textContent.text += data.dialogA[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
