﻿using Newtonsoft.Json;

namespace MTEFDataAccess.Model
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }

        public Response(bool success, string msg, T data)
        {
            Data = data;
            Succeeded = success;
            Message = msg;
        }
        public Response()
        {
        }
        /// <summary>
        /// Sets the data to the appropriate response
        /// at run time
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static Response<T> Fail(string errorMessage)
        {
            return new Response<T> { Succeeded = false, Message = errorMessage };
        }
        public static Response<T> Success(string successMessage, T data = default)
        {
            return new Response<T> { Succeeded = true, Message = successMessage, Data = data };
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

}
