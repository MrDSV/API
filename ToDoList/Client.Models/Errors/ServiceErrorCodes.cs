using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models.Errors
{
    /// <summary>
    /// Коды ошибок
    /// </summary>
    public class ServiceErrorCodes
    {
        /// <summary>
        /// Системная ошибка
        /// </summary>
        public const string System = "system";

        /// <summary>
        /// Не найдено
        /// </summary>
        public const string NotFound = "not-found";

        /// <summary>
        /// Нет доступа
        /// </summary>
        public const string Forbidden = "auth:forbidden";

        /// <summary>
        /// Некорректный запрос
        /// </summary>
        public const string BadRequest = "bad-request";

        /// <summary>
        /// Ошибка валидации
        /// </summary>
        public const string ValidationError = "validation:error";
    }
}
