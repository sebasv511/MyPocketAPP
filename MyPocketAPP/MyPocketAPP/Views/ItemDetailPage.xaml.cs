using MyPocketAPP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyPocketAPP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}