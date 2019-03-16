

namespace Shop
{
    using Shop.BuisnessLayer;
    using Shop.BuisnessLayer.Errors;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;

    /// <inheritdoc />
    /// <summary>
    /// The base api controller.
    /// </summary>
    [EnableCors("DefaultProfile")]
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// The error.
        /// </summary>
        /// <typeparam name="T">
        /// Any error
        /// </typeparam>
        /// <returns>
        /// The <see cref="ApiError"/>.
        /// </returns>
        protected ApiError Error<T>()
            where T : IError, new()
        {
            var errorInstance = new T();

            return this.Error(errorInstance);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="error">
        /// The error object.
        /// </param>
        /// <returns>
        /// The <see cref="ApiError"/>.
        /// </returns>
        protected ApiError Error(IError error)
        {
            var errorInstance = new ApiError(HttpStatusCode.BadRequest, error, this);

            return errorInstance;
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="errorList">
        /// The error list.
        /// </param>
        /// <returns>
        /// The <see cref="ApiError"/>.
        /// </returns>
        protected ApiError Error(IEnumerable<string> errorList) =>
            new ApiError(HttpStatusCode.InternalServerError, new InternalServerError(errorList), this);

        /// <summary>
        /// Check model state and put converted error
        /// </summary>
        /// <returns>
        /// The <see cref="ApiError" />.
        /// </returns>
        protected ApiError GetModelError()
        {
            if (this.ModelState.IsValid)
            {
                return null;
            }

            return new ApiError(
                HttpStatusCode.BadRequest,
                new ArgumentError(this.ModelState.Values.First(v => v.Errors.Any()).Errors.Select(x => x.ErrorMessage)),
                this);
        }

        /// <summary>
        /// The not found.
        /// </summary>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <returns>
        /// The <see cref="ApiError"/>.
        /// </returns>
        protected ApiError NotFound(IError error) => new ApiError(HttpStatusCode.NotFound, error, this);

        /// <summary>
        /// The run handler.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <typeparam name="THandler">
        /// Any type inherited from <see cref="BaseCommandHandler{TCommand,TResponse}"/>
        /// </typeparam>
        /// <typeparam name="TCommand">
        /// Any type as command
        /// </typeparam>
        /// <typeparam name="TResponse">
        /// Any type as response
        /// </typeparam>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        protected IHttpActionResult RunHandler<THandler, TCommand, TResponse>(TCommand command) where THandler : BaseCommandHandler<TCommand, TResponse>
        {
            var result = this.Using<THandler>().Execute(command);

            if (!result.Succeeded)
            {
                return this.Error(result.Errors.First());
            }

            return this.Ok(result.Data);
        }

        /// <summary>
        /// The run handler.
        /// </summary>
        /// <typeparam name="THandler">
        /// Any type inherited from <see cref="BaseCommandHandler{TResponse}"/>
        /// </typeparam>
        /// <typeparam name="TResponse">
        /// Any type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        protected IHttpActionResult RunHandler<THandler, TResponse>() where THandler : BaseCommandHandler<TResponse>
        {
            var result = this.Using<THandler>().Execute();

            if (!result.Succeeded)
            {
                return this.Error(result.Errors.First());
            }

            return this.Ok(result.Data);
        }

        /// <summary>
        /// The using.
        /// </summary>
        /// <typeparam name="T">
        /// Any reference type
        /// </typeparam>
        /// <returns>
        /// The <see cref="Using{T}" />.
        /// </returns>
        /// <exception cref="NullReferenceException">
        /// Type can not be resolved
        /// </exception>
        [DebuggerStepThrough]
        protected T Using<T>()
            where T : class
        {
            var resolver = StartupConfig.Config.DependencyResolver;
            var handler = resolver.GetService(typeof(T)) as T;
            if (handler == null)
            {
                throw new NullReferenceException($"Unable to resolve type with service locator; type {typeof(T).Name}");
            }

            return handler;
        }
    }
}
