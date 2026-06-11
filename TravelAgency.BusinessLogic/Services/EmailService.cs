using System.Net;
using System.Net.Mail;

public class EmailService
{
    public void Send(string to, string subject, string body)
    {
        var smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("yourmail@gmail.com", "app_password"),
            EnableSsl = true,
        };

        smtp.Send("yourmail@gmail.com", to, subject, body);
    }
}