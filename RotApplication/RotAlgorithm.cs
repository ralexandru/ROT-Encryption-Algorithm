namespace RotApplication
{
    class RotAlgorithm
    {
        byte rotNumber; // number of rotations
        public RotAlgorithm(byte rotNumber=13) // if there isn't any number defined as a parameter, 13 is the default value
        {
            this.rotNumber = rotNumber;
        }

        public static string Encrypt(RotAlgorithm rotAlg,string textToEncrypt) // takes as parameter an object of this class(in order to use the specified number of rotations) and the string to be encrypted.
        {
            // ASCII : a = 97 ; z = 122 ; A = 65 ; Z = 90;
            string encryptedText ="";
            foreach(char character in textToEncrypt)
            {
                if ((byte)character >= 97 && (byte)character <= 122) // checks if the character is between a-z
                {
                    if ((byte)character + rotAlg.rotNumber <= 122)
                    {
                        encryptedText += (char)((byte)character + rotAlg.rotNumber);
                    }
                    else
                    {
                        encryptedText += (char)(97 + (((byte)character - 1 + rotAlg.rotNumber) - 122)); // if number of rotations exceeds the ASCII value of z, the rest rotations will continue starting with the ASCII value of a
                    }
                }
                else if ((byte)character >= 65 && (byte)character <= 90) // checks if the character is between A-Z
                {
                    if ((byte)character + rotAlg.rotNumber <= 90)
                        encryptedText += (char)((byte)character + rotAlg.rotNumber);
                    else
                    {
                        encryptedText += (char)(65 + (((byte)character - 1 + rotAlg.rotNumber) - 90));
                    }
                }
                else
                    encryptedText += character; // if character is not a letter, add it as it is
            }
            return encryptedText; // return the encrypted text.
        }

        public static string Decrypt(RotAlgorithm rotAlg, string textToDecrypt) // decrypts a text encrypted using a rot algorithm
        {
            string decryptedText = "";
            foreach (char character in textToDecrypt)
            {
                if ((byte)character >= 97 && (byte)character <= 122) // checks if the character is between a-z
                {
                    if ((byte)character - rotAlg.rotNumber >= 97)
                    {
                        decryptedText += (char)((byte)character - rotAlg.rotNumber);
                    }
                    else // while decrypting, we have to decrease the ASCII value of the character with the number of rotations specified by the algorithm
                    // so, in order to do that, we are subtracting from the ASCII value of z the number of rotations left after reaching the ASCII value
                    // of a.
                    {
                        decryptedText += (char)(122 - ((97-((byte)character+1-rotAlg.rotNumber ))));
                    }
                }
                else if ((byte)character >= 65 && (byte)character <= 90) // checks if the character is between A-Z
                {
                    if ((byte)character - rotAlg.rotNumber >= 65)
                        decryptedText += (char)((byte)character - rotAlg.rotNumber);
                    else
                    {
                        decryptedText += (char)(90 - ((65 - ((byte)character + 1 - rotAlg.rotNumber))));
                    }
                }
                else
                    decryptedText += character; // if character is not a letter, add it as it is
            }
            return decryptedText;
        }

        public static byte CheckROTEncryption(string decryptedText, string encryptedText)
        {
            byte rotAlgorithmUsed = 0; // this variable is going to be incremented for each rotation made untill the ASCII value of encryptedText == ASCII value of decryptedText
            int indexOfChar = 0;
            for(int i = 0; i < encryptedText.Length;i++)
            {
                if ((encryptedText[i] >= 65 && encryptedText[i] <= 90) || (encryptedText[i] >= 97 && encryptedText[i] <= 122)) // we only need the first character that is a letter from the string
                {
                    indexOfChar = i;
                    break;
                }
            }
            byte ASCIIofEncryptedChar = (byte)encryptedText[indexOfChar]; //converting the encrypted character to byte.
            byte ASCIIofDecryptedChar = (byte)decryptedText[indexOfChar]; //converting the decrypted character to byte.
            while(ASCIIofEncryptedChar != ASCIIofDecryptedChar)
            {
                rotAlgorithmUsed++; // incrementing the number of rotations made
                ASCIIofEncryptedChar--;
                if (ASCIIofEncryptedChar < 65) // if the encrypted character reaches the lower limit(ASCII value of 'a') we have to go to the upper limit(ASCII value of 'z')
                    ASCIIofEncryptedChar = 90;
                else if(ASCIIofEncryptedChar < 97 && ASCIIofEncryptedChar > 90) // same thing but for uppercase letters.
                    ASCIIofEncryptedChar = 122;    
            }
            return rotAlgorithmUsed; //returning the number of rotations made as an int.
        }
    }
}
