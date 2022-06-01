using System.Threading.Tasks;
using Xamarin.Forms;

namespace MailXamarin.Utils
{
    public static class AlertFacade
    {
        public static async Task ShowErrorAlert(this Page page, string message)
        {
            await page.DisplayAlert("Ошибка", message, "ОK");
        }

        public static async Task ShowInfoAlert(this Page page, string message)
        {
            await page.DisplayAlert("Уведомление", message, "ОK");
        }

        public static async Task<bool> ShowQuestionAlert(this Page page, string message)
        {
            bool response = await page.DisplayAlert("Вопрос", message, "Да", "Нет");
            return response;
        }
    }
}