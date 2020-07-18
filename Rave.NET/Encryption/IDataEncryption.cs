using System;
using System.Collections.Generic;
using System.Text;

namespace Rave
{
    public interface IDataEncryption
    {
        ///<summary>
        ///Fetches encryption key from dashboard using secretkey
        /// </summary>
        /// <params name="secretKey">The secret key generated in your Rave dashboard</params>
        string GetEncryptionKey(string secretKey);

        string EncryptData(string encryptionKey, string data);

        string DecryptData(string encryptedData, string encryptionKey);
    }
}
