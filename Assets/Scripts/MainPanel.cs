using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text score;
    [SerializeField] private Button btnChange;
    [SerializeField] private InputField inputNick;

    public int Score { get; set; }
    public string NickName { get; set; }

    private void Awake()
    {
        inputNick.onSubmit.AddListener((s) =>
        {
            NickName = s;
            UpdateUI();
        });
        
        btnChange.onClick.AddListener(() =>
        {
            Score++;
            UpdateUI();
        });
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        nickName.text = NickName;
        score.text = Score.ToString();
    }
}
