using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public bool activeSelf;
    public int poolSize = 300;

    private void Start()
    {
        // 미리 poolSize만큼 생성
        for(int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.gameObject.SetActive(false);
            pool.Add(gameObject);
        }
    }

    public GameObject Get()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경 -> return
        GameObject go = pool.Find(obj => !obj.gameObject.activeSelf);
        go.SetActive(true);
        return go;
    }

public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.gameObject.SetActive(false);
    }
}
