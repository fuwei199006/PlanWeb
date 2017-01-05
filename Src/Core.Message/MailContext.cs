using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Core.Config;
using Core.Encrypt;

namespace Core.Message
{

    /// <summary>
    /// EmailSend 的摘要说明。
    /// </summary>
    public class MailContext
    {

        /// <summary>
        /// SMTP服务器名或IP地址 smtp.gmail.com
        /// </summary>
        private static readonly string EmailHost = DESEncrypt.Decode(LocalCachedConfigContext.Current.Mail163Config.EmailHost);
        /// <summary>
        /// 邮件地址 yuanrui@macrowing.com
        /// </summary>
        private static readonly string EmailAddress = DESEncrypt.Decode(LocalCachedConfigContext.Current.Mail163Config.EmailAddress);
        /// <summary>
        /// 邮件密码
        /// </summary>
        private static readonly string EmailPassword = DESEncrypt.Decode(LocalCachedConfigContext.Current.Mail163Config.EmailPassword);

        private static readonly int Port = Int32.Parse(DESEncrypt.Decode(LocalCachedConfigContext.Current.Mail163Config.EmailPort));


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail">发送 多个 , 隔开</param>
        /// <param name="ccEmail">抄送 多个 , 隔开</param>
        /// <param name="title">标题</param>
        /// <param name="context">正文</param>
        /// <param name="fileName">附件文件路径</param>
        /// <returns></returns>
        public static bool SendEmail(string toEmail, string ccEmail, string title, string context, string fileName)
        {
            try
            {
                MailMessage myMail = new MailMessage();
                SmtpClient smtpSender = new SmtpClient
                {
                    UseDefaultCredentials = true,
                    Host = EmailHost,
                    Credentials = new System.Net.NetworkCredential(EmailAddress, EmailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //SMTP服务器名或IP地址


                myMail.Subject = title.Trim();
                myMail.From = new MailAddress(EmailAddress);
                if (File.Exists(fileName))
                {
                    myMail.Attachments.Add(new Attachment(fileName));//添加附件
                }
               
                string[] users = toEmail.Split(',');
                string[] ccUsers = ccEmail.Split(',');
                for (int i = 0; i < users.Length; i++)
                {
                    if (!string.IsNullOrEmpty(users[i]))
                        myMail.To.Add(new MailAddress(users[i]));
                }
                // 如果发送为空，则抄送变发送
                if (myMail.To.Count > 0)
                {
                    for (int i = 0; i < ccUsers.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ccUsers[i]))
                            myMail.CC.Add(new MailAddress(ccUsers[i]));
                    }
                }
                else
                {
                    for (int i = 0; i < ccUsers.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ccUsers[i]))
                            myMail.To.Add(new MailAddress(ccUsers[i]));
                    }
                }
                myMail.Body = context;
                myMail.BodyEncoding = System.Text.Encoding.Default;
                myMail.SubjectEncoding = System.Text.Encoding.Default;
                myMail.IsBodyHtml = true;
                smtpSender.Port = Port;
                smtpSender.EnableSsl = true;
                smtpSender.Send(myMail);
              
                return true;
            }
            catch (Exception e)
            {
               
                throw new Exception("发送邮件失败 " + e.Message);
                 
            }
            finally
            {

            }
        }

        public static bool SendEmail(string toEmail, string ccEmail, string title, string context)
        {
            try
            {
                MailMessage myMail = new MailMessage();
                SmtpClient smtpSender = new SmtpClient
                {
                    UseDefaultCredentials = true,
                    Host = EmailHost,
                    Credentials = new System.Net.NetworkCredential(EmailAddress, EmailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //SMTP服务器名或IP地址


                myMail.Subject = title.Trim();
                myMail.From = new MailAddress(EmailAddress);
                string[] users = toEmail.Split(',');
                string[] ccUsers = ccEmail.Split(',');
                for (int i = 0; i < users.Length; i++)
                {
                    if (!string.IsNullOrEmpty(users[i]))
                        myMail.To.Add(new MailAddress(users[i]));
                }
                // 如果发送为空，则抄送变发送
                if (myMail.To.Count > 0)
                {
                    for (int i = 0; i < ccUsers.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ccUsers[i]))
                            myMail.CC.Add(new MailAddress(ccUsers[i]));
                    }
                }
                else
                {
                    for (int i = 0; i < ccUsers.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(ccUsers[i]))
                            myMail.To.Add(new MailAddress(ccUsers[i]));
                    }
                }
                myMail.Body = context;
                myMail.BodyEncoding = System.Text.Encoding.Default;
                myMail.SubjectEncoding = System.Text.Encoding.Default;
                myMail.IsBodyHtml = true;
                smtpSender.Port = Port;
                smtpSender.EnableSsl = true;
                smtpSender.Send(myMail);

                return true;
            }
            catch (Exception e)
            {

                throw new Exception("发送邮件失败 " + e.Message);

            }
            finally
            {

            }
        }
        public static bool SendEmail(string toEmail,string title, string context)
        {
            try
            {
                MailMessage myMail = new MailMessage();
                SmtpClient smtpSender = new SmtpClient
                {
                    UseDefaultCredentials = true,
                    Host = EmailHost,
                    Credentials = new System.Net.NetworkCredential(EmailAddress, EmailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                //SMTP服务器名或IP地址


                myMail.Subject = title.Trim();
                myMail.From = new MailAddress(EmailAddress);
                string[] users = toEmail.Split(',');
            
                foreach (string t in users)
                {
                    if (!string.IsNullOrEmpty(t))
                        myMail.To.Add(new MailAddress(t));
                }

                myMail.Body = context;
                myMail.BodyEncoding = System.Text.Encoding.Default;
                myMail.SubjectEncoding = System.Text.Encoding.Default;
                myMail.IsBodyHtml = true;
                smtpSender.Port = Port;
                smtpSender.EnableSsl = true;
                smtpSender.Send(myMail);

                return true;
            }
            catch (Exception e)
            {

                throw new Exception("发送邮件失败 " + e.Message);

            }
            finally
            {

            }
        }

    }
}

