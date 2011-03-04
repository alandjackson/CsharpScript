using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Mono.CSharp;

namespace CsharpScript
{
    public partial class Immediate : Form
    {
        public Immediate()
        {
            InitializeComponent();

            Evaluator.Init(new string[0]);
            Evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
            Evaluator.Run("using CsharpScript.Scripting;");

            txtCommand.KeyDown += txtCommand_KeyDown;
            txtCommand.Focus();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ExecuteCommand(txtCommand.Text);
        }

        void ExecuteCommand(string line)
        {
            string result="";
            try
            {
                result = Evaluator.Evaluate(line).ToString();
            }
            catch (Exception e)
            {
                if (!(e is ArgumentException) &&
                    e.Message != "The expression did not set a result")
                    result = e.ToString();
            }

            List<string> lines = new List<string>(txtConsole.Lines);
            lines.Add(line);
            lines.Add(result);
            while (lines.Count > 200) lines.RemoveAt(0);
            txtConsole.Lines = lines.ToArray();
            txtConsole.SelectionStart = txtConsole.Text.Length;
            txtConsole.ScrollToCaret();
            txtCommand.Text = "";
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsole_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
