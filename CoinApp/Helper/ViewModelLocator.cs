﻿using CoinApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace CoinApp.Helper
{
    public static class ViewModelLocator
    {
        private static readonly AppContainer Container;

        static ViewModelLocator() => Container = new AppContainer();

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached(
                "AutoWireViewModel",
                typeof(bool),
                typeof(ViewModelLocator),
                default(bool),
                propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) =>
            (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) =>
            bindable.SetValue(AutoWireViewModelProperty, value);

        public static T Resolve<T>() where T : class => Container.Resolve<T>();

        private static async void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType != null)
            {
                var viewModel = Container.Resolve(viewModelType) as BaseViewModel;
                view.BindingContext = viewModel;
            }
        }
    }
}
