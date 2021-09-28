using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Autentication_FormsApp.Service
{
    public class LlamarAPI
    {
        public Object Ejecutar<T>(string url, T objectRequest, string method = "POST")
        {
            Object respuesta = new object();

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    respuesta = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                respuesta = e.Message;

            }

            return respuesta;
        }
    }
}
