using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cronometro;
    [SerializeField] private GameObject go_Pause;

    [SerializeField] private GameObject go_Result;
    [SerializeField] private TextMeshProUGUI txt_Result;
    [SerializeField] private TextMeshProUGUI txt_TimerFinal;
    
    private float timerElapsed;

    private int minutes, seconds;

    private void Start()
    {
        Player.onGameOver += SetResultUi;
    }

    private void OnDestroy()
    {
        Player.onGameOver -= SetResultUi;
    }

    //public static UIManager instance = null;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Update()
    {
        timerElapsed += Time.deltaTime;

        minutes = (int)(timerElapsed / 60f);
        seconds = (int)(timerElapsed - minutes * 60f);

        string txt_timer = string.Format("{0:00} : {1:00}", minutes, seconds);
        cronometro.text = txt_timer;
    }

    public void SetResultUi(bool result)
    {
        go_Result.SetActive(true);

        txt_Result.text = result ? "GANASTE" : "PERDISTE";
        txt_TimerFinal.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnClick(string id )
    {
        switch (id)
        {
            case "pause":
                Time.timeScale = 0f;
                go_Pause.SetActive(true);
                break;

            case "continue":
                Time.timeScale = 1f;
                go_Pause.SetActive(false);
                break;

            case "try-again":
                Time.timeScale = 1f;
                SceneManager.LoadScene("SampleScene");
                break;

            case "menu":
                Time.timeScale = 1f;
                SceneManager.LoadScene("Menu");
                break;

            default:
                break;
        }
    }
}
