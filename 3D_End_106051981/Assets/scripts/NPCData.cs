using UnityEngine;

[CreateAssetMenu(fileName ="NPC資料", menuName ="KEON/NPC資料")]
public class npcData : ScriptableObject
{
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialougA;
    [Header("第二段對話"), TextArea(1, 5)]
    public string dialougB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string dialougC;
    [Header("任務需求數量")]
    public int count;
    [Header("已完成數量")]
    public int countCurrent;
}
