# RSA - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the RSA.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain the process for calculating the public keys in RSA.

First, two distinct large prime numbers, p and q, are selected. These primes are kept secret. Next, their product n is computed. This value is used as part of both the public and private keys and is crucial for the encryption and decryption processes. The totient function represents the count of integers up to n that are coprime with n. A public exponent e is then chosen. Common choices for e include 3, 17, and 65537, as these values often strike a good balance between security and computational efficiency. The public key is composed of the pair (e,n). The value n acts as the modulus for both the public and private keys, while e serves as the exponent in the encryption process. This public key is distributed openly and used to encrypt messages, ensuring that only the holder of the corresponding private key can decrypt them. The private key, which includes the private exponent d, remains confidential to ensure the security of the encrypted communications.

2. Explain the process for calculating the private key in RSA.

The private key calculation hinges on the totient function. The first step is to ensure that the public exponent e is coprime with n. This ensures that e has a multiplicative inverse modulo n, which is crucial for decryption. Once the coprimality is confirmed, the next step is to compute the private exponent d, which is the modular multiplicative inverse of e modulo n. The extended Euclidean algorithm is typically used to find this inverse efficiently. The algorithm not only calculates the greatest common divisor but also provides the coefficients that satisfy Bézout's identity, from which d is derived. The private exponent d must be a positive integer less than n. Once d is determined, the private key is formed by the pair (d,n). Here, n is the modulus, shared with the public key, while d is kept secret. This private key allows the decryption of messages encrypted with the corresponding public key (e,n). Essentially, while the public key encrypts the data, only the private key can decrypt it.

3. Explain the process for calculating a^b mod N using recursion.

This method known as modular exponentiation or exponentiation by squaring. The process leverages the properties of modular arithmetic and recursive function calls to break down the problem into more manageable pieces. The algorithm works by recursively reducing the exponent b. If b is zero, the result is 1, as any number to the power of zero is one. For other values of b, the algorithm checks whether b is even or odd. If b is even, the problem can be reduced to calculating (a^b/2)^2 mod  N. If b is odd, the expression a^b mod N can be broken down and further reduced recursively. By repeatedly halving the exponent and squaring the result, the algorithm minimizes the number of multiplications required. The intermediate results are taken modulo N to prevent overflow and keep the calculations within a practical range. This method is both time efficient and space efficient due to the limited depth of the recursion.

## 3. Performance (10%)

The performance for the modular exponentiation (where $n$ is the exponent value)

* Worst Case: $O(logb)$
* Best Case: $\Omega(logb)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore Elliptic Curve Cryptography (ECC) and compare it with RSA.

ECC and RSA are both widely used public-key cryptographic systems, but they differ in terms of efficiency and security. ECC is based on the mathematics of elliptic curves over finite fields, while RSA relies on the difficulty of factoring large integers. One of the main advantages of ECC over RSA is that it offers comparable security with much smaller key sizes. For example, a 256-bit key in ECC provides a similar level of security to a 3072-bit key in RSA. This leads to faster computations, reduced storage requirements, and lower power consumption, making ECC particularly suitable for environments with constrained resources. Additionally, smaller key sizes in ECC result in faster encryption and decryption processes, as well as quicker key generation. However, ECC is more complex and requires careful implementation to avoid security pitfalls. Despite this, ECC's efficiency advantages make it increasingly popular.