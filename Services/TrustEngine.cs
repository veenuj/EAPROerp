using System.Security.Cryptography;
using System.Text;

public class TrustEngine
{
    public static string CalculateHash(int index, DateTime timestamp, string data, string prevHash)
    {
        string rawData = $"{index}{timestamp}{data}{prevHash}";
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Convert.ToHexString(bytes);
        }
    }
}