using System.Security.Cryptography;
using System.Text;

namespace Aoc._2015.day04.v1;

public class Hasher(string secret)
{
    private readonly MD5 CryptoServiceProvider = MD5.Create();
    public string? LastHashedString { get; private set; }
    private int SecretSuffix = 0;

    public string IterateOnSecret()
    {
        SecretSuffix += 1;
        return MD5FromString($"{secret}{SecretSuffix}");
    }

    public string MD5FromString(string from)
    {
        var sourceAsBytes = Encoding.ASCII.GetBytes(from);
        var hash = CryptoServiceProvider.ComputeHash(sourceAsBytes);
        var hashAsString = ByteArrayToString(hash);

        LastHashedString = from;
        return hashAsString;
    }

    private static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new(arrInput.Length);
        for (i = 0; i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
}