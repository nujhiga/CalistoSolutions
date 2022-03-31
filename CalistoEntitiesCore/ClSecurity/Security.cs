using System.Security.Cryptography;
using System.Text;

namespace CalistoEnvironment.ClSecurity;
public static class Security
{
    public static string Encrypt(string key, string data)
    {
        string encData = null!;
        var keys = GetHashKeys(key);

        try
        {
            encData = EncryptStringToBytesAes(data, keys[0], keys[1]);
        }
        catch (CryptographicException)
        {
        }
        catch (ArgumentNullException)
        {
        }

        return encData;
    }

    public static string Decrypt(string key, string data)
    {
        string decData = null!;
        var keys = GetHashKeys(key);

        try
        {
            decData = DecryptStringFromBytesAes(data, keys[0], keys[1]);
        }
        catch (CryptographicException)
        {
        }
        catch (ArgumentNullException)
        {
        }

        return decData;
    }

    private static byte[][] GetHashKeys(string key)
    {
        var result = new byte[2][];
        var enc = Encoding.UTF8;

        using SHA256 sha256 = SHA256.Create();

        var rawKey = enc.GetBytes(key);
        var rawIV = enc.GetBytes(key);

        var hashKey = sha256.ComputeHash(rawKey);
        var hashIV = sha256.ComputeHash(rawIV);

        Array.Resize(ref hashIV, 16);

        result[0] = hashKey;
        result[1] = hashIV;

        return result;
    }

    //source: https://msdn.microsoft.com/de-de/library/system.security.cryptography.aes(v=vs.110).aspx
    private static string EncryptStringToBytesAes(string plainText, byte[] Key, byte[] IV)
    {
        if (plainText is not { Length: > 0 }) throw new ArgumentNullException(nameof(plainText));
        if (Key is not { Length: > 0 }) throw new ArgumentNullException(nameof(Key));
        if (IV is not { Length: > 0 }) throw new ArgumentNullException(nameof(IV));

        using Aes aes = Aes.Create();

        aes.Key = Key;
        aes.IV = IV;

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var msEncrypt = new MemoryStream();

        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

        using var swEncrypt = new StreamWriter(csEncrypt);

        swEncrypt.Write(plainText);

        var encrypted = msEncrypt.ToArray();

        return Convert.ToBase64String(encrypted);
    }

    //source: https://msdn.microsoft.com/de-de/library/system.security.cryptography.aes(v=vs.110).aspx
    private static string DecryptStringFromBytesAes(string cipherTextString, byte[] Key, byte[] IV)
    {
        byte[] cipherText = Convert.FromBase64String(cipherTextString);

        if (cipherText is not { Length: > 0 }) throw new ArgumentNullException(nameof(cipherText));
        if (Key is not { Length: > 0 }) throw new ArgumentNullException(nameof(Key));
        if (IV is not { Length: > 0 }) throw new ArgumentNullException(nameof(IV));

        using var aes = Aes.Create();

        aes.Key = Key;
        aes.IV = IV;

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var msDecrypt = new MemoryStream(cipherText);

        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

        using var srDecrypt = new StreamReader(csDecrypt);

        var plaintext = srDecrypt.ReadToEnd();

        return plaintext;
    }

    public static string HexToString(string byteString)
    {
        var bArray = ByteStringToArray(byteString);
        return Encoding.ASCII.GetString(bArray);
    }

    private static byte[] ByteStringToArray(string byteString)
    {
        byte[] bytes = new byte[byteString.Length];

        for (int i = 0; i < bytes.Length; i += 2)
            bytes[i] = Convert.ToByte(byteString[i..2], 16);

        return bytes;
        //var byteList = new List<byte>();

        //for (var i = 0; i < byteString.Length; i += 2)
        //    byteList.Add(Convert.ToByte(byteString.Substring(i, 2), 16));

        //return byteList.ToArray();
    }
}
