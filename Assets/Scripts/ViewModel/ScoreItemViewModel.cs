using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM;

namespace ViewModel
{
    public class ScoreItemViewModel : ViewModelBase
    {

        private ScoreItem _scoreItem;

        public ScoreItemViewModel(ScoreItem scoreItem)
        {
            _scoreItem = scoreItem;
        }
        
        public string ItemNick
        {
            get => _scoreItem.nickName;
            set => SetField(ref _scoreItem.nickName,value);
        }

        public int ItemScore
        {
            get => _scoreItem.score;
            set => SetField(ref _scoreItem.score, value);
        }

        public void AddItemScore()
        {
            ItemScore++;
        }

        public void ChangeName(string name)
        {
            ItemNick = name;
        }
        
    }
}