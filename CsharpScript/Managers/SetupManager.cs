using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpScript.UI;
using System.Windows.Forms;
using System.Threading;

namespace CsharpScript.Managers
{
    public class SetupManager
    {
        Setup SetupDialog { get; set; }

        public void Show()
        {
            if (SetupDialog == null)
            {
                SetupDialog = new Setup();
                SetupDialog.btnSayHello.Click += (object sender, EventArgs e) => { SayHello(); };
            }
            new Thread(() => SetupDialog.ShowDialog()).Start();
        }


        public string Name { get { return SetupDialog.txtName.Text; } set { SetupDialog.txtName.Text = value; } }

        public void Hide() { SetupDialog.Hide(); }
        public void SayHello() { MessageBox.Show("Hello " + Name); }

    }
}
