using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    public class ContactController : Controller
    {
        // Метод для отображения страницы контактов
        public IActionResult Index()
        {
            return View("Contact");
        }

        // Метод для обработки POST-запроса с формы
        [HttpPost]
        public async Task<IActionResult> SendMessage(string name, string email, string number, string msg)
        {
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress("harrisonnn2023@gmail.com"));  // Ваша почта
                message.From = new MailAddress(email);  // Почта отправителя
                message.Subject = "Новое сообщение с контактной формы";
                message.Body = $"Name: {name}\nEmail: {email}\nNumber: {number}\nMessage: {msg}";
                message.IsBodyHtml = false;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "harrisonnn2023@gmail.com",  // Ваша почта
                        Password = "cbye kufu vqaa nvpz"  // Ваш пароль
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }

                ViewBag.Message = "Сообщение отправлено!";
                return RedirectToAction("Index", "Home");
            }

            return View("Contact");
        }
    }
}
