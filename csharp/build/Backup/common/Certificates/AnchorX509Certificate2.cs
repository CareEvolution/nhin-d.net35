﻿/* 
 Copyright (c) 2013, Direct Project
 All rights reserved.

 Authors:
    Umesh Madan     umeshma@microsoft.com
  
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
Neither the name of The Direct Project (directproject.org) nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Health.Direct.Common.Certificates
{
    /// <summary>
    /// A X509Certificate2 representing an Anchor
    /// You can tack on additional properties such as required OIDs and data. 
    /// Note: these properties are not persisted when you save the certificate.
    /// </summary>
    public class AnchorX509Certificate2 : DisposableX509Certificate2
    {
            /// <summary>
        /// Construct a new certificate
        /// </summary>
        /// <param name="rawData">certificate data</param>
        public AnchorX509Certificate2(byte[] rawData)
            : base(rawData)
        {
        }
        
        /// <summary>
        /// Construct a new certificate
        /// </summary>
        /// <param name="rawData">rawData</param>
        /// <param name="password">password</param>
        public AnchorX509Certificate2(byte[] rawData, string password)
            : base(rawData, password)
        {
        }
        
        /// <summary>
        /// Construct a new X509Certificate
        /// </summary>
        /// <param name="rawData">certificate data</param>
        /// <param name="password">password</param>
        /// <param name="keyStorageFlags">storage flags</param>
        public AnchorX509Certificate2(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags)
            : base(rawData, password, keyStorageFlags)
        {
        }
        
        /// <summary>
        /// OPTIONAL
        /// Additional properties associated with this Anchor certificate
        /// </summary>
        public AnchorMetadata Metadata
        {
            get; set;
        }        
        
        /// <summary>
        /// Returns true if this certificate has associated metadata
        /// </summary>
        public bool HasMetadata
        {
            get { return (this.Metadata != null);}
        }
    }
}
