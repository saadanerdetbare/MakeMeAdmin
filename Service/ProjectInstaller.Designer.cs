﻿namespace SinclairCC.MakeMeAdmin
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }

                    if (this.serviceInstaller != null)
                    {
                        this.serviceInstaller.Dispose();
                    }

                    if (this.serviceProcessInstaller != null)
                    {
                        this.serviceProcessInstaller.Dispose();
                    }

                    if (this.eventLogInstaller != null)
                    {
                        this.eventLogInstaller.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.eventLogInstaller = new System.Diagnostics.EventLogInstaller();
            //
            // serviceProcessInstaller
            //
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            //
            // serviceInstaller
            //
            this.serviceInstaller.Description = "Enables users to elevate themselves to administrator-level rights.";
            this.serviceInstaller.DisplayName = "Make Me Admin";
            this.serviceInstaller.ServiceName = "MakeMeAdmin";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            //
            // eventLogInstaller
            //
            this.eventLogInstaller.Log = "MakeMeAdmin";
            this.eventLogInstaller.Source = "Make Me Admin";
            //
            // ProjectInstaller
            //
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller,
            this.eventLogInstaller});

        }

        #endregion

        /// <summary>
        /// Installs an executable containing classes that extend ServiceBase. This
        /// class is called by installation utilities, such as InstallUtil.exe, when
        /// installing a service application.
        /// </summary>
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;

        /// <summary>
        /// Installs a class that extends ServiceBase to implement a service. This
        /// class is called by the install utility when installing a service application.
        /// </summary>
        private System.ServiceProcess.ServiceInstaller serviceInstaller;

        /// <summary>
        /// Installs the event log for the service.
        /// </summary>
        private System.Diagnostics.EventLogInstaller eventLogInstaller;
    }
}