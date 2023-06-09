﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFirebaseApp.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentEntry : ContentPage
    {

        StudentRepository repository = new StudentRepository();
        public StudentEntry()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            var name = TxtName.Text;
            var email = TxtEmail.Text;
            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Warning", "Please enter your name", "Cancel");
            }
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Please enter your Email", "Cancel");
            }

            StudentModel studentModel = new StudentModel();
            studentModel.Name = name;
            studentModel.Email = email;
            var isSaved = await repository.Save(studentModel);
            if (isSaved)
            {
                await DisplayAlert("Information", "Student has been saved", "OK");
                Clear();
            }
            else
            {
                await DisplayAlert("Error", "Student saved failed", "OK");
            }

        }

        public void Clear()
        {
            TxtName.Text = string.Empty;
            TxtEmail.Text = string.Empty;
        }
    }
}