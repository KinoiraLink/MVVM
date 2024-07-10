# 基于 `INotifyPropertyChanged` 的 MVVM 简单实现
## 使用
### Model 层
Model 层由于 ViewModel 层用了 INotifyPropertyChanged 的新的触发方法 Model 层只能用字段，使用原触发方法可以用属性。
```csharp
public class ModelTemplate
{
    public int id;
    public string title;
    public DateTime releaseDate;
    public string genre;
    public decimal price;
}
```
### ViewModel 层
ViewModel 需要继承 `ViewModelBase` 类。属性：
```csharp
public int ItemScore
{
    get => _scoreItem.score;
    set => SetField (ref _scoreItem.score, value);// 新触发方法
}
```
### View 层
View 层需要继承 `ViewBase<T>` 类。
需要使用 InitViewModel () 方法初始化 ViewModel。
需要使用 BindText () 方法绑定 UI。
BindText () 参数分别为 UI 控件、ViewModel 属性名、ViewModel 属性的 get 委托。

```csharp
InitViewModel (_scoreItemViewModel);
BindText (nickName,nameof (_scoreItemViewModel.ItemNick),()=>_scoreItemViewModel.ItemNick);
```

## 参考
[数据绑定和 MVVM](https://learn.microsoft.com/zh-cn/dotnet/maui/xaml/fundamentals/mvvm?view=net-maui-8.0)

[Model-View-ViewModel (MVVM)](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)

[Input Field](https://docs.unity3d.com/Packages/com.unity.ugui@3.0/manual/script-InputField.html#events)

[INotifyPropertyChanged](https://learn.microsoft.com/zh-cn/dotnet/api/system.componentmodel.inotifypropertychanged?view=netstandard-2.1#events)

[PropertyChangedEventHandler 委托](https://learn.microsoft.com/zh-cn/dotnet/api/system.componentmodel.propertychangedeventhandler?view=netstandard-2.1)

[GPTchat: 属性的引用]()


## 重构
### v0.0.00
- [x] 新建项目
- [x] 初始化场景

### v0.0.01
- [x] 普通 UI 脚本

### v0.0.02
- [x] 分离 Model
- [x] 分离 ViewModel
### v0.0.03
- [x] 抽象 ViewModel 
- [x] 抽象 View 

