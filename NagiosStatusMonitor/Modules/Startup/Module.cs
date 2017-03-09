using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using Gemini.Framework;
using Gemini.Modules.Inspector;
using Gemini.Modules.Output;

namespace NagiosStatusMonitor.Modules.Startup
{
    [Export (typeof (IModule))]
    public class Module : ModuleBase
    {
        private readonly IOutput _output;

        [ImportingConstructor]
        public Module (IOutput output, IInspectorTool inspectorTool)
        {
            _output = output;
        }

        public override void Initialize ()
        {
            Shell.ShowFloatingWindowsInTaskbar = true;
            Shell.ToolBars.Visible = true;

            //MainWindow.WindowState = WindowState.Maximized;
            MainWindow.Title = "Nagios Status Monitor";

            Shell.StatusBar.AddItem ("Status!", new GridLength (1, GridUnitType.Star));
            Shell.StatusBar.AddItem ("Server: ", new GridLength (100));
            Shell.StatusBar.AddItem ("HH-LS-IT-001", new GridLength (100));

            _output.AppendLine ("Started up");
        }
    }
}
