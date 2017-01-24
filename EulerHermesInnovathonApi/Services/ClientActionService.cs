using EulerHermesInnovathon.Model.Client;
using EulerHermesInnovathon.Models.Button;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Twilio;

namespace EulerHermesInnovathonApi.Services
{
    public class ClientActionService
    {
        private static object __sync = new object();
        private static ClientActionService __Instance;

        public static ClientActionService Instance
        {
            get
            {
                if (__Instance == null)
                    lock(__sync)
                        if(__Instance == null)
                            __Instance = new ClientActionService();
                return __Instance;
            }
        }

        public void RegisterForSms(string phoneNumber)
        {
            this._actionList.Add(new ClientAction() { ActionType = ClientActionType.Sms, ActionData = phoneNumber });
            this.Serialize();
        }

        public void RegisterForEmail(string emailAddress)
        {
            this._actionList.Add(new ClientAction() { ActionType = ClientActionType.Email, ActionData = emailAddress });
            this.Serialize();
        }

        public void RegisterForCallback(string callbackUri)
        {
            this._actionList.Add(new ClientAction() { ActionType = ClientActionType.Callback, ActionData = callbackUri });
            this.Serialize();
        }

        public void PerformClientActions(PartnerQuote quote)
        {
            this.Deserialize();
            foreach (var action in this._actionList)
            {
                switch (action.ActionType)
                {
                    case ClientActionType.Sms:
                        this.sendSms(action.ActionData, quote);
                        break;
                    case ClientActionType.Email:
                        this.sendEmail(action.ActionData, quote);
                        break;
                    case ClientActionType.Callback:
                        this.callback(action.ActionData, quote);
                        break;
                }
            }
        }

        private void sendSms(string phoneNumber, PartnerQuote quote)
        {
            string AccountSid = "AC46920ac3a6c3c0bd914e0539134e6171";
            string AuthToken = "5eeed72d74b3b061831d24729054aa54";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            twilio.SendMessage(
                "+33644644705", 
                phoneNumber,
                "Don't Panic ! " + quote.PartnerName + " is on its way to save your SI !", 
                new Action<Message>(m => { }));
        }

        private void sendEmail(string emailAddress, PartnerQuote quote)
        {
            bool isImportantEmail = false;
            string fromEmail = "FeelSecure@eulerHermes.com";
            string toEmail = emailAddress;
            int smtpPort = 587;
            bool smtpEnableSsl = true;
            string smtpHost = " SSL0.ovh.net";
            string smtpUser = "iothub@keiyan.net";
            string smtpPass = "Lk8Je6QS99gR10w12Uqm";
            string subject = "Don't Panic ! " + quote.PartnerName + " is on its way to save your SI !";
            string body = string.Format(@"Hello,

Someone pressed the blue button. Our emergency partner {0} is on its way.
The hourly rate for the intervention is {1} €/hour.
Here is a copy of the contract accepted for this intervention :
{2}", quote.PartnerName, quote.HourlyPrice, quote.Contract);

            MailMessage mail = new MailMessage(fromEmail, toEmail);
            SmtpClient client = new SmtpClient();
            client.Port = smtpPort;
            client.EnableSsl = smtpEnableSsl;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = smtpHost;
            client.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPass);
            mail.Subject = subject;

            if (isImportantEmail)
            {
                mail.Priority = MailPriority.High;
            }

            mail.Body = body;
            client.Send(mail);
        }

        private void callback(string uri, PartnerQuote quote)
        {
            new System.Net.WebClient().DownloadStringAsync(new Uri(uri));
        }

        private List<ClientAction> _actionList = new List<ClientAction>();

        private const string FileName = "C:\\temp\\actions.json";

        private void Serialize()
        {
            string serialized = JsonConvert.SerializeObject(this._actionList);

            lock(__sync)
            {
                File.WriteAllText(FileName, serialized);
            }
        }

        private void Deserialize()
        {
            if (!File.Exists(FileName)) return;
            string content = File.ReadAllText(FileName);

            lock(__sync)
            {
                this._actionList = JsonConvert.DeserializeObject<List<ClientAction>>(content);
            }
        }
    }
}
