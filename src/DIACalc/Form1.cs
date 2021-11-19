using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIACalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialogData.Filter = "txt(*.txt)|*.txt";
            openFileDialogFasta.Filter = "fasta(*.fasta)|*.fasta";
            saveFileDialog1.Filter = "txt(*.txt)|*.txt";
            target.Text = "IA_acid";
            calc.Enabled = false;
            Program.SetProgressbar += SetProEvent;
        }

        public static string datapath = "";
        public static string fastapath = "";
        public static string savepath = "rep.txt";

        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialogData.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                datapath = openFileDialogData.FileName;
                savepath = openFileDialogData.FileName.Split('.')[0] + "_rep.txt";
                saveFileDialog1.FileName = savepath;
                if (datapath != "" && fastapath != "")
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
        }

        private void openfasta_Click(object sender, EventArgs e)
        {
            if (openFileDialogFasta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fastapath = openFileDialogFasta.FileName;
                Program.ClearProtein();
                if (datapath != "" && fastapath != "")
                {
                    calc.Enabled = true;
                }
                else
                {
                    calc.Enabled = false;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                savepath = saveFileDialog1.FileName;
                //MessageBox.Show(savepath);
            }
        }

        private void calc_Click(object sender, EventArgs e)
        {
            if (target.Text == "")
            {
                MessageBox.Show("No valid target information");
                return;
            }
            Thread thread = new Thread(new ThreadStart(Calc));
            thread.IsBackground = true;
            thread.Start();
            EnableButton(false);
            
        }

        private void cutoff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private delegate void SetProgress(int i);

        private delegate void Enable(bool b);

        private void EnableButton(bool b)
        {
            this.calc.Enabled = b;
            this.save.Enabled = b;
            this.open.Enabled = b;
            this.openfasta.Enabled = b;
            this.target.Enabled = b;
        }

        void SetProEvent(object sender, int i)
        {
            Setpro(i);
        }

        public void Setpro(int i)
        {
            if (this.InvokeRequired)
            {
                SetProgress setprogress = new SetProgress(Setpro);
                this.Invoke(setprogress, new object[] { i });
            }
            else
            {
                this.progressBar1.Value = i;
            }
        }

        private void Calc()
        {
            Setpro(0);
            Program.ReadFasta(fastapath);
            Setpro(5);
            //Thread thread = new Thread(new ThreadStart(Time));
            //thread.IsBackground = true;
            //thread.Start();
            int singlecnt = 0;

            string r = Program.Result(target.Text, datapath, false,int.MaxValue, out singlecnt,-1, true, 1);
            //thread.Abort();
            Setpro(90);
            StreamWriter sw = new StreamWriter(savepath);
            sw.Write(r);
            sw.Close();
            Setpro(100);
            //singlecount.Text = "singlecount: " + singlecnt.ToString();
            MessageBox.Show("Finished");
            Enable enable = new Enable(EnableButton);
            this.Invoke(enable, new object[] { true });
        }

        private void Time()
        {
            int k = 1000;
            for (int i = 0; i < k; i++)
            {
                Thread.Sleep(500);
                Setpro(i * 85 / k + 5);
            }
        }

    }
}
