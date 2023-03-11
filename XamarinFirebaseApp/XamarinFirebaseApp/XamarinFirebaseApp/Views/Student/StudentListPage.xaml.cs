using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentListPage : ContentPage
    {
        StudentRepository repository = new StudentRepository();
        public StudentListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
           var students = await repository.GetAll();
            StudentListView.ItemsSource = students;
        }

        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StudentEntry());
        }
    }
}