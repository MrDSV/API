namespace Client.Models.ToDoList
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Информация о ToDo
    /// </summary>
    public class ToDoInfo
    {
        /// <summary>
        /// Идентификатор ToDo
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит ToDo
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Флаг, указывающий, выполнено ToDo или нет
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Дата создания ToDo
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего изменения ToDo
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }

        
    }
}
