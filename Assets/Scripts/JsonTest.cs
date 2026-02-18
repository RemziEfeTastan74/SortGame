using System.IO;
using UnityEngine;

[System.Serializable]
public class EventData
{
    public int id;
    public string title;
    public int year;
}

[System.Serializable]
public class EventList
{
    public EventData[] events;
}

public class JsonTest : MonoBehaviour
{
    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "history.json");
        string json = File.ReadAllText(path);

        EventList list = JsonUtility.FromJson<EventList>(json);

        // Listeyi karıştır
        for (int i = 0; i < list.events.Length; i++)
        {
            EventData temp = list.events[i];
            int randomIndex = Random.Range(i, list.events.Length);
            list.events[i] = list.events[randomIndex];
            list.events[randomIndex] = temp;
        }

        // İlk 5 tanesini yazdır
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Random Secilen: " + list.events[i].title + " - " + list.events[i].year);
        }
    }

}
