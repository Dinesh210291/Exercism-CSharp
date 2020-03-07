using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.Linq;
using System.Net;

namespace ZipAndSendToEmail
{
    public partial class Form1 : Form
    {
        private const string _tempLogFile = "TXConnectTest.zip";
        private string _tempFolderPath = Path.GetTempPath();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendClientLog_Click(object sender, EventArgs e)
        {
            // Get all the log files from temp/TXConnect folder
            if (Directory.Exists(_tempFolderPath))
            {
                //check sub directory "TXConnect"
                string subDir = _tempFolderPath + "TXConnect";
                if (Directory.Exists(subDir))
                {
                    CompressDirectory(subDir, Path.Combine(_tempFolderPath, _tempLogFile));
                }
            }
        }

        /// <summary>
        /// Method that compress all the files inside a folder (non-recursive) into a zip file.
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <param name="OutputFilePath"></param>
        /// <param name="CompressionLevel"></param>
        private void CompressDirectory(string DirectoryPath, string OutputFilePath, int CompressionLevel = 9)
        {
            // check zip file already exists?
            if (File.Exists(OutputFilePath))
            {
                //Delete zip file
                File.Delete(OutputFilePath);
            }

            try
            {
                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.

                //First way: creating multiple directories inside the zip folder
                string[] logFiles = Directory.GetFiles(DirectoryPath);
                //using (ZipFile zipFile = ZipFile.Create(_tempLogFile))
                //{
                //    initialize the file so that it can accept updates
                //    zipFile.BeginUpdate();

                //    foreach (var logFile in logFiles)
                //    {
                //        if (Path.GetFileName(logFile).Contains("Log"))
                //        {
                //            zipFile.Add(logFile);
                //        }
                //    }
                //    //commit the update once we are done
                //    zipFile.CommitUpdate();

                //    zipFile.Delete(_tempLogFile);
                //}
                //SendLogZipFile(_tempLogFile);
                //Second way
                using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
                {

                    // Define the compression level
                    // 0 - store only to 9 - means best compression
                    OutputStream.SetLevel(CompressionLevel);

                    //need to check with more size of log files
                    byte[] buffer = new byte[4096];

                    foreach (string file in logFiles)
                    {
                        if (Path.GetFileName(file).Contains("Log"))
                        {
                            ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                            entry.DateTime = DateTime.Now;
                            OutputStream.PutNextEntry(entry);

                            using (FileStream fs = File.OpenRead(file))
                            {
                                // Using a fixed size buffer here makes no noticeable difference for output
                                // but keeps a lid on memory usage.
                                int sourceBytes;

                                do
                                {
                                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                    OutputStream.Write(buffer, 0, sourceBytes);
                                } while (sourceBytes > 0);
                            }
                        }
                    }
                    OutputStream.Finish();

                    OutputStream.Close();

                    //Add client log "Zip Files successfully compressed" with stack trace.

                    //Pick up the Zip file from local and send it to respective person's email
                    SendLogZipFile();
                }
            }
            catch (Exception ex)
            {
                // No need to rethrow the exception as for our purposes its handled.
                // Show or Add client log with proper message
            }
        }

        private void SendLogZipFile(/*string zipFile*/)
        {
            var logAttachment = Directory.GetFiles(_tempFolderPath, "*.zip*").Where(file => Path.GetFileName(file).Equals("TXConnectTest.zip")).FirstOrDefault();

            if (logAttachment != null)
            {
                //Logic to send mail with attachement
                try
                {
                    using (var client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("dsdineshsharma770@gmail.com", "xxxxxxxx"),
                        Timeout = 20000
                    })
                    {
                        using (MailMessage msg = new MailMessage())
                        {
                            Attachment attachment = new Attachment(logAttachment);
                            msg.From = new MailAddress("dsdineshsharma770@gmail.com");
                            msg.To.Add(new MailAddress("dsdineshsharma770@gmail.com"));
                            // msg.To.Add(new MailAddress("nagarajup@cybage.com"));
                            msg.To.Add(new MailAddress("dsdineshsharma770@gmail.com"));
                            msg.Subject = "TXConnect: Client logs";
                            msg.Body = "Best Regards";
                            msg.Body += Environment.NewLine;
                            msg.Body += "Dinesh Sharma";
                            msg.IsBodyHtml = true;

                            msg.Attachments.Add(attachment);
                            client.Send(msg);

                            MessageBox.Show("Email sent successfully!", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Add client log or show message box with message "Email sent successfully!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Add client log or show message box with message "failed to send email with the following error:" ex.Message
                }
            }

        }
    }
}
