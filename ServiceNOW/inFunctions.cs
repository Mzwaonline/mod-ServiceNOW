﻿namespace ServiceNOW
{
    //
    // This is the service reference
    //
    using snIndb;
    using System;
    using System.Net;
    public class inFunctions
    {
        /// <summary>
        /// This function creates a new incident in ServiceNOW
        /// </summary>
        /// <param name="Credential">A credential object that gets passed to the soap client for authentication</param>
        /// <param name="Incident">An insert object that contains the data to be inserted into ServiceNOW</param>
        /// <returns>An insertResponse object containing data returned from ServiceNOW</returns>
        public static insertResponse NewIncident(NetworkCredential Credential, insert Incident)
        {
            try
            {
                string userName = Credential.UserName;
                string userPass = Credential.Password;
                ServiceNowSoapClient client = soapClient(userName, userPass);

                insertResponse response = new insertResponse();

                response = client.insert(Incident);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// A private function to create the soapclient to communicate with ServiceNOW
        /// </summary>
        /// <param name="UserName">The API Username</param>
        /// <param name="Password">The API Password</param>
        /// <returns>A ServiceNow SoapClient object</returns>
        private static ServiceNowSoapClient soapClient(string UserName, string Password)
        {
            try
            {
                ServiceNowSoapClient soapClient = new ServiceNowSoapClient();
                soapClient.ClientCredentials.UserName.UserName = UserName;
                soapClient.ClientCredentials.UserName.Password = Password;
                return soapClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}