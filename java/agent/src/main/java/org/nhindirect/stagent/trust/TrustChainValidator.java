/* 
Copyright (c) 2010, NHIN Direct Project
All rights reserved.

Authors:
   Umesh Madan     umeshma@microsoft.com
   Greg Meyer      gm2552@cerner.com
 
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
in the documentation and/or other materials provided with the distribution.  Neither the name of the The NHIN Direct Project (nhindirect.org). 
nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS 
BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
THE POSSIBILITY OF SUCH DAMAGE.
*/

package org.nhindirect.stagent.trust;

import java.security.cert.CertPath;
import java.security.cert.CertPathValidator;
import java.security.cert.Certificate;
import java.security.cert.CertificateFactory;
import java.security.cert.PKIXParameters;
import java.security.cert.TrustAnchor;
import java.security.cert.X509Certificate;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

/**
 * Validates the trust chain of a certificate with a set of anchors.
 * @author Greg Meyer
 * @author Umesh Madan
 *
 */
public class TrustChainValidator 
{

	/**
	 * Indicates if a certificate is considered to be trusted by resolving a valid certificate trust chain with the provided anchors.
	 * @param certificate The certificate to check.
	 * @param anchors A list of trust anchors used to check the trust chain.
	 * @return Returns true if the certificate can find a valid trust chain in the collection of anchors.  False otherwise.
	 */
    public boolean isTrusted(X509Certificate certificate, Collection<X509Certificate> anchors)
    {    	
    	if (certificate == null)
    		throw new IllegalArgumentException();
    	
    	if (anchors == null || anchors.size() == 0)
    		return false; // no anchors... conspiracy theory?  trust no one
    	
    	try
    	{
        	
    		CertPath certPath = null;
        	CertificateFactory factory = CertificateFactory.getInstance("X509");
        	
        	List<Certificate> certs = new ArrayList<Certificate>();
        	certs.add(certificate);
        	
        	Set<TrustAnchor> trustAnchorSet = new HashSet<TrustAnchor>();
        		
        	for (X509Certificate archor : anchors)
        		trustAnchorSet.add(new TrustAnchor(archor, null));
        	
            PKIXParameters params = new PKIXParameters(trustAnchorSet); 
            params.setRevocationEnabled(false); // NHIND Revocations are handled using ICertificateStore.getCertificate
        	certPath = factory.generateCertPath(certs);
        	CertPathValidator pathValidator = CertPathValidator.getInstance("PKIX");    		
    		

        	pathValidator.validate(certPath, params);
    		return true;
    	}
    	catch (Exception e)
    	{
    		e.printStackTrace();
    	}
    	
    	return false;    	
    }     	
}
