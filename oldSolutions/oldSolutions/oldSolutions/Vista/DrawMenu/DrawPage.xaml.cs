using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace oldSolutions.Vista.DrawMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrawPage : MasterDetailPage
	{
        public List<MasterPageItem> menuList { get; set; }
        public DrawPage()
        {
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            var page1 = new MasterPageItem() { Title = "Gestion de reparaciones", TargetType = typeof(MainMenu) };
            var page2 = new MasterPageItem() { Title = "Settings", TargetType = typeof(Page2) };
            menuList.Add(page1);
            menuList.Add(page2);
            MenuDesplegable.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Page2)));
        }

        private void MenuDesplegable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}