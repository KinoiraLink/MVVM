using System;
using MVVM;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ViewModel;

namespace View
{
    public class MainPanel : ViewBase<ScoreItemViewModel>
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
            InitViewModel(_scoreItemViewModel);
            //BindText(nickName,nameof(_scoreItemViewModel.ItemNick));
            //DataBind<string>((x) => nickName.text = x, nameof(_scoreItemViewModel.ItemNick));
            DataBind<string, string>(
                (x) => nickName.text = x,
                nameof(_scoreItemViewModel.ItemNick),
                inputNick.onSubmit,
                (x) => _scoreItemViewModel.ChangeName(x)
            );
            //BindText(score,nameof(_scoreItemViewModel.ItemScore),()=>_scoreItemViewModel.ItemScore.ToString());
            //DataBind<int>((x) => score.text = x.ToString(), nameof(_scoreItemViewModel.ItemScore));
            DataBind<int>(
                (x) => score.text = x.ToString(),
                nameof(_scoreItemViewModel.ItemScore),
                btnChange.onClick,
                _scoreItemViewModel.AddItemScore
            );
        }

        private void OnDestroy()
        {
            Dispose();
        }

    }


}
