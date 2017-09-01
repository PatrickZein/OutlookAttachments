using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;

namespace OutlookAttachmentsCS
{
    public partial class Form1 : Form
    {
        private readonly Microsoft.Office.Interop.Outlook.Application _application = new Microsoft.Office.Interop.Outlook.Application();

        public Form1()
        {
            InitializeComponent();

            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);

            maildrop.DragDrop += Label1_DragDrop;
            maildrop.DragOver += Label1_DragOver;
        }

        private void Label1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                //handle a message dragged from Outllok 
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //otherwise, do not handle
                e.Effect = DragDropEffects.None;
            }
        }

        private void Label1_DragDrop(object sender, DragEventArgs e)
        {
            lstResults.Items.Clear();

            try
            {
                if (e.Data.GetDataPresent("FileGroupDescriptor"))
                {
                    //supports a drop of a Outlook message
                    foreach (MailItem mailItem in _application.ActiveExplorer().Selection)
                    {
                        //hardcode a destination path for testing
                        string strFile = Path.Combine(@"c:\temp", FixFileName(mailItem.CreationTime + "_" + mailItem.SenderEmailAddress + "_" + mailItem.SenderName + "_" + mailItem.Subject + ".msg"));
                        lstResults.Items.Add(strFile);
                        mailItem.SaveAs(strFile);
                        GetAttachmentsInfo(mailItem);
                    }
                }
            }
            catch (System.Exception ex)
            {
                lstResults.Items.Add("An error occured in the drop event");
                lstResults.Items.Add(ex.ToString());
            }
        }

        private void GetAttachmentsInfo(MailItem pMailItem)
        {
            if (pMailItem.Attachments != null)
            {
                for (int i = 0; i < pMailItem.Attachments.Count; i++)
                {
                    Attachment currentAttachment = pMailItem.Attachments[i+1];
                    if (currentAttachment != null)
                    {
                        lstResults.Items.Add("attachment #" + i.ToString());
                        lstResults.Items.Add("File Name: " + currentAttachment.FileName);
                        string strFile = Path.Combine(@"c:\temp", FixFileName(currentAttachment.FileName));
                        currentAttachment.SaveAsFile(strFile);
                        Marshal.ReleaseComObject(currentAttachment);
                    }
                }
            }
        }

        private string FixFileName(string pFileName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            if (pFileName.IndexOfAny(invalidChars) >= 0)
            {
                pFileName = invalidChars.Aggregate(pFileName, (current, invalidChar) => current.Replace(invalidChar, Convert.ToChar("_")));
            }
            return pFileName;
        }


        private void kalender_click(object sender, EventArgs e)
        {
            AddAppointment(appointheader.Text,
                           bodytext.Text,
                           dateTimePicker1.Value,
                           dateTimePicker2.Value);
        }

        private void AddAppointment(string subject, string body, DateTime startdatum, DateTime sluttatum)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.AppointmentItem newAppointment =
                (Microsoft.Office.Interop.Outlook.AppointmentItem)
                _application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
                newAppointment.Start = startdatum;
                newAppointment.End = sluttatum;
                newAppointment.AllDayEvent = false;
                newAppointment.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olTentative;
                newAppointment.Location = "Platsangivelse...";

                // Bifoga ett dokument om så önskas
                OpenFileDialog attachment = new OpenFileDialog();
                attachment.Title = appointheader.Text;
                attachment.ShowDialog();
                if (attachment.FileName.Length > 0)
                    newAppointment.Attachments.Add(attachment.FileName,
                                         Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue,
                                         1,
                                         attachment.FileName);

                Microsoft.Office.Interop.Outlook.Recipients sentTo = newAppointment.Recipients;
                Microsoft.Office.Interop.Outlook.Recipient sentInvite = null;
                sentInvite = sentTo.Add("Holly Holt");
                sentInvite.Type = (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType
                    .olRequired;
                sentInvite = sentTo.Add("David Junca ");
                sentInvite.Type = (int)Microsoft.Office.Interop.Outlook.OlMeetingRecipientType
                    .olOptional;
                sentTo.ResolveAll();
                
                newAppointment.Subject = subject;
                newAppointment.Body = body;
                newAppointment.Save();
                // newAppointment.Display(true);
                newAppointment.Close(OlInspectorClose.olSave); // Detta gör att man inte behöver stänga dialogen manuellt
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        private void sendmail_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook._MailItem mail =
                _application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem) 
                as Microsoft.Office.Interop.Outlook._MailItem;

            mail.Subject = "An attachment for you!";
            mail.Body = bodytext.Text;
            mail.To = "Patrick Hassel-Zein";
        
            OpenFileDialog attachment = new OpenFileDialog();
            attachment.Title = appointheader.Text;
            attachment.ShowDialog();
            if (attachment.FileName.Length > 0)
            {
                try
                {
                    mail.Attachments.Add(attachment.FileName,
                                     Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue,
                                     1,
                                     attachment.FileName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("The following error occurred: " + ex.Message);
                }
            }
            try
            {
                ((Microsoft.Office.Interop.Outlook._MailItem)mail).Send();
                // mail.Close(OlInspectorClose.olSave); // Detta gör att man inte behöver stänga dialogen manuellt
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void header_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
