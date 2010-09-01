﻿/* 
 Copyright (c) 2010, NHIN Direct Project
 All rights reserved.

 Authors:
    Umesh Madan     umeshma@microsoft.com
  
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of the The NHIN Direct Project (nhindirect.org). nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace NHINDirect
{
    /// <summary>
    /// Extensions to core/common .NET objects. 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Tests if the second string is contained by the first string with the supplied <paramref name="comparison"/> operator
        /// </summary>
        /// <param name="x">The base string.</param>
        /// <param name="y">The string to test if it is contained in the base string</param>
        /// <param name="comparison">The comparison operator.</param>
        /// <returns><c>true</c> if the second string is contained in the first with respect to the supplied form of
        /// string comparison, <c>false</c> otherwise</returns>
        public static bool Contains(this string x, string y, StringComparison comparison)
        {
            return (x.IndexOf(y, comparison) >= 0);
        }

        /// <summary>
        /// Tests if this collection is <c>null</c> or has 0 entries.
        /// </summary>
        /// <param name="certs">The collection to test.</param>
        /// <returns><c>true</c> if the collection is <c>null</c> or has 0 entries</returns>
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }

        /// <summary>
        /// Tests if this collection is <c>null</c> or has 0 entries.
        /// </summary>
        /// <param name="chainElements">The collection to test.</param>
        /// <returns><c>true</c> if the collection is <c>null</c> or has 0 entries</returns>
        public static bool IsNullOrEmpty(this System.Collections.ICollection collection)
        {
            return (collection == null || collection.Count == 0);
        }

        //---------------------------------------
        //
        // StringBuilder
        //
        //---------------------------------------
                
        public static void AppendLine(this StringBuilder builder, object value)
        {
            builder.AppendLine(value.ToString());
        }

        public static void AppendLine<T>(this StringBuilder builder, T value)
        {
            builder.AppendLine(value.ToString());            
        }

        public static void AppendLineFormat(this StringBuilder builder, string format, params object[] args)
        {
            builder.AppendFormat(format, args);
            builder.AppendLine();
        }

        public static void Append<T>(this StringBuilder builder, T value)
        {
            builder.Append(value.ToString());
        }
    }
}
