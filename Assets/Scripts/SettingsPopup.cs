using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Messenger.Broadcast(GameEvent.SETTINGS_OPEN);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        Messenger.Broadcast(GameEvent.SETTINGS_CLOSE);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log($"Name: {name}");
    }
    public void OnSpeedValue(float speed)
    {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
