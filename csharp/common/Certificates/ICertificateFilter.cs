using System.Security.Cryptography.X509Certificates;

namespace Health.Direct.Common.Certificates
{
	public interface ICertificateFilter
	{
		X509Certificate2Collection FilterSigningCertificates( X509Certificate2Collection certificatesToFilter );
		X509Certificate2Collection FilterEncryptionCertificates( X509Certificate2Collection certificatesToFilter );
	}
}