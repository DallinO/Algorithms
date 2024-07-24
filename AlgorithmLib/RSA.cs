/* CSE 381 - RSA 
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Euclid, ModularExponentiation, GeneratePrivateKey,
*  Encrypt, and Decrypt functions per the instructions in the comments.  
*  Run all tests in RSATest.cs to verify your code.
*  Submit this file and the completed RSA.md file into Canvas.
*/

using System.Numerics;

namespace AlgorithmLib;

public class RSA
{
    // Recursively use Euclid to find the Greatest Common Divisor between two numbers
    // as well as the linear combination form.
    public static (BigInteger gcd, BigInteger x, BigInteger y) Euclid(BigInteger a, BigInteger b)
    {
        if (b == 0)
            return (a, 1, 0);

        (BigInteger gcd, BigInteger x1, BigInteger y1) = Euclid(b, a % b);
        BigInteger x = y1;
        BigInteger y = x1 - (a / b) * y1;

        return (gcd, x, y);
    }

    // Recursively calculates x^y mod n
    public static BigInteger ModularExponentiation(BigInteger x, BigInteger y, BigInteger n)
    {
        if (y == 0)
            return 1;

        BigInteger z = ModularExponentiation(x, y / 2, n);
        if (y % 2 == 0)
            return (z * z) % n;
        else
            return (x * z * z) % n;
    }

    // Generate the RSA private key given the two prime numbers p and q and
    // the public key e which was selected to be co-prime with r = (p-1) * (q-1).
    public static BigInteger GeneratePrivateKey(BigInteger p, BigInteger q, BigInteger e)
    {
        BigInteger phi = (p - 1) * (q - 1);
        var (gcd, x, y) = Euclid(e, phi);
        if (gcd != 1)
            throw new ArgumentException("e must be co-prime with (p-1)*(q-1)");

        BigInteger d = x % phi;
        if (d < 0)
            d += phi;

        return d;
    }

    // Encrypt a value using the public keys e and n
    public static BigInteger Encrypt(BigInteger value, BigInteger e, BigInteger n)
    {
        return ModularExponentiation(value, e, n);
    }

    // Decrypt a value using the public key n and private key d
    public static BigInteger Decrypt(BigInteger value, BigInteger d, BigInteger n)
    {
        return ModularExponentiation(value, d, n);
    }
}