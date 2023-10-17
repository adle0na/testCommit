using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UnityWebRequestGet());
    }

    IEnumerator UnityWebRequestGet()
    {
        string url = "http://localhost:8080/pet";

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.error == null)
        {
            // 받아온 JSON 데이터를 해석하여 출력
            string jsonText = www.downloadHandler.text;
            PetData petData = JsonUtility.FromJson<PetData>(jsonText);
            Debug.Log("Item Name: " + petData.itemName);
            Debug.Log("Price: " + petData.price);
        }
        else
        {
            Debug.Log("error: " + www.error);
        }
    }

    [System.Serializable]
    public class PetData
    {
        public string itemName;
        public float price;
    }
}