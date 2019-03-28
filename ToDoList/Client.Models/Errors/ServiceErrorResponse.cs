using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Client.Models.Errors
{
    /// <summary>
    /// Сервисный ответ с ошибкой
    /// </summary>
    public class ServiceErrorResponse
    {
        /// <summary>
        /// Статус код ответа
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Ошибка
        /// </summary>
        public ServiceError Error { get; set; }
    }
}
