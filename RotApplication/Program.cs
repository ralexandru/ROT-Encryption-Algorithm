using System;

namespace RotApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RotAlgorithm rot13 = new RotAlgorithm(); //Create an object of RotAlgorithm class specifing the number of rotations if nothing is specified, then ROT13 algorithm is used by default)
            string textEncryptedWithRot13 = RotAlgorithm.Encrypt(rot13, "An example of encrypted text. (ROT13)"); //To encrypt a text, call the static method Encrypt of the RotAlgorithm class that returns the encrypted string.
            Console.WriteLine("ENCRYPTED USING ROT13: " + textEncryptedWithRot13);
            //Output: ENCRYPTED USING ROT13: Na rknzcyr bs rapelcgrq grkg. (EBG13)

            RotAlgorithm rot3 = new RotAlgorithm(3);
            string textEncryptedWithRot3 = RotAlgorithm.Encrypt(rot3, "An example of encrypted text. (ROT3)");
            Console.WriteLine("ENCRYPTED USING ROT3: " + textEncryptedWithRot3);
            //Output: ENCRYPTED USING ROT3: Dq hadpsoh ri hqfubswhg whaw. (URW3)

            RotAlgorithm rot5 = new RotAlgorithm(5);
            string textEncryptedWithRot5 = RotAlgorithm.Encrypt(rot5, "An example of encrypted text. (ROT5)");
            Console.WriteLine("ENCRYPTED USING ROT5: " + textEncryptedWithRot5);
            //Output: ENCRYPTED USING ROT5: Fs jcfruqj tk jshwduyji yjcy. (WTY5)

            // Decrypting the encrypted text
            Console.WriteLine(RotAlgorithm.Decrypt(rot13, textEncryptedWithRot13));
            //Output: An example of encrypted text. (ROT13)

            Console.WriteLine(RotAlgorithm.Decrypt(rot3, textEncryptedWithRot3));
            //Output: An example of encrypted text. (ROT3)

            Console.WriteLine(RotAlgorithm.Decrypt(rot5, textEncryptedWithRot5));
            //Output: An example of encrypted text. (ROT5)

            string decryptedText = "Text to encrypt";
            string encryptedText = RotAlgorithm.Encrypt(new RotAlgorithm(10), decryptedText);
            Console.WriteLine("This text is encrypted using ROT"+RotAlgorithm.CheckROTEncryption(decryptedText,encryptedText));
            //RotAlgorithm.CheckROTEncryption(decryptedText,encryptedText); -> returns the ROT algorithm used to encrypt the decryptedText.
        }
    }
}
