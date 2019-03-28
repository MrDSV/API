using MongoDB.Bson.Serialization.Attributes;

namespace Models.ToDoList
{
    /// <summary>
    /// Заметка для выполнения (ToDo)
    /// </summary>
    public class ToDo : ToDoInfo
    {
        /// <summary>
        /// Текст ToDo
        /// </summary>
        [BsonRequired]
        public string Text { get; set; }
    }
}
