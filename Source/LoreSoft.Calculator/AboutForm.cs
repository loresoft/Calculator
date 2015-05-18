using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace LoreSoft.Calculator
{
    partial class AboutForm : Form
    {
        
        public AboutForm()
        {
            InitializeComponent();

            this.Text = "About " + ThisAssembly.AssemblyTitle;
            titleLabel.Text = ThisAssembly.AssemblyTitle;
            versionLabel.Text = "Version " + ThisAssembly.AssemblyFileVersion;
            descriptionLabel.Text = ThisAssembly.AssemblyDescription;
            copyrightLabel.Text = ThisAssembly.AssemblyCopyright;

            assembliesListView.Items.Clear();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    string name = assembly.FullName;
                    bool isIncluded = !String.IsNullOrEmpty(assembly.Location);
                    if (isIncluded)
                        isIncluded = !(name.StartsWith("System", StringComparison.OrdinalIgnoreCase)
                            || name.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase)
                            || name.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase));

                    if (isIncluded)
                    {
                        ListViewItem item = new ListViewItem();

                        AssemblyName assemblyName = assembly.GetName();
                        item.Text = assemblyName.Name;

                        item.SubItems.Add(assemblyName.Version.ToString());
                        
                        DateTime date = File.GetLastAccessTime(assembly.Location);
                        item.SubItems.Add(date.ToShortDateString());
                        
                        assembliesListView.Items.Add(item);
                    }
                }
                catch (NotSupportedException) { }
            }
        }

        private void loresoftLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.loresoft.com");
        }
    }
}
