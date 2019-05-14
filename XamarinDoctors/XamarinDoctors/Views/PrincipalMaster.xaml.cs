using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDoctors.Models;

namespace XamarinDoctors.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalMaster : MasterDetailPage
	{
        public List<MenuItemPage> PageMenu { get; set; }
		public PrincipalMaster ()
		{
			InitializeComponent ();
            PageMenu = new List<MenuItemPage>();
            var page1 = new MenuItemPage()
            {
                Title = "Doctor´s list",
                PageType = typeof(Doctors)
            };
            var page2 = new MenuItemPage()
            {
                Title = "New doctor",
                PageType = typeof(Insert)
            };
            PageMenu.Add(page1);
            PageMenu.Add(page2);
            lstMenu.ItemsSource = PageMenu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Doctors)));
            IsPresented = false;
            lstMenu.ItemSelected += ChangePage;
		}

        private void ChangePage(object sender, SelectedItemChangedEventArgs e)
        {
            MenuItemPage selected = (MenuItemPage)e.SelectedItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selected.PageType));
        }
    }
}