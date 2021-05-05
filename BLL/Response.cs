using System.Collections.Generic;

namespace BLL
{
    public class Response<T>
    {
        public T Object { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public Response(T _object) 
        {
            Object = _object;
            Error = false;
        }
        public Response(string message)
        {
            Message = message;
            Error = true;
        }  
    }

    public class ResponseList<T>
    {
        public List<T> Objects { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }

        public ResponseList(List<T> _objects)
        {
            Objects = _objects;
            Error = false;
        }

        public ResponseList(string message)
        {
            Error = true;
            Message = message;
        }
        
        
    }
}