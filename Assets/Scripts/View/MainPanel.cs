using MVVM;
using UnityEngine;
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
            BindText(nickName,nameof(_scoreItemViewModel.ItemNick),()=>_scoreItemViewModel.ItemNick);
            BindText(score,nameof(_scoreItemViewModel.ItemScore),()=>_scoreItemViewModel.ItemScore.ToString());
            inputNick.onSubmit.AddListener(_scoreItemViewModel.ChangeName);
            btnChange.onClick.AddListener(_scoreItemViewModel.AddItemScore);
        }
    }
}
