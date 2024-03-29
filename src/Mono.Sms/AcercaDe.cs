using System;
using System.Diagnostics;
using System.Windows.Forms;
using Mono.Sms.Core;

namespace Mono.Sms
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {
            linkWeb.Links.Add(0, linkWeb.Text.Length, "http://code.google.com/p/monosms/");

            rtxtReleaseNotes.LoadFile(MonoSmsResources.GetResourceStream("creditos.rtf"), RichTextBoxStreamType.RichText);
        }


        private void LinkArgs(LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void linkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkArgs(e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}