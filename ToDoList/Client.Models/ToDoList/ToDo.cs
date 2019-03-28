namespace Client.Models.ToDoList
{
    /// <summary>
    /// Заметка для выполнения (ToDo)
    /// </summary>
    public class ToDo : ToDoInfo
    {
        /// <summary>
        /// Текст ToDo
        /// </summary>
        public string Text { get; set; }
    }
}
