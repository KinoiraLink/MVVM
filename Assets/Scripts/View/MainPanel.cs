using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using ViewModel;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Text nickName;
    [SerializeField] private Text score;
    [SerializeField] private Button btnChange;
    [SerializeField] private InputField inputNick;

    private ScoreItem _scoreItem;
    private ScoreItemViewModel _scoreItemViewModel;

    private void Awake()
    {
        _scoreItem = new ScoreItem()
        {
            id = 1,
            nickName = "Nick",
            score = 79
        };
        _scoreItemViewModel = new ScoreItemViewModel(_scoreItem);
        _scoreItemViewModel.PropertyChanged +=  OnPropertyChanged;
        inputNick.onSubmit.AddListener(_scoreItemViewModel.ChangeName);
        btnChange.onClick.AddListener(_scoreItemViewModel.AddItemScore);
        UpdateUI();
    }
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (nameof(_scoreItemViewModel.ItemScore) == e.PropertyName)
        {
            UpdateUI();
        }
        if (nameof(_scoreItemViewModel.ItemNick) == e.PropertyName)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        nickName.text = _scoreItemViewModel.ItemNick.ToString();
        score.text = _scoreItemViewModel.ItemScore.ToString();
    }
}
