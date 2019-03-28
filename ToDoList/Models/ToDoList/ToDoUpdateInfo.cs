using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ToDoList
{
    public class ToDoUpdateInfo
    {
        public ToDoUpdateInfo(int id, string text = null, bool? isDone = null)
        {
            this.Id = id;
            this.IsDone = isDone;
            this.Text = text;
        }

        /// <summary>
        /// Идентификатор модифицируемого ToDo
        /// </summary>
        public  int Id { get; }

        /// <summary>
        /// Флаг, указывающий выполнение ToDo
        /// </summary>
        public bool? IsDone { get; set; }

        /// <summary>
        /// Текст ToDo
        /// </summary>
        public string Text { get; set; }

    }
}
