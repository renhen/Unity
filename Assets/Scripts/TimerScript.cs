using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI secText;
    public GameObject winTextObject;
    public float delayBeforeExit;

    private bool isEndGame = false;
    private float secundomer = 0F;
    private int minute = 0;
    private float end_seundomer = 0F;

    // Update is called once per frame
    void Update()
    {
        if (!isEndGame)
        {
            secundomer += Time.deltaTime;
            if (secundomer.CompareTo(60F) >= 0)
            {
                secundomer = 0F;
                minute++;
            }
            secText.text = string.Format("{0,2:00}:{1,2:00}", minute, (int)System.Math.Floor(secundomer));
            if (winTextObject.activeSelf)
            {
                isEndGame = true;
                RecordData new_store = new RecordData(minute, secundomer);
                if (LeaderboardScript.savedGames.IndexOf(new_store) == -1) 
                {
                    LeaderboardScript.savedGames.Add(new_store);
                }
                
            }
        }
        else
        {
            end_seundomer += Time.deltaTime;
            if (end_seundomer.CompareTo(delayBeforeExit) >= 0)
            {
                Debug.Log("exit");
                LeaderboardScript.Save();
                Application.LoadLevel(0);
            }
            
        }
    }
}
