﻿namespace EasyPass
{
    internal interface IEncryptor
    {
        string Encrypt(string textToEnrypt);
        string Decrypt(string textToDecrypt);
    }
}