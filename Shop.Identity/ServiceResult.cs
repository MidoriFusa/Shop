﻿namespace Shop.Identity
{
    using System.Collections.Generic;

    using Shop.Common;

    /// <summary>
    /// The service result.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class ServiceResult<T> : IError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public ServiceResult(T data)
        {
            this.Data = data;
            this.Succeeded = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public ServiceResult(ErrorCodes code, string message)
        {
            this.ErrorCode = code;
            this.Errors = new List<string> { message };
            this.Succeeded = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="messages">
        /// The messages.
        /// </param>
        public ServiceResult(ErrorCodes code, IEnumerable<string> messages)
        {
            this.ErrorCode = code;
            this.Errors = messages;
            this.Succeeded = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResult{T}"/> class.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        public ServiceResult(IError error)
            : this(error.ErrorCode, error.Errors)
        {
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Gets a value indicating whether succeeded.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public ErrorCodes ErrorCode { get; private set; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }
    }
}