﻿using System;
using System.Net;
using System.Net.Http.Headers;
using GraphQL;

namespace GitStatus
{
    public class GraphQLException : Exception
    {
        public GraphQLException(in GraphQLError[] errors,
                                in HttpResponseHeaders responseHeaders,
                                in HttpStatusCode statusCode)
        {
            Errors = errors;
            StatusCode = statusCode;
            ResponseHeaders = responseHeaders;
        }

        public GraphQLError[] Errors { get; }
        public HttpStatusCode StatusCode { get; }
        public HttpResponseHeaders ResponseHeaders { get; }
    }
}