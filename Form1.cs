using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Http;


namespace OneFile_AMRCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "OneFileUploader Beta1";
        }

        public List<string> OneFile_MeterID = new List<string>();
        public List<string> OneFile_IPAddr = new List<string>();
        const string LogFile = @"\\netserver3\DATA\Log_AMR_Updates_SImAutomation\OneFileLog(Forever).txt";
        const string MeterCodeAE = "AE";
        string[] DataBasenames = new[] { "AlsoEnergy2021Vision", "AlsoEnergy2019Vision" , "AlsoEnergyReturnsVision"};
        
        long _tick;



        private void timer_FileUpload_Tick(object sender, EventArgs e)
        {
            Program_SQL sql = new Program_SQL();

            _tick++;

            if (!string.IsNullOrEmpty(textBox_Server19.Text) && checkBox_StartProcessDB.Checked && !string.IsNullOrEmpty(textBox_initials.Text))
            {
                OneFile_IPAddr.Clear(); OneFile_IPAddr.Clear(); string DataBasenameForTheProcess = string.Empty;
                richTextBox2.AppendText(_tick%2==0? Environment.NewLine + "................../": Environment.NewLine + "..................\\");
                if (_tick % 1000 == 0)
                {
                    OneFile_IPAddr.Clear(); OneFile_IPAddr.Clear();
                    if(FileParseFromServer19())
                    {
                        richTextBox2.AppendText(OneFile_MeterID.Count < 1 ? Environment.NewLine + "..." : Environment.NewLine + "OneFile is Parsed....");
                        File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "File found and parsed, Count "+ OneFile_MeterID.Count+Environment.NewLine);


                        try
                        {
                            foreach (string DataBase in DataBasenames)
                            {
                                string result = sql.GrabADatabaseWithMeterID(DataBase, OneFile_MeterID[0], "MeterID");
                                if(!string.Equals(result, "NODATA"))
                                {
                                    DataBasenameForTheProcess = DataBase;break;
                                }
                            }

                            for (int count = 0; count < OneFile_MeterID.Count; count++)
                            {
                                string result = sql.GrabADatabaseWithMeterID(DataBasenameForTheProcess, OneFile_MeterID[count], "AMRchkBy");
                                int StrLength = result.Length;
                                if (StrLength<1)
                                {
                                    sql.PostDataToAMRCheck(OneFile_MeterID[count], DateTime.Now, textBox_initials.Text, OneFile_IPAddr[count], DataBasenameForTheProcess);
                                    richTextBox2.AppendText(Environment.NewLine + "DB updating...");
                                    File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "File updated, " + OneFile_MeterID[count] + "--" + DataBasenameForTheProcess + "--" + OneFile_IPAddr[count] + Environment.NewLine);
                                }
                                else
                                {
                                    File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "File NOT updated, " + OneFile_MeterID[count] + "--" + DataBasenameForTheProcess + "--" + OneFile_IPAddr[count] + Environment.NewLine);
                                }
                            }

                            File.Delete(textBox_Server19.Text + @"\OneFile.txt");
                            richTextBox2.AppendText(Environment.NewLine + "OneFile Deleted...");
                            File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "File deleted" + Environment.NewLine);
                        }
                        catch
                        {
                            richTextBox2.AppendText(Environment.NewLine + "data not found");
                            File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "File does not have data.(catch occured)" + Environment.NewLine);
                        }

                    }
                    else if(!checkBox1.Checked)
                    {
                        File.AppendAllText(LogFile, "[" + DateTime.Now + "]----" + "Checked in Directory, No OneFile." + Environment.NewLine);
                    }
                }
            }
        }
        public bool FileParseFromServer19()
        {
            OneFile_IPAddr.Clear(); OneFile_IPAddr.Clear();
            try
            {
                string[] DataFromOneFile = File.ReadAllLines(textBox_Server19.Text + @"\OneFile.txt");
                foreach (string n in DataFromOneFile)
                {
                    string[] Delimited = n.Split(',');

                    OneFile_MeterID.Add(MeterCodeAE + Delimited[0]);
                    OneFile_IPAddr.Add(Delimited[1]);
                }
                return true;
            }
            catch
            {
                richTextBox2.AppendText(Environment.NewLine + "File not found");return false;
            }
        }
    }
}
