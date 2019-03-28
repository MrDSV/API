using MongoDB.Bson.Serialization.Attributes;

namespace Models.ToDoList
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
        [BsonId]
        //[BsonRequired]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит ToDo
        /// </summary>
        [BsonRequired]
        //[BsonId]
        public string UserId { get; set; }

        /// <summary>
        /// Флаг, указывающий, выполнено ToDo или нет
        /// </summary>
        [BsonRequired]
        public bool IsDone { get; set; }

        /// <summary>
        /// Дата создания ToDo
        /// </summary>
        [BsonRequired]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата последнего изменения ToDo
        /// </summary>
        [BsonRequired]
        public DateTime LastUpdatedAt { get; set; }
    }
}
