using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager _instance;

    public MonsterQuestDataSO monsterData;
    public EncounterQuestDataSO encounterData;

    public List<QuestDataSO> Quests = new List<QuestDataSO>();

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<QuestManager>();
            }
            else if(_instance == null)
            {
                _instance = new GameObject("QuestManager").AddComponent<QuestManager>();
            }
            return _instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
        }
        else
        {
            if(_instance == null)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Start()
    {
        for(int i = 0; i < Quests.Count; i++)
        {
            QuestDataSO data = Quests[i];
            Debug.Log($"Quest{data.QuestNPC} - {data.QuestName}(�ּҷ���{data.QuestRequiredLevel})");
            if (data.GetType() == typeof(MonsterQuestDataSO))
            {
                Debug.Log($"{monsterData.monsterName}�� ����ּ���! ({monsterData.monsterName}" +
                    $" {monsterData.mosnterNum}���� ����)");
            }
            else if(data.GetType() == typeof(EncounterQuestDataSO))
            {
                Debug.Log($"{encounterData.desc} (���� : {encounterData.reward})");
            }
        }
    }
}
