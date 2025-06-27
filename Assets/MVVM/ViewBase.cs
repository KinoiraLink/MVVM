using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MVVM
{
    
    

    public class ViewBase<T> : MonoBehaviour,IDisposable where T : ViewModelBase
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

        public void Dispose()
        {
            _viewModel.PropertyChanged -= ViewModelOnPropertyChanged;
            _viewModel = null;
            if (_bindableText != null)
            {
                _bindableText.Clear();
                _bindableText = null;
            }
        }

        /// <summary>
        /// 绑定Text控件与数据
        /// 使用Func 委托来获取数据值，引用属性()=>_viewModel.property
        /// </summary>
        /// <param name="text">Text控件</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyGet">属性获取</param>
        protected void BindText(Text text, string propertyName, Func<string> propertyGet)
        {
            if (_bindableText == null) _bindableText = new Dictionary<string, Action>();
            Action textUpdate = () => text.text = propertyGet();
            _bindableText[propertyName] = textUpdate;
            textUpdate();
        }

        protected void BindText(Text text, string propertyName)
        {
            BindText(text, propertyName, () => _viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel)?.ToString() ?? string.Empty);
        }

        protected void DataBind<TValue>(Action<TValue> action, string propertyName, Func<TValue> propertyGet)
        {
            if (_bindableText == null) _bindableText = new Dictionary<string, Action>();
            Action dataUpdate = () => action(propertyGet());
            if(string.IsNullOrEmpty(propertyName))
            {
                Debug.LogError("Property name cannot be null or empty.");
                return;
            }
            _bindableText[propertyName] = dataUpdate;
            dataUpdate();
        }

        protected void DataBind<TValue>(Action<TValue> action, string propertyName)
        {
            DataBind(action, propertyName, () => (TValue)_viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel));
        }

        protected void DataBind<TValue, TEventValue>(Action<TValue> action, string propertyName,
            Func<TValue> propertyGet, UnityEvent<TEventValue> unityEvent, UnityAction<TEventValue> propertySet)
        { 
            DataBind(action, propertyName, propertyGet);
            unityEvent.AddListener(propertySet);
        }

        protected void DataBind<TValue, TEventValue>(Action<TValue> action, string propertyName,
             UnityEvent<TEventValue> unityEvent, UnityAction<TEventValue> propertySet)
        {
            DataBind(action, propertyName, () => (TValue)_viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel));
            unityEvent.AddListener(propertySet);
        }

        protected void DataBind<TValue>(Action<TValue> action, string propertyName,
            Func<TValue> propertyGet, UnityEvent unityEvent, UnityAction propertySet)
        {
            DataBind(action, propertyName, propertyGet);
            unityEvent.AddListener(propertySet);
        }

        protected void DataBind<TValue>(Action<TValue> action, string propertyName, UnityEvent unityEvent, UnityAction propertySet)
        {
            DataBind(action, propertyName, () => (TValue)_viewModel.GetType().GetProperty(propertyName)?.GetValue(_viewModel));
            unityEvent.AddListener(propertySet);
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