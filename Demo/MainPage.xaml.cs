﻿using Demo.ViewModels;

namespace Demo
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }


    }
}