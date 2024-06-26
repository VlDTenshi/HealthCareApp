﻿using HealthCareApp.View;

namespace HealthCareApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); 
        }

        protected override async void OnStart()
        {
            base.OnStart();

            MainPage = new NavigationPage(new LoadingPage());

            await Task.Delay(5000);

            MainPage = new AppShell();
        }
    }
}
