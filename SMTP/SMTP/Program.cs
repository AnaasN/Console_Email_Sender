using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;


namespace SMTP
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserEmailAddress;
            int LineOfInput;
            string UserPassword;
            char Option;

            while (true)
            {
                
                Console.WriteLine("Send E-mails.");
                Console.WriteLine("Enter Recipient's E-mail address:");
                MailAddress to = new MailAddress(Console.ReadLine()); //user inputs the revicers email address

                Console.WriteLine("Enter Your E-mail Address:");
                UserEmailAddress = Console.ReadLine();

                MailAddress from = new MailAddress(UserEmailAddress);//senders email address

                Console.WriteLine("Enter password:");
                UserPassword = Console.ReadLine();

                //hides password
                LineOfInput = 1 + (UserPassword.Length / Console.BufferWidth);
                Console.CursorTop -= LineOfInput;
                Console.CursorLeft = 0;
                Console.WriteLine(new string(' ', UserPassword.Length));// replaces the password with space.
                Console.CursorTop -= LineOfInput;
                Console.CursorLeft = 0;
                //hides password

                MailMessage mail = new MailMessage(from, to);

                Console.WriteLine("Subject");
                mail.Subject = Console.ReadLine();

                Console.WriteLine("Your message here");
                mail.Body = Console.ReadLine();

                SmtpClient SMTP = new SmtpClient();
                SMTP.Host = "smtp.gmail.com"; //can be changed to more sutable one
                SMTP.Port = 587;//can be changed to more sutable one
                SMTP.Credentials = new NetworkCredential(UserEmailAddress, UserPassword);

                SMTP.EnableSsl = true;

                Console.WriteLine("Choose option: 'a'(normal), 'b'(spam)");
                Option = Console.ReadLine()[0];

                if (Option == 'a')
                {
                    Console.WriteLine("Sending E-mail");
                    SMTP.Send(mail);
                    UserPassword = null;//clear password.
                }
                else if(Option == 'b')
                {
                    Console.WriteLine("Sending E-mails");
                    Console.WriteLine("The recipients going to have a bad time.");
                    while (1 < 2)
                    {
                        SMTP.Send(mail);//sends the email.
                    }
                }
             
            }//end of loop
        }
    }
}
