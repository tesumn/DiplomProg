using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using DiplomProg.ViewModels;

namespace DiplomProg
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            var name = param.GetType().FullName?
                .Replace("ViewModel", "View", StringComparison.Ordinal);

            if (string.IsNullOrEmpty(name))
                return new TextBlock { Text = "Invalid ViewModel" };

            var type = Type.GetType(name);

            return type != null
                ? (Control)Activator.CreateInstance(type)!
                : new TextBlock { Text = "View Not Found: " + name };
        }

        public bool Match(object? data) => data is ViewModelBase;
    }
}