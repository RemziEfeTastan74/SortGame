using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class HistoryManager : MonoBehaviour
{
    public static HistoryManager Instance;

    private List<HistoryData> allHistories;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        LoadHistories();
    }

    private void Start()
    {
        List<HistoryData> randomFive = GetRandomHistories(5);

        foreach (var item in randomFive)
        {
            Debug.Log(item.title);
        }
    }

    void LoadHistories()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("JSON/History");

        if (jsonFile == null)
        {
            Debug.LogError("History.json bulunamadı!");
            return;
        }

        HistoryListWrapper wrapper =
            JsonUtility.FromJson<HistoryListWrapper>(jsonFile.text);

        allHistories = wrapper.histories;

        Debug.Log("Toplam veri: " + allHistories.Count);
    }

    public List<HistoryData> GetRandomHistories(int count = 5)
    {
        return allHistories
            .OrderBy(x => Random.value)
            .Take(count)
            .ToList();
    }
}