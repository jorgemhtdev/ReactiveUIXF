[assembly: Xamarin.Forms.Dependency(typeof(ReactiveUIXF.Services.AlertDialogService))]
namespace ReactiveUIXF.Services
{
	using System.Threading.Tasks;
	using Xamarin.Forms;

	public class AlertDialogService : IAlertDialogService
	{
		public async Task ShowDialogAsync(string title, string message, string close)
			=> await Application.Current.MainPage.DisplayAlert(title, message, close);

		public async Task<bool> ShowDialogConfirmationAsync(string title, string message, string cancel, string ok)
			=> await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);

		public async Task<string> DisplayActionSheet(string title, string cancel, string[] buttons)
			=> await Application.Current.MainPage.DisplayActionSheet(title, cancel, null, buttons);
	}
}
