using MyPocketAPP.Data.Models;
using MyPocketAPP.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace MyPocketAPP.ViewModels
{
    public class PocketsViewModel
    {
        private readonly IPocketService _pocketService;

        public PocketsViewModel(IPocketService pocketService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());            
            //Title = "Pockets";
            _pocketService = pocketService;
        }

        public ObservableRangeCollection<PocketDetail> Pockets { get; set; } = new ObservableRangeCollection<PocketDetail>();

        public ICommand AppearingCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                //IsBusy = true;
                var pockets = await _pocketService.GetPockets();
                if (pockets != null)
                {
                    Pockets.ReplaceRange(pockets);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                //IsBusy = false;
            }
        }
    }
}
