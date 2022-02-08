# ROT-Encryption-Algorithm
Using the RotAlgorithm class you can encrypt/decrypt a text using any kind of ROT Algorithm(1,2,3..n). You can also check the type of ROT Algorithm used to encrypt a text.

<h2>Description</h2>
ROT Algorithm is an encryption algorithm used to cypher messages. This algorithm is rotating each letter from a message to the right to a fixed number of positions.<br/>
For example: ROT13 Algorithm: a -> n , ROT3 ALGORITHM: a -> d , ROT5 ALGORITHM: a -> f<br/>
Doing this for each letter of a text, we will get an encrypted message, as we can see in the picture below.<br/>
<img src="https://i.imgur.com/11YYBkh.png" align="center"/><br/>
The above picture shows how the "HELLO WORLD" message looks encrypted using ROT13.
Using this repository, you can encrypt and decrypt messages using any kind of ROT algorithm(1,2,3,...,n), and you can also check what type of ROT Algorithm was used in order to encrypt a message.
<h2>Usage</h2>

1.First, you need to create an object of the RotAlgorithm class passing a parameter of type int that represents the type of ROT Algorithm you would like to use. <br/>
<code>
RotAlgorithm rot13 = new RotAlgorithm(); // 13 is the default value, so no need to pass any arguments
</code><br/>
2.In order to encrypt a text, we need to use the RotAlgorithm object created previously and a string.<br/>
<code>
string encryptedText = RotAlgorithm.Encrypt(rot13, "Text to encrypt"); // encrypts the text using the rot13 algorithm
</code><br/>
3.To decrypt the message, we will use the RotAlgorithm.Decrypt() method, passing the ROT algorithm used to encrypt the message and the encrypted message.<br/>
<code>
string decryptedText = RotAlgorithm.Decrypt(rot13, encryptedText); // decrypts the encrypted text
</code><br/>
4.To check what ROT Algorithm was used to encrypt a message we need to call the RotAlgorithm.CheckROTEncryption() method, passing the decrypted and the encrypted message. The result will be returned as an int.<br/>
<code>
int rotAlgorithm = RotAlgorithm.CheckROTEncryption(decryptedText,encryptedText); // returns the ROT Algorithm used in order to encrypt a text as an integer. For example, ROT5 will return 5
</code><br/>
