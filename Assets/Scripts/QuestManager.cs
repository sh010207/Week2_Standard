using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager _instance;

    public MonsterQuestDataSO monsterData;
    public EncounterQuestDataSO encounterData;

    public List<QuestDataSO> Quests = new List<QuestDataSO>();

    // [구현사항 2] 정적 프로퍼티 정의
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

    // [구현사항 3] 인스턴스 검사 로직
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
            Debug.Log($"Quest{data.QuestNPC} - {data.QuestName}(최소레벨{data.QuestRequiredLevel})");
            if (data.GetType() == typeof(MonsterQuestDataSO))
            {
                Debug.Log($"{monsterData.monsterName}을 잡아주세요! ({monsterData.monsterName}" +
                    $" {monsterData.mosnterNum}마리 소탕)");
            }
            else if(data.GetType() == typeof(EncounterQuestDataSO))
            {
                Debug.Log($"{encounterData.desc} (보상 : {encounterData.reward})");
            }
        }
    }
}
