using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinDoctors.Base;
using XamarinDoctors.Models;
using XamarinDoctors.Repositories;
using XamarinDoctors.Views;

namespace XamarinDoctors.ViewModels
{
    public class DoctorModel : ViewModelBase
    {
        private Doctor _Doctor;
        public Doctor Doctor
        {
            get { return _Doctor; }
            set
            {
                _Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }
        RepositoryDoctor repo;
        public DoctorModel()
        {
            repo = new RepositoryDoctor();
            if (Doctor == null)
                Doctor = new Doctor();
        }
        public Command InsertDoctor
        {
            get
            {
                return new Command(async() => {
                    await repo.InsertDoctor(this.Doctor);
                    MessagingCenter.Send<DoctorsViewModel>(App.Locator.DoctorsViewModel, "INSERT");
                });
            }
        }
        public Command DeleteDoctor
        {
            get
            {
                return new Command(async () => {
                    await repo.DeleteDoctor(this.Doctor.Id);
                    MessagingCenter.Send<DoctorsViewModel>(App.Locator.DoctorsViewModel, "DELETE");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
        public Command UpdateDoctor
        {
            get
            {
                return new Command(async () => {
                    await repo.UpdateDoctor(this.Doctor.Id, this.Doctor);
                    MessagingCenter.Send<DoctorsViewModel>(App.Locator.DoctorsViewModel, "UPDATE");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
