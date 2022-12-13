using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] GameObject settingsObj;

    private int score;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreLabel.text = score.ToString();

        settingsPopup.Close();
    }

    private void OnEnemyHit()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !settingsObj.activeSelf) {
            settingsPopup.Open();
        }else if (Input.GetKeyDown(KeyCode.Escape) && settingsObj.activeSelf) {
            settingsPopup.Close();
        }
        
    }


    public void OnOpenSettings() {
        settingsPopup.Open();
    }

}
