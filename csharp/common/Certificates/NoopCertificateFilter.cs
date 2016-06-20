using System.Security.Cryptography.X509Certificates;

namespace Health.Direct.Common.Certificates
{
	public class NoopCertificateFilter : ICertificateFilter
	{
		public X509Certificate2Collection FilterEncryptionCertificates( X509Certificate2Collection certificatesToFilter )
		{
			return certificatesToFilter;
		}

		public X509Certificate2Collection FilterSigningCertificates( X509Certificate2Collection certificatesToFilter )
		{
			return certificatesToFilter;
		}
	}
}