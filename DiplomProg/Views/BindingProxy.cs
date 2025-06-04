using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace DiplomProg.Views
{
    public class BindingProxy : AvaloniaObject
    {
        public static readonly StyledProperty<object> DataProperty =
            AvaloniaProperty.Register<BindingProxy, object>(nameof(Data));

        public object Data
        {
            get => GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public BindingProxy()
        {
            // Заменяем DataContextChanged на PropertyChanged
            this.GetObservable(DataContextProperty).Subscribe(_ =>
            {
                Data = DataContext;
            });
        }
    }
}
