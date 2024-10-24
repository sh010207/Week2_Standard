using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "ScriptableObject/EncounterQuest", order = 2)]

public class EncounterQuestDataSO : QuestDataSO
{
    public string desc;
    public int reward = 200;
}
