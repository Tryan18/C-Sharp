using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultipleTechniques
{
    public partial class Form1 : Form
    {
        private int getal = 0;
        private int getal2 = 0;
        private Mutex m = new Mutex();
        private Test t;

        public Form1()
        {
            InitializeComponent();
            t = new Test();
            t.UpdateHandler += T_UpdateHandler;
        }

        private void T_UpdateHandler(int getal)
        {
            getal2 = getal;
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(delegate 
            {
                while (true)
                {
                    if (m.WaitOne())
                    {
                        getal++;
                        AppendTextBox("Output: " + getal.ToString());
                        Thread.Sleep(1000);
                        m.ReleaseMutex();
                    }
                }
            }));
            t.Start();
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            label_output.Text = value;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && textBox1.Text == "test")
            {
                string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Assembly a = Assembly.LoadFile(filePath + "\\ReflectionExample.dll");
                Type t = a.GetType("ReflectionExample.ReflectionTest");
                object obj = Activator.CreateInstance(t);
                int getal = (int)t.InvokeMember("Dummy", BindingFlags.InvokeMethod, null, obj, null);
                textBox1.Text = getal.ToString();
            }
        }

        private void button_input2_Click(object sender, EventArgs e)
        {
            t.Modify();
            label_output2.Text = "Output: " + getal2;
        }
    }
}
