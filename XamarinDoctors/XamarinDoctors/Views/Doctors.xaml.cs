using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDoctors.Models;
using XamarinDoctors.Repositories;
using XamarinDoctors.ViewModels;

namespace XamarinDoctors.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Doctors : ContentPage
	{        
		public Doctors ()
		{
			InitializeComponent ();                    
		}               
	}
}