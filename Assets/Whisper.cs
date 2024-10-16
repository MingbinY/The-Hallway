using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisper : MonoBehaviour
{
    bool triggered = false;
    public List<AudioClip> clipList = new List<AudioClip>();

    public bool isStopTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) { return; }
        if (!isStopTrigger)
        {
            if (other.GetComponent<PlayerManager>() != null)
            {
                triggered = true;
                GetComponent<AudioSource>().PlayOneShot(clipList[Random.Range(0, clipList.Count)]);
            }
        }
        else
        {
            Whisper[] whispers = FindObjectsOfType<Whisper>();
            foreach (Whisper wh in whispers)
            {
                if (!wh.isStopTrigger)
                {
                    wh.GetComponent<AudioSource>().Stop();
                    Destroy(wh.gameObject);
                }
            }
        }
       
    }
}
