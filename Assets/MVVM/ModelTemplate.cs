using System;
namespace MVVM
{
    public class ModelTemplate
    {
        //由于ViewModel层用了INotifyPropertyChanged的新的触发方法Model层只能用字段，使用原触发方法可以用属性
        public int id;
        public string title;
        public DateTime releaseDate;
        public string genre;
        public decimal price;
    }
}