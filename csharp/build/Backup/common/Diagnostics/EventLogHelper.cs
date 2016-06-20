/* 
 Copyright (c) 2010, Direct Project
 All rights reserved.

 Authors:
    John Theisen     jtheisen@kryptiq.com
  
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of The Direct Project (directproject.org) nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 
*/
using System;
using System.Diagnostics;

namespace Health.Direct.Common.Diagnostics
{
    ///<summary>
    /// This helper/utility class allows us to have a single entry point when writing
    /// to the EventLog.
    ///</summary>
    public static class EventLogHelper
    {
        private const string DefaultSourceName = "Health.Direct";
        private const int DefaultEventID = 1;

        ///<summary>
        /// Write to the EventLog with the type set to <see cref="EventLogEntryType.Error"/>.
        ///</summary>
        /// <remarks>If this fails it will 'eat' the exception.</remarks>
        ///<param name="source">The source name</param>
        ///<param name="message">The message to log</param>
        public static void WriteError(string source, string message)
        {
            WriteLog(source, EventLogEntryType.Error, DefaultEventID, message);
        }

        ///<summary>
        /// Write to the EventLog with the type set to <see cref="EventLogEntryType.Information"/>.
        ///</summary>
        /// <remarks>If this fails it will 'eat' the exception.</remarks>
        ///<param name="source">The source name</param>
        ///<param name="message">The message to log</param>
        public static void WriteInformation(string source, string message)
        {
            WriteLog(source, EventLogEntryType.Information, DefaultEventID, message);
        }

        ///<summary>
        /// Write to the EventLog with the type set to <see cref="EventLogEntryType.Warning"/>. 
        /// If this fails it will 'eat' the exception.
        ///</summary>
        /// <remarks>If this fails it will 'eat' the exception.</remarks>
        ///<param name="source">The source name</param>
        ///<param name="message">The message to log</param>
        public static void WriteWarning(string source, string message)
        {
            WriteLog(source, EventLogEntryType.Warning, DefaultEventID, message);
        }

        private static void WriteLog(string source, EventLogEntryType type, int eventID, string message)
        {
            try
            {
                EventLog.WriteEntry(source ?? DefaultSourceName, message, type, eventID);
            }
            catch (Exception ex)
            {
                try
                {
                    Log.For(typeof(EventLogHelper))
                        .Warn("While writing to the EventLog. Original message was - " + message, ex);
                }
                catch
                {
                    // eat this exception
                }
            }
        }
    }
}