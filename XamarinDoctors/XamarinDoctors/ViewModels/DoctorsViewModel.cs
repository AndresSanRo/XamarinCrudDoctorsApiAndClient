using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDoctors.Base;
using XamarinDoctors.Models;
using XamarinDoctors.Repositories;
using XamarinDoctors.Views;

namespace XamarinDoctors.ViewModels
{
    public class DoctorsViewModel : ViewModelBase
    {
        RepositoryDoctor repo;
        private ObservableCollection<Doctor> _Doctors;
        public ObservableCollection<Doctor> Doctors
        {
            get { return this._Doctors; }
            set
            {
                this._Doctors = value;
                OnPropertyChanged("Doctors");
            }
        }
        public Command ShowDoctorDetail
        {
            get
            {
                return new Command(async (doc) => {
                    DetailDoctor view = new DetailDoctor();
                    DoctorModel viewmodel = new DoctorModel();
                    viewmodel.Doctor = doc as Doctor;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                    MessagingCenter.Subscribe<DoctorsViewModel>(this, "DELETE", async (sender) => {
                        await LoadDoctors();
                    });
                });
            }
        }
        public Command NewDoctor
        {
            get
            {
                return new Command(async() => {
                    Insert view = new Insert();
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                    MessagingCenter.Subscribe<DoctorsViewModel>(this, "INSERT", async(sender) => {
                        //Al recibir "INSERT", hacemos cosas
                        await LoadDoctors();
                    });
                });
            }
        }
        public Command ModifyDoctor
        {
            get
            {
                return new Command(async (doc) => {
                    Update view = new Update();
                    DoctorModel viewmodel = new DoctorModel();
                    viewmodel.Doctor = doc as Doctor;
                    view.BindingContext = viewmodel;
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                    MessagingCenter.Subscribe<DoctorsViewModel>(this, "UPDATE", async (sender) => {
                        //Al recibir "INSERT", hacemos cosas
                        await LoadDoctors();
                    });
                });
            }
        }
        public DoctorsViewModel()
        {
            repo = new RepositoryDoctor();
            Task.Run(async () => {
                await LoadDoctors();
            });
        }
        public async Task LoadDoctors()
        {            
            List<Doctor> list = await repo.GetDoctor();
            Doctors = new ObservableCollection<Doctor>(list);            
        }
    }
}
