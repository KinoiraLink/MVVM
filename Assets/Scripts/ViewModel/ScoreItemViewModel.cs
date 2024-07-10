using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class ScoreItemViewModel : INotifyPropertyChanged
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
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}