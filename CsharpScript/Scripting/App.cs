using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsharpScript.Managers;

namespace CsharpScript.Scripting
{
    public static class App
    {
        public static void Msg(string msg)
        {
            MessageBox.Show(msg);
        }

        static SetupManager _setup;
        public static SetupManager Setup
        {
            get { return (_setup = _setup ?? new SetupManager()); }
        }
    }
}
