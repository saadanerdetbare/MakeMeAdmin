// 
// Copyright © 2010-2019, Sinclair Community College
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
    /// <summary>
    /// This class allows simple logging of application events to the MakeMeAdmin Windows Event Log.
    /// </summary>
    public class ApplicationLog
    {
        /// <summary>
        /// The source name to use when writing events to the Event Log.
        /// </summary>
        private const string SourceName = "Make Me Admin";

        /// <summary>
        /// An EventLog object for interacting with this service's event log.
        /// </summary>
        private static System.Diagnostics.EventLog log;

        /// <summary>
        /// Constructor
        /// </summary>
        static ApplicationLog()
        {
            // Get an EventLog object for this service's log.
            log = new System.Diagnostics.EventLog(Properties.Resources.ApplicationLogName)
            {
                // Specify the source name for this event log.
                Source = SourceName
            };
        }

        /// <summary>
        /// Adds an event source to the event log on the local computer.
        /// </summary>
        public static void CreateSource()
        {
            // If the specified source name does not exist, create it.
            if (!System.Diagnostics.EventLog.SourceExists(SourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(SourceName, Properties.Resources.ApplicationLogName);
            }
        }

        /// <summary>
        /// Removes, from the local computer, the event source for this service.
        /// </summary>
        public static void RemoveSource()
        {
            // If the specified source name exists, remove it.
            if (System.Diagnostics.EventLog.SourceExists(SourceName))
            {
                System.Diagnostics.EventLog.DeleteEventSource(SourceName);
            }
        }


        /// <summary>
        /// Writes an event to the MakeMeAdmin Windows Event Log.
        /// </summary>
        /// <param name="message">
        /// The message to write to the log.
        /// </param>
        /// <param name="id">
        /// An ID for the type of event being logged.
        /// </param>
        /// <param name="entryType">
        /// The severity of the message being logged (information, warning, etc.).
        /// </param>
        public static void WriteEvent(string message, EventID id, System.Diagnostics.EventLogEntryType entryType)
        {
            try
            {
                log.WriteEntry(message, entryType, (int)id);
            }
            catch (System.Security.SecurityException)
            {
                // If we don't have permission to write to the event log, fail silently
                // This can happen if the event log source is not properly registered
            }
            catch (System.InvalidOperationException)
            {
                // If the event log doesn't exist or source is invalid, fail silently
            }
        }
    }
}
