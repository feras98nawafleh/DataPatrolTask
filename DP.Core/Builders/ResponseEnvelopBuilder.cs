using DP.Core.Models;
using System.Net;

namespace DP.Core.Builders
{
    public class ResponseEnvelopeBuilder<T>
    {
        private bool _success;
        private T _data;
        private string _message;
        private HttpStatusCode _statusCode;

        public ResponseEnvelopeBuilder()
        {
            _success = true;
            _message = string.Empty;
        }

        public ResponseEnvelopeBuilder<T> WithSuccess()
        {
            _success = true;
            return this;
        }

        public ResponseEnvelopeBuilder<T> WithError()
        {
            _success = false;
            return this;
        }

        public ResponseEnvelopeBuilder<T> WithData(T data)
        {
            _data = data;
            return this;
        }

        public ResponseEnvelopeBuilder<T> WithMessage(string message = "")
        {
            if(string.IsNullOrEmpty(message))
                _message = this._statusCode.ToString();
            else
                _message = message;

            return this;
        }

        public ResponseEnvelopeBuilder<T> WithStatusCode(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public ResponseEnvelope<T> Build()
        {
            if(string.IsNullOrEmpty(this._message))
                this._message = this._statusCode.ToString();

            return new ResponseEnvelope<T>
            {
                Success = _success,
                Data = _data,
                Message = _message,
                StatusCode = _statusCode
            };
        }

        public static ResponseEnvelope<T> SuccessResponse(T data, HttpStatusCode statusCode)
        {
            return new ResponseEnvelopeBuilder<T>()
                .WithSuccess()
                .WithData(data)
                .WithStatusCode(statusCode)
                .Build();
        }

        public static ResponseEnvelope<T> ErrorResponse(HttpStatusCode statusCode)
        {
            return new ResponseEnvelopeBuilder<T>()
                .WithError()
                .WithData(default)
                .WithStatusCode(statusCode)
                .Build();
        }
    }

}
