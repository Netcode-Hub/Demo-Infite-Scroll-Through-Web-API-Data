
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Demo.Models;
using Demo.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewModels
{
    public partial class MainPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly ITodoService todoService;
        [ObservableProperty]
        bool isBusy;

        List<Todo> todoList = new();
        int PageSize = 20;
        public ObservableRangeCollection<Todo> Todos { get; set; } = new ObservableRangeCollection<Todo>();
        public MainPageViewModel(ITodoService todoService)
        {
            this.todoService = todoService;
            LoadTodos();
        }

        [RelayCommand]
        private async Task LoadTodos()
        {
            try
            {
                IsBusy = true;
                todoList = await todoService.GetDotos();
                Todos.AddRange(todoList.Take(PageSize));
                IsBusy = false;
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }


        [RelayCommand]
        public async Task GetNextData()
        {
            try
            {
                if (Todos.Count > 0)
                {
                    Todos.AddRange(todoList.Skip(Todos.Count).Take(PageSize));
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }
    }
}
