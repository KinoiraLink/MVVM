using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public class ViewBase<T> : MonoBehaviour where T : ViewModelBase
    {
        private T _viewModel;
        
        private Dictionary<string, Action> _bindableText;
        
        /// <summary>
        /// 初始化View的ViewModel
        /// </summary>
        /// <param name="viewModel"></param>
        public void InitViewModel(T viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }
        
        /// <summary>
        /// 绑定Text控件与数据
        /// 使用Func 委托来获取数据值，引用属性()=>_viewModel.property
        /// </summary>
        /// <param name="text">Text控件</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyGet">属性获取</param>
        protected void BindText( Text text,string propertyName , Func<string> propertyGet)
        {
            if (_bindableText == null) _bindableText = new Dictionary<string, Action>();
            Action textUpdate = () => text.text = propertyGet();
            _bindableText[propertyName] = textUpdate;
            textUpdate();
        }
        
        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_bindableText.TryGetValue(e.PropertyName, out var textUpdate))
            {
                textUpdate?.Invoke();
            }
        }
    }
}