// 
// Copyright � 2010-2019, Sinclair Community College
// Licensed under the GNU General Public License, version 3.
// See the LICENSE file in the project root for full license information.  
//
// This file is part of Make Me Admin.
//
// Make Me Admin is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, version 3.
//
// Make Me Admin is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Make Me Admin. If not, see <http://www.gnu.org/licenses/>.
//

namespace SinclairCC.MakeMeAdmin
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Deployment.WindowsInstaller;
    using Microsoft.Win32;

    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RemoveUserList(Session session)
        {
            // TODO: i18n
            session.Log(string.Format("Removing saved user list \"{0}\".", EncryptedSettings.SettingsFilePath));

            int tries = 5;
            TimeSpan sleepTime = new TimeSpan(0, 0, 5);
            while ((tries > 0) && (System.IO.File.Exists(EncryptedSettings.SettingsFilePath)))
            {
                try
                {
                    EncryptedSettings.RemoveAllSettings();
                }
                catch (Exception e)
                {
                    // TODO: i18n
                    session.Log("Error while trying to remove saved user list.");
                    session.Log(e.Message);
                }

                tries--;
                if (tries > 0)
                {
                    // TODO: i18n
                    session.Log(string.Format("{0:N0} tries remaining.", tries));
                    System.Threading.Thread.Sleep(sleepTime);
                }
            }

            // TODO: i18n
            session.Log("Finished removing saved user list.");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult ConfigureEventLog(Session session)
        {
            try
            {
                string installFolder = session["INSTALLFOLDER"];
                session.Log($"Configuring event log with install folder: {installFolder}");

                string eventMessageFile = System.IO.Path.Combine(installFolder, "EventMessages.dll");
                session.Log($"Event message file path: {eventMessageFile}");

                // Configure the MakeMeAdmin event log
                using (RegistryKey eventLogKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\EventLog\MakeMeAdmin", true))
                {
                    if (eventLogKey != null)
                    {
                        eventLogKey.SetValue("EventMessageFile", eventMessageFile, RegistryValueKind.ExpandString);
                        eventLogKey.SetValue("CategoryMessageFile", eventMessageFile, RegistryValueKind.ExpandString);
                        eventLogKey.SetValue("TypesSupported", 7, RegistryValueKind.DWord);
                        session.Log("Configured MakeMeAdmin event log registry key");
                    }
                    else
                    {
                        session.Log("WARNING: MakeMeAdmin event log key not found");
                    }
                }

                // Configure the Make Me Admin event source
                using (RegistryKey sourceKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\EventLog\MakeMeAdmin\Make Me Admin", true))
                {
                    if (sourceKey != null)
                    {
                        sourceKey.SetValue("EventMessageFile", eventMessageFile, RegistryValueKind.ExpandString);
                        sourceKey.SetValue("CategoryMessageFile", eventMessageFile, RegistryValueKind.ExpandString);
                        sourceKey.SetValue("TypesSupported", 7, RegistryValueKind.DWord);
                        session.Log("Configured Make Me Admin event source registry key");
                    }
                    else
                    {
                        session.Log("WARNING: Make Me Admin event source key not found");
                    }
                }

                session.Log("Event log configuration completed successfully");
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.Log($"ERROR configuring event log: {ex.Message}");
                session.Log($"Stack trace: {ex.StackTrace}");
                // Don't fail the installation if event log configuration fails
                return ActionResult.Success;
            }
        }
    }
}
